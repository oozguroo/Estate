import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Params, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { Category } from 'src/app/_models/category';
import { District } from 'src/app/_models/district';
import { House } from 'src/app/_models/house';
import { HouseParams } from 'src/app/_models/houseParams';
import { Pagination } from 'src/app/_models/pagination';
import { Town } from 'src/app/_models/town';
import { AccountService } from 'src/app/_services/account.service';
import { AdsService } from 'src/app/_services/ads.service';

@Component({
  selector: 'app-ads-list',
  templateUrl: './ads-list.component.html',
  styleUrls: ['./ads-list.component.css'],
})
export class AdsListComponent implements OnInit {
  houses: House[] = [];
  pagination: Pagination | undefined;
  houseParams: HouseParams = new HouseParams();
  categories: Category[] = [];
  towns: Town[] = [];
  districts: District[] = [];
  priceFromInput: number | null = null;
  priceToInput: number | null = null;

  constructor(
    private adsService: AdsService,
    private accountService: AccountService,
    private toastr: ToastrService,
    private router: Router,
    private route: ActivatedRoute
  ) {}

  ngOnInit(): void {
    this.route.queryParams.subscribe((params) => {
      // Retrieve the filter parameters from query params
      const queryParams: Partial<HouseParams> = { ...params };
  
      // Assign the retrieved values to the houseParams object
      this.houseParams.category = queryParams.category || '';
      this.houseParams.town = queryParams.town || '';
      this.houseParams.district = queryParams.district || '';
  
      // Retrieve the price filter values and convert them back to numbers
      this.priceFromInput = queryParams.priceFrom ? +queryParams.priceFrom : null;
      this.priceToInput = queryParams.priceTo ? +queryParams.priceTo : null;
  
      // Load the houses with the retrieved filter parameters
      this.loadHouses();
    });
  
    this.loadCategories();
    this.loadTowns();
    this.loadDistricts();
  }
  
  loadHouses() {
    this.houseParams.priceFrom = this.priceFromInput;
    this.houseParams.priceTo = this.priceToInput;
  
    this.adsService.getHouses(this.houseParams).subscribe({
      next: (response) => {
        if (response.result && response.pagination) {
          this.houses = response.result;
          this.pagination = response.pagination;
        }
      },
    });
  
    this.router.navigate([], {
      relativeTo: this.route,
      queryParams: {
        category: this.houseParams.category,
        town: this.houseParams.town,
        district: this.houseParams.district,
        priceFrom: this.houseParams.priceFrom,
        priceTo: this.houseParams.priceTo
      },
      queryParamsHandling: 'merge',
    });
  }
  
  pageChanged(event: any) {
    if (this.houseParams && this.houseParams.pageNumber !== event.page) {
      this.houseParams.pageNumber = event.page; // Update the pageNumber property
      this.loadHouses();
    }
  }


  goToAdDetail(adId: number): void {
    const queryParams: Params = {
      ...this.houseParams,
      priceFrom: this.priceFromInput?.toString() || '',
      priceTo: this.priceToInput?.toString() || ''
    };
  
    this.router.navigate(['/ads', adId], { queryParams });
  }
  

  
  resetFilters() {
    this.houseParams.category = '';
    this.houseParams.town = '';
    this.houseParams.district = '';
    this.priceFromInput = null;
    this.priceToInput = null;
    this.loadHouses(); //
  }
  loadTowns() {
    this.adsService.getHouseTowns().subscribe({
      next: (towns) => {
        this.towns = towns;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }
  loadDistricts() {
    this.adsService.getHouseDistricts().subscribe({
      next: (districts) => {
        this.districts = districts;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  loadCategories() {
    this.adsService.getHouseCategories().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: (error) => {
        console.log(error);
      },
    });
  }

  likeAd(houseId: number) {
    const appUserId = this.accountService.getCurrentUserId();
    if (appUserId) {
      this.adsService.addLike(appUserId, houseId).subscribe(
        () => {
          this.toastr.success('Added to Favourite List', 'Success');
        },
        (error) => {
          if (
            error.status === 400 &&
            error.error === 'You have already liked this ad.'
          ) {
            this.toastr.warning('You have already liked this ad.', 'Warning');
          } else {
            this.toastr.error(
              'An error occurred. Please try again later.',
              'Error'
            );
          }
        }
      );
    } else {
      this.toastr.error('An error occurred. Please try again later.', 'Error');
    }
  }
}

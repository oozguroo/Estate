import { Component, OnInit } from '@angular/core';
import { ToastrService } from 'ngx-toastr';
import { House } from 'src/app/_models/house';
import { AccountService } from 'src/app/_services/account.service';
import { AdsService } from 'src/app/_services/ads.service';

@Component({
  selector: 'app-ads-list',
  templateUrl: './ads-list.component.html',
  styleUrls: ['./ads-list.component.css'],
})
export class AdsListComponent implements OnInit {
  houses: House[] = [];
  
  constructor(
    private adsService: AdsService,
    private accountService: AccountService,
    private toastr:ToastrService
  ) {}

  ngOnInit(): void {
    this.loadHouses();
  }

  loadHouses() {
    this.adsService.getHouses().subscribe({
      next: (houses) => {
        this.houses = houses;
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
          if (error.status === 400 && error.error === 'You have already liked this ad.') {
            this.toastr.warning('You have already liked this ad.', 'Warning');
          } else {
            this.toastr.error('An error occurred. Please try again later.', 'Error');
          }
        }
      );
    } else {
      this.toastr.error('An error occurred. Please try again later.', 'Error');
    }
  }
  
  
  
  
  
  
  
  
  
}

import { Component, Input, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { Category } from 'src/app/_models/category';
import { District } from 'src/app/_models/district';
import { House } from 'src/app/_models/house';
import { Town } from 'src/app/_models/town';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AdsService } from 'src/app/_services/ads.service';

@Component({
  selector: 'app-ads-edit',
  templateUrl: './ads-edit.component.html',
  styleUrls: ['./ads-edit.component.css']
})
export class AdsEditComponent implements OnInit {
  @Input() user: User | undefined;
  houseForm!: FormGroup;
  house: House = {} as House;
  categories: Category[] = [];
  towns: Town[] = [];
  districts: District[] = [];

  constructor(  private adsService: AdsService,
    private formBuilder: FormBuilder,
    private route: ActivatedRoute,
    private router: Router,
    private accountService:AccountService,
    private toastr:ToastrService) {
      this.initializeForm();
      this.accountService.currentUser$.pipe(take(1)).subscribe({
        next: (user) => {
          if (user) this.user = user;
        }
      });
     }

  ngOnInit(): void {
    this.initializeForm();
    this.getCategories();
    this.getTowns();
    this.getDistricts();
    this.loadHouse();
  }

  updateHouse(): void {
    if (this.houseForm.invalid) {
      console.log('Form is invalid');
      console.log('Update button clicked');
      Object.keys(this.houseForm.controls).forEach((controlName) => {
        const control = this.houseForm.get(controlName);
        console.log(`Control: ${controlName}, Errors: ${JSON.stringify(control?.errors)}, Touched: ${control?.touched}`);
      });
  
      return;
    }
  
    const houseId = this.house.id;
    const categoryId = this.houseForm.value.category;
    const townId = this.houseForm.value.town;
    const districtId = this.houseForm.value.district;
  
    const formData: FormData = new FormData();
             formData.append('id', houseId.toString());
              formData.append('category', categoryId);
              formData.append('town', townId);
              formData.append('district', districtId);
              formData.append('title', this.houseForm.value.title);
              formData.append('price', this.houseForm.value.price);
              formData.append('description', this.houseForm.value.description);
              formData.append('age', this.houseForm.value.age);
              formData.append('floor', this.houseForm.value.floor);
              formData.append('bathroom', this.houseForm.value.bathroom);
              formData.append('balcony', this.houseForm.value.balcony);
              formData.append('room', this.houseForm.value.room);
              formData.append('heath', this.houseForm.value.heath);
              formData.append('complexName', this.houseForm.value.complexName);
              formData.append('deed', this.houseForm.value.deed);
              formData.append('furnish', this.houseForm.value.furnish);
              formData.append('dues', this.houseForm.value.dues);
              formData.append('exchange', this.houseForm.value.exchange);
              formData.append('credit', this.houseForm.value.credit);
              formData.append('gross', this.houseForm.value.gross);
              formData.append('square', this.houseForm.value.square);
              formData.append('hasNorthFrontage', this.houseForm.value.hasNorthFrontage);
              formData.append('hasSouthFrontage', this.houseForm.value.hasSouthFrontage);
              formData.append('hasWestFrontage', this.houseForm.value.hasWestFrontage);
              formData.append('hasEastFrontage', this.houseForm.value.hasEastFrontage);
              formData.append('nature', this.houseForm.value.nature);
              formData.append('sea', this.houseForm.value.sea);
              formData.append('lake', this.houseForm.value.lake);
              formData.append('hasWifi', this.houseForm.value.hasWifi);
              formData.append('hasSteelDoors', this.houseForm.value.hasSteelDoors);
              formData.append('hasElevator', this.houseForm.value.hasElevator);
              formData.append('hasChimney', this.houseForm.value.hasChimney);
              formData.append('swimmingPool', this.houseForm.value.swimmingPool);
              formData.append('generator', this.houseForm.value.generator);
              formData.append('parking', this.houseForm.value.parking);
              formData.append('satellite', this.houseForm.value.satellite);
              formData.append('tramvay', this.houseForm.value.tramvay);
              formData.append('metro', this.houseForm.value.metro);
              formData.append('busStop', this.houseForm.value.busStop);
              formData.append('van', this.houseForm.value.van);
              formData.append('gym', this.houseForm.value.gym);
              formData.append('pharmacy', this.houseForm.value.pharmacy);
              formData.append('hospital', this.houseForm.value.hospital);
              formData.append('shoppingCenter', this.houseForm.value.shoppingCenter);
  
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user && user.token) {
          const username = user.username; // Get the username from the user object
          const appUserId = user.id; // Get the user ID from the user object
          if (this.house.userName !== username) {
            this.toastr.error('Cannot edit someone elses ad.', 'Error');
            console.log('Cannot edit ads of other users');
            return;
          }
          formData.append('appUserId', appUserId.toString());
  
          this.adsService.updateHouse(formData, appUserId, categoryId, townId, districtId, houseId, username).subscribe({
            next: (response) => {
              console.log('Request succeeded:', response);
              console.log('Response id:', response.id);
              this.toastr.success('House ad updated successfully', 'Success');
              this.router.navigate(['ads', response.id.toString()]);
            },
            error: (error) => {
              console.log('Request failed:', error);
            },
          });
        } else {
          console.log('User token or ID is undefined');
        }
      },
      error: (error) => {
        console.log('Error retrieving current user:', error);
      }
    });
  }
  
  
   
  

  loadHouse() {
    const id = this.route.snapshot.paramMap.get('id');
    if (!id) {
      console.log('House ID is missing');
      return;
    }
  
    const houseId = parseInt(id, 10); // Parse id as a number

    this.adsService.getHouse(houseId).subscribe({
      next: (house) => {
        this.house = house;
        this.houseForm.patchValue({
          category: house.categoryId,
          town:house.townId,
          district:house.districtId,
          title:house.title,
          price:house.price,
          description:house.description,
          age: house.age,
          floor: house.floor,
          bathroom: house.bathroom,
          balcony: house.balcony,
          room: house.room,
          heath: house.heath,
          complexName: house.complexName,
          deed: house.deed,
          furnish: house.furnish,
          dues: house.dues,
          exchange: house.exchange,
          credit: house.credit,
          gross: house.gross,
          square: house.square,
          hasNorthFrontage: house.hasNorthFrontage,
          hasSouthFrontage: house.hasSouthFrontage,
          hasWestFrontage: house.hasWestFrontage,
          hasEastFrontage: house.hasEastFrontage,
          nature: house.nature,
          sea: house.sea,
          lake: house.lake,
          hasWifi: house.hasWifi,
          hasSteelDoors: house.hasSteelDoors,
          hasElevator: house.hasElevator,
          hasChimney: house.hasChimney,
          swimmingPool: house.swimmingPool,
          generator: house.generator,
          parking: house.parking,
          satellite: house.satellite,
          tramvay: house.tramvay,
          metro: house.metro,
          busStop: house.van,
          gym: house.gym,
          pharmacy: house.pharmacy,
          hospital: house.hospital,
          shoppingCenter: house.shoppingCenter

           // Assuming 'category' is the property name in the House model
          // Patch other form control values based on house object properties
        });
      },
      error: (error) => {
        console.log('Error occurred while loading the house:', error);
      }
    });
  }
  
  
  

  onChange(event: any, controlName: string): void {
    const value = event.target.checked ? true : false;
    this.houseForm.controls[controlName].setValue(value);
  }
  getCategories(): void {
    this.adsService.getHouseCategories().subscribe({
      next: (categories) => {
        this.categories = categories;
      },
      error: (error) => {
        console.error('Failed to retrieve categories:', error);
      },
    });
  }

  getTowns(): void {
    this.adsService.getHouseTowns().subscribe({
      next: (towns) => {
        this.towns = towns;
      },
      error: (error) => {
        console.error('Failed to retrieve towns:', error);
      },
    });
  }

  getDistricts(): void {
    this.adsService.getHouseDistricts().subscribe({
      next: (districts) => {
        this.districts = districts;
      },
      error: (error) => {
        console.error('Failed to retrieve districts:', error);
      },
    });
  }
  initializeForm(): void {
    this.houseForm = this.formBuilder.group({
      category: ['', Validators.required],
      town: ['', Validators.required],
      district: ['', Validators.required],
      title: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required],
      gross: [''],
      square: [''],
      age: [''],
      deed: [''],
      dues: [''],
      floor: [''],
      bathroom: [''],
      balcony: [''],
      room: [''],
      heath: [''],
      complexName: [''],
      furnish: false,
      credit: false,
      exchange: false,
      hasNorthFrontage: false,
      hasSouthFrontage: false,
      hasEastFrontage: false,
      hasWestFrontage: false,
      nature: false,
      sea: false,
      lake: false,
      hasWifi: false,
      hasSteelDoors: false,
      hasElevator: false,
      hasChimney: false,
      swimmingPool: false,
      generator: false,
      parking: false,
      satellite: false,
      metro: false,
      tramvay: false,
      van: false,
      busStop: false,
      hospital: false,
      gym: false,
      pharmacy: false,
      shoppingCenter: false,
    });
  }
}

import { Component, Input, OnInit } from '@angular/core';
import {
  FormBuilder,
  FormControl,
  FormGroup,
  Validators,
} from '@angular/forms';
import { FileUploader } from 'ng2-file-upload';
import { take } from 'rxjs';
import { Category } from 'src/app/_models/category';
import { District } from 'src/app/_models/district';
import { Town } from 'src/app/_models/town';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AdsService } from 'src/app/_services/ads.service';
import { environment } from 'src/environments/environment';

@Component({
  selector: 'app-ads-new',
  templateUrl: './ads-new.component.html',
  styleUrls: ['./ads-new.component.css'],
})
export class AdsNewComponent implements OnInit {
  @Input() user: User | undefined;
  houseForm!: FormGroup;
  uploader: FileUploader;
  categories: Category[] = [];
  towns: Town[] = [];
  districts: District[] = [];
  baseUrl = environment.apiUrl;
  hasBaseDropZoneOver = false;


  constructor(
    private adsService: AdsService,
    private formBuilder: FormBuilder,
    private accountService: AccountService
  ) {
    this.initializeForm();
    this.uploader = new FileUploader({
      url: 'ads/add',
      itemAlias: 'photo', 
      autoUpload: false, 
    });
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

  }
  initializeForm(): void {
    this.houseForm = this.formBuilder.group({
      category: ['', Validators.required],
      town: ['', Validators.required],
      district: ['', Validators.required],
      photo: new FormControl(null),
      title: ['', Validators.required],
      description: ['', Validators.required],
      price: ['', Validators.required],
      gross: [''],
      square: [''],
      age: [''],
      deedType: [''],
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

  // ...
  fileOverBase(e: any) {
    this.hasBaseDropZoneOver = e;
  }

  onFileChange(event: any): void {
    const file = event.target.files[0];
    this.uploader?.clearQueue();
    this.uploader?.addToQueue([file]);
  }

  onChange(event: any, controlName: string): void {
    const value = event.target.checked ? true : false;
    this.houseForm.controls[controlName].setValue(value);
  }

  // ...

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

  submitHouseAd(): void {
    console.log('submitHouseAd() method called');
    if (this.houseForm.invalid) {
      console.log('Form is invalid');
      console.log('Submit button clicked');
      Object.keys(this.houseForm.controls).forEach((controlName) => {
        const control = this.houseForm.get(controlName);
        console.log(`Control: ${controlName}, Errors: ${JSON.stringify(control?.errors)}, Touched: ${control?.touched}`);
      });
      
      return;
    }

    const categoryId = this.houseForm.value.category;
    const townId = this.houseForm.value.town;
    const districtId = this.houseForm.value.district;

    const formData: FormData = new FormData();
    formData.append('category', categoryId);
    formData.append('town', townId);
    formData.append('district', districtId);
    formData.append('title', this.houseForm.value.title);
    formData.append('description', this.houseForm.value.description);
    formData.append('age', this.houseForm.value.age);
    formData.append('floor', this.houseForm.value.floor);
    formData.append('bathroom', this.houseForm.value.bathroom);
    formData.append('balcony', this.houseForm.value.balcony);
    formData.append('room', this.houseForm.value.room);
    formData.append('heath', this.houseForm.value.heath);
    formData.append('complexName', this.houseForm.value.complexName);
    formData.append('deedType', this.houseForm.value.deedType);
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
    formData.append('van', this.houseForm.value.busStop);
    formData.append('gym', this.houseForm.value.gym);
    formData.append('pharmacy', this.houseForm.value.pharmacy);
    formData.append('shoppingCenter', this.houseForm.value.shoppingCenter);

    // uploaded photo to the formData
    let file: File | undefined;
    if (this.uploader && this.uploader.queue.length > 0) {
      file = this.uploader.queue[0]._file;
      formData.append('file', file, file.name);
    }

    // if currentUser is defined
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) {
          const currentUser = user;
          console.log('Current user:', currentUser);
  
    
          // the currentUser object
          if (currentUser.id) {
            formData.append('appUserId', currentUser.id.toString());
    
            // HTTP request
            if (file) {
              this.adsService.createHouseAd(formData, currentUser.id, categoryId, townId, districtId, file)
                .subscribe({
                  next: (response) => {
                    console.log('Request succeeded:', response);
                  },
                  error: (error) => {
                    console.log('Request failed:', error);
                  },
                });
            }
          } else {
            console.log('User ID is undefined');
          }
        } else {
          console.log('Current user is undefined');
        }
      },
      error: (error) => {
        console.log('Error retrieving current user:', error);
      },
    });
  }

}

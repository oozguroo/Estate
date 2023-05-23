import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Category } from 'src/app/_models/category';
import { District } from 'src/app/_models/district';
import { Town } from 'src/app/_models/town';
import { AdsService } from 'src/app/_services/ads.service';

@Component({
  selector: 'app-ads-new',
  templateUrl: './ads-new.component.html',
  styleUrls: ['./ads-new.component.css'],
})
export class AdsNewComponent implements OnInit {
  houseForm: FormGroup = new FormGroup({});
  categories: Category[] = [];
  towns: Town[] = [];
  districts: District[] = [];
  constructor(
    private adsService: AdsService,
    private formBuilder: FormBuilder
  ) {}

  ngOnInit(): void {
    this.initializeForm();
    this.getCategories();
    this.getTowns();
    this.getDistricts();
  }
  onChange(event: any, controlName: string): void {
    const value = event.target.checked ? true : null;
    this.houseForm.controls[controlName].setValue(value);
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
      deedType: [''],
      dues: [''],
      floor: [''],
      bathroom: [''],
      balcony: [''],
      room: [''],
      heathType: [''],
      complexName: [''],
      furnish: [null],
      credit: [null],
      exchange: [null],
  

      hasNorthFrontage: [''],
      hasSouthFrontage: [''],
      hasEastFrontage: [''],
      hasWestFrontage: [''],
      
      ramp: [''],
      elevator: [''],

      nature: [''],
      sea: [''],
      lake: [''],

      hasWifi: [''],
      hasSteelDoors: [''],
      hasElevator: [''],
      hasChimney: [''],

      swimmingPool: [''],
      generator: [''],
      parking: [''],
      satellite: [''],

      metro: [''],
      tramvay: [''],
      van: [''],
      busStop: [''],

      hospital: [''],
      gym: [''],
      pharmacy: [''],
      shoppingCenter: [''],

      // Add more form controls for other house properties
    });
  }

  submitHouseAd(): void {
    if (this.houseForm.invalid) {
      // Handle invalid form submission (e.g., show error messages)
      return;
    }

    const formData = new FormData();
    // Append form values to formData
    formData.append('title', this.houseForm.value.title);
    formData.append('description', this.houseForm.value.description);
    formData.append('price', this.houseForm.value.price);

    // Call the service method to create the house ad
    this.adsService.createHouseAd(formData).subscribe(
      () => {
        // Success: handle the successful ad creation
        console.log('House ad created successfully!');
        // Redirect to a success page or perform any other actions
      },
      (error) => {
        // Error: handle the error during ad creation
        console.error('Failed to create house ad:', error);
        // Display an error message or perform any other error handling
      }
    );
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
}

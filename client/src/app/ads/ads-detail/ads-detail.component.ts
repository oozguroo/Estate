import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Category } from 'src/app/_models/category';
import { District } from 'src/app/_models/district';
import { House } from 'src/app/_models/house';
import { Town } from 'src/app/_models/town';
import { AdsService } from 'src/app/_services/ads.service';




@Component({
  selector: 'app-ads-detail',
  templateUrl: './ads-detail.component.html',
  styleUrls: ['./ads-detail.component.css'],
})
export class AdsDetailComponent implements OnInit {
  constructor(private adsService: AdsService, private route: ActivatedRoute) {}
  house: House = {} as House;
  houseTowns: Town[] = [];
  houseDistricts: District[] = [];
  houseCategories: Category[] = [];


  

  ngOnInit(): void {
    this.loadHouse();
  }

  loadHouse() {
    const id = this.route.snapshot.paramMap.get('id');
    if (!id) return;
  
    const houseId = parseInt(id, 10); // Parse id as a number
  
    this.adsService.getHouse(houseId).subscribe({
      next: (house) => {
        this.house = house;
        // Access the HouseLocations for the single House
        this.houseTowns = house.towns;
        this.houseDistricts = house.districts;

        // Access the HouseCategories for the single House
        this.houseCategories = house.categories;

      },
    });
  }
  

  
}

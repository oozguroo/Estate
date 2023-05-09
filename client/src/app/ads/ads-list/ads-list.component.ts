import { Component, OnInit } from '@angular/core';
import { Category } from 'src/app/_models/category';
import { District } from 'src/app/_models/district';
import { House } from 'src/app/_models/house';
import { Town } from 'src/app/_models/town';
import { AdsService } from 'src/app/_services/ads.service';

@Component({
  selector: 'app-ads-list',
  templateUrl: './ads-list.component.html',
  styleUrls: ['./ads-list.component.css'],
})
export class AdsListComponent implements OnInit {
  houses: House[] = [];
  houseTowns: Town[]= [];
  houseDistricts: District[] = [];
  houseCategories: Category[]=[];


  constructor(private adsService: AdsService) {}

  ngOnInit(): void {
    this.loadHouses();
  }

  loadHouses() {
    this.adsService.getHouses().subscribe({
      next: (houses) => {
        this.houses = houses;
        // Access the HouseLocations for each House
        this.houseTowns = houses.flatMap((house) => house.towns);
        this.houseDistricts = houses.flatMap((house) => house.districts);
        // Access the HouseCategories for each House
        this.houseCategories = houses.flatMap((house) => house.categories);
      },
    });
  }
  
}

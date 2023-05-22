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



  constructor(private adsService: AdsService) {}

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
  
}

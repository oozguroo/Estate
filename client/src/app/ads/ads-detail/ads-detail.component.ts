import { Component, OnInit } from '@angular/core';
import { House } from 'src/app/_models/house';
import { AdsService } from 'src/app/_services/ads.service';

@Component({
  selector: 'app-ads-detail',
  templateUrl: './ads-detail.component.html',
  styleUrls: ['./ads-detail.component.css']
})
export class AdsDetailComponent implements OnInit {

  constructor(private adsService:AdsService) { }
  house: House = {} as House;

  ngOnInit(): void {
this.loadHouse(id:number);
  }

  loadHouse(id: number){
    this.adsService.getHouse().subscribe({
      next:(house) =>{
        this.house = house;
      }
    })
  }

}

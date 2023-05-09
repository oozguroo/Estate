import { Component, Input, OnInit } from '@angular/core';
import { House } from 'src/app/_models/house';

@Component({
  selector: 'app-ads-card',
  templateUrl: './ads-card.component.html',
  styleUrls: ['./ads-card.component.css']
})
export class AdsCardComponent implements OnInit {
@Input () house: House | undefined;
  constructor() { }

  ngOnInit(): void {
  }

}

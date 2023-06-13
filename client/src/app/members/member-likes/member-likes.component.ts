import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { HouseLike } from 'src/app/_models/houselike';
import { AccountService } from 'src/app/_services/account.service';
import { AdsService } from 'src/app/_services/ads.service';

@Component({
  selector: 'app-member-likes',
  templateUrl: './member-likes.component.html',
  styleUrls: ['./member-likes.component.css']
})
export class MemberLikesComponent implements OnInit {
  userId: number | null | undefined;
  likedAds: HouseLike[] =[];
  constructor(private accountService: AccountService,private adsService: AdsService,private router:Router) { }

  ngOnInit() {
    const userId = this.accountService.getCurrentUserId();
    if (userId) {
      this.adsService.getLikedAds(userId).subscribe(ads => {
        this.likedAds = ads;
      });
    }
  }

  onUnlike(houseId: number) {
    const userId = this.accountService.getCurrentUserId();
    if (userId) {
      this.adsService.removeLike(userId, houseId).subscribe(() => {
        // Remove the house ad from the likedAds array
        this.likedAds = this.likedAds.filter(ad => ad.houseId !== houseId);
      });
    }
  }

  

  
  redirectToAdDetail(Id: number) {
    // Redirect to ad detail page using the adId
    this.router.navigate(['/ads', Id]);
  }

}

import { Component, OnInit } from '@angular/core';
import { Route, Router } from '@angular/router';
import { HouseLike } from 'src/app/_models/houselike';
import { Pagination } from 'src/app/_models/pagination';
import { AccountService } from 'src/app/_services/account.service';
import { AdsService } from 'src/app/_services/ads.service';

@Component({
  selector: 'app-member-likes',
  templateUrl: './member-likes.component.html',
  styleUrls: ['./member-likes.component.css']
})
export class MemberLikesComponent implements OnInit {
  appUserId: number | null | undefined;
  houseLike: HouseLike[] |  undefined;
  pageNumber=1;
  pageSize=3;
  pagination: Pagination | undefined;
  constructor(private accountService: AccountService,private adsService: AdsService,private router:Router) { }

  ngOnInit() {
    const appUserId = this.accountService.getCurrentUserId();
    if (appUserId) {
      this.appUserId = appUserId;
      this.loadLikes();
    }
  }
  
  loadLikes() {
    console.log(this.houseLike);
    const appUserId = this.accountService.getCurrentUserId();
    if (appUserId) {
      this.adsService.getLikedAds(appUserId ?? 0, this.pageNumber, this.pageSize).subscribe({
        next: (response) => {
          this.houseLike = response.result; // <-- Change this line
          this.pagination = response.pagination; // <-- Add this line
          console.log("this.houseLike");
          console.log(response);
        },
        error: (error) => {
          console.log(error); // Handle error appropriately
        }
      });
    }
  }
  
  
  
  

  
  pageChanged(event: any) {
   if(this.pageNumber !== event.page){
    this.pageNumber = event.page;
    this.loadLikes();
   }
  }
  
  onUnlike(houseId: number) {
    const userId = this.accountService.getCurrentUserId();
    if (userId) {
      this.adsService.removeLike(userId, houseId).subscribe(() => {
        if (this.houseLike) { // Check if this.likedAds is defined
          // Remove the house ad from the likedAds array
          this.houseLike = this.houseLike.filter(ad => ad.houseId !== houseId);
        }
      });
    }
  }
  
  redirectToAdDetail(Id: number) {
    // Redirect to ad detail page using the adId
    this.router.navigate(['/ads', Id]);
  }

}

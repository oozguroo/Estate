import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { take } from 'rxjs';
import { House } from 'src/app/_models/house';
import { Member } from 'src/app/_models/member';
import { User } from 'src/app/_models/user';
import { AccountService } from 'src/app/_services/account.service';
import { AdsService } from 'src/app/_services/ads.service';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css'],
})
export class MemberDetailComponent implements OnInit {
  @Input() user: User | undefined;
  member: Member | undefined;
  houses: { houseId: number; photo: string; title: string; price: number }[] =
    [];

  constructor(
    private memberService: MembersService,
    private route: ActivatedRoute,
    private router: Router,
    private adsService: AdsService,
    private accountService: AccountService,
    private toastr: ToastrService
  ) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user) this.user = user;
      },
    });
  }

  ngOnInit(): void {
    this.loadMember();
  }

  loadMember() {
    const username = this.route.snapshot.paramMap.get('username');
    if (!username) return;
    this.memberService.getMember(username).subscribe({
      next: (member) => {
        this.member = member;
        this.houses = this.extractHouseData(member.houses);
      },
    });
  }

  deleteAd(houseId: number) {
    this.accountService.currentUser$.pipe(take(1)).subscribe({
      next: (user) => {
        if (user && user.token) {
          const username = user.username; // Get the username from the user object
          this.adsService.deleteHouseAd(houseId, username).subscribe({
            next: () => {
              this.toastr.success('House ad deleted successfully', 'Success');
              this.router.navigate(['members', username]);
              // Additional logic or page navigation
            },
            error: (error) => {
              console.error('Failed to delete house ad:', error);
              // Handle error and display appropriate message
            },
          });
        }
      },
      error: (error) => {
        console.error('Failed to get current user:', error);
        // Handle error and display appropriate message
      },
    });
  }
  

  extractHouseData(
    houses: House[]
  ): { houseId: number; photo: string; title: string; price: number }[] {
    return houses.map((house) => {
      const mainPhoto = house.photos.find((photo) => photo.isMain);
      return {
        houseId: house.id,
        photo: mainPhoto?.url ?? '',
        title: house.title,
        price: house.price,
      };
    });
  }
  getMainPhotoUrl(house: House): string {
    const mainPhoto = house.photos.find((photo) => photo.isMain);
    return mainPhoto?.url ?? '';
  }
  redirectToAdDetail(Id: number) {
    // Redirect to ad detail page using the adId
    this.router.navigate(['/ads', Id]);
  }
}

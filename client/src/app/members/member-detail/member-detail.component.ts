import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { House } from 'src/app/_models/house';
import { Member } from 'src/app/_models/member';
import { Photo } from 'src/app/_models/photo';
import { MembersService } from 'src/app/_services/members.service';

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  member: Member | undefined;
  houses: { houseId: number, photo: string, title: string, price: number }[] = [];

  constructor(private memberService: MembersService, private route: ActivatedRoute, private router:Router) { }

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
      }
    });
  }

  extractHouseData(houses: House[]): { houseId: number, photo: string, title: string, price: number }[] {
    return houses.map((house) => {
      const mainPhoto = house.photos.find((photo) => photo.isMain);
      return {
        houseId: house.id,
        photo: mainPhoto?.url ?? '',
        title: house.title,
        price: house.price
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
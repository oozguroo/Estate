import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import { ActivatedRoute } from '@angular/router';
import { TabDirective, TabsetComponent } from 'ngx-bootstrap/tabs';
import { House } from 'src/app/_models/house';
import { Member } from 'src/app/_models/member';
import { Message } from 'src/app/_models/message';
import { AccountService } from 'src/app/_services/account.service';
import { AdsService } from 'src/app/_services/ads.service';
import { MessageService } from 'src/app/_services/message.service';

@Component({
  selector: 'app-ads-detail',
  templateUrl: './ads-detail.component.html',
  styleUrls: ['./ads-detail.component.css'],
})
export class AdsDetailComponent implements OnInit {
  constructor(private adsService: AdsService, private route: ActivatedRoute,private accountService: AccountService,
     private messageService: MessageService,) {}
  @ViewChild('memberTabs', {static: true}) memberTabs?: TabsetComponent;
  @ViewChild('messageForm') messageForm?: NgForm
  @Input() username?: string;
  messageContent = '';
  house: House = {} as House;
  member: Member = { } as Member;
  messages: Message[] = [];
  activeTab?: TabDirective;
  /* user?:User; */


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
        this.loadMessages(); // Call loadMessages after house has been initialized
      },
    });
  }

  loadMessages() {
    if (this.house) {
      console.log(this.house.userName); 
      this.messageService.getMessageThread(this.house.userName).subscribe({
        next: (messages) => (this.messages = messages),
      });
    }
  }
  
  onTabActivated(data: TabDirective) {
    this.activeTab = data;
    if (this.activeTab.heading === 'Messages') {
      this.loadMessages();
    }
  }
  selectTab(heading: string) {
    if (this.memberTabs) {
      this.memberTabs.tabs.find(x => x.heading === heading)!.active = true
    }
  }
}

import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';
import { AccountService } from 'src/app/_services/account.service';

@Component({
  selector: 'app-member-login',
  templateUrl: './member-login.component.html',
  styleUrls: ['./member-login.component.css']
})
export class MemberLoginComponent implements OnInit {
  model: any = {};

  constructor(public accountService: AccountService,
              private router:Router,
              private toastr:ToastrService
              ) { }

  ngOnInit(): void {
  }

  login() {
    this.accountService.login(this.model).subscribe({
      next: response => {
        const user = response; // Access the response object
  
        console.log(user.token); // Output: the token
        console.log(user.username); // Output: the username
        console.log(user.id); // Output: the ID
  
        // Store the token in local storage
        localStorage.setItem('token', user.token);
  
        // Call the setCurrentUser method
        this.accountService.setCurrentUser(user);
  
        // Redirect the user to the ads page
        this.router.navigateByUrl('/ads');
      },
      error: error => {
        this.toastr.error(error.error);
        console.log(error);
      }
    });
  }
  
  

}

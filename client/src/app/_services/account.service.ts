import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { BehaviorSubject, map } from 'rxjs';
import { User } from '../_models/user';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root',
})
export class AccountService {


  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User | null>(null);
  currentUser$ = this.currentUserSource.asObservable();

  constructor(private http: HttpClient) {}

  setCurrentUser(user: User) {
    const { id, username } = user;
    const currentUser: User = {
      id,
      username,
      token: '', // Add the token property here
    };
    this.currentUserSource.next(currentUser);
  }
  
  


  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const { id, username } = response;
        if (id && username) {
          const currentUser: User = {
            id,
            username,
            token: '', // Add the token property here
          };
          localStorage.setItem('user', JSON.stringify(response));
          this.setCurrentUser(currentUser);
        }
      })
    );
  }
  
  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map((user) => {
        if (user) {
          localStorage.setItem('user', JSON.stringify(user));
          this.currentUserSource.next(user);
        }
        return user;
      })
    );
  }

 

  logout() {
    localStorage.removeItem('user');
    this.currentUserSource.next(null);
  }
}

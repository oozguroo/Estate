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
    this.currentUserSource.next(user);
  }
  
  getToken(): string {
    const token = localStorage.getItem('token');
    return token ? token : '';
  }
  
  getCurrentUserId(): number | null {
    const user = localStorage.getItem('user');
    return user ? JSON.parse(user).id : null;
  }
  
  
  login(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/login', model).pipe(
      map((response: User) => {
        const { id, username, token } = response;
        if (id && username) {
          const currentUser: User = {
            id,
            username,
            token,
          };
          localStorage.setItem('user', JSON.stringify(currentUser));
          localStorage.setItem('token', token); // Store the token in the local storage
          this.setCurrentUser(currentUser);
        }
        return response;
      })
    );
  }
  
  register(model: any) {
    return this.http.post<User>(this.baseUrl + 'account/register', model).pipe(
      map((user) => {
        if (user) {
          const { id, username, token } = user;
          const currentUser: User = {
            id,
            username,
            token,
          };
          localStorage.setItem('user', JSON.stringify(currentUser));
          localStorage.setItem('token', token);
          this.setCurrentUser(currentUser);
          return currentUser;
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

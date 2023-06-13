import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { House } from '../_models/house';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';
import { Town } from '../_models/town';
import { District } from '../_models/district';
import { AccountService } from './account.service';
import { HouseLike } from '../_models/houselike';

@Injectable({
  providedIn: 'root',
})
export class AdsService {
  baseUrl = environment.apiUrl;

  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}


  getHouses(): Observable<House[]> {
    return this.http.get<House[]>(
      `${this.baseUrl}ads?includeTowns=true&includeHouseCategories=true&includeHouseDistricts=true`
    );
  }

  getHouse(id: number) {
    return this.http.get<House>(
      `${this.baseUrl}ads/${id}?includeHouseCategories=true&includeTowns=true`
    );
  }

  removeLike(userId: number, houseId: number) {
    const url = `${this.baseUrl}likes/unlike/${userId}/${houseId}`;
    return this.http.delete(url);
  }
  
  
  addLike(appUserId: number, houseId: number): Observable<any> {
    const formData = new FormData();
    formData.append('appUserId', appUserId.toString());
    formData.append('houseId', houseId.toString());
    return this.http.post(this.baseUrl + 'likes/adlike', formData);
  }
  getLikedAds(userId: number): Observable<HouseLike[]> {
    return this.http.get<HouseLike[]>(`${this.baseUrl}likes/liked/${userId}`);
  }

  updateHouse(
    formData: FormData,
    appUserId: number,
    categoryId: number,
    townId: number,
    districtId: number,
    houseId: number,
    username: string
  ): Observable<any> {
    formData.append('houseId', houseId.toString());
    formData.append('categoryId', categoryId.toString());
    formData.append('townId', townId.toString());
    formData.append('districtId', districtId.toString());
    formData.append('username', username);

    const headers = new HttpHeaders({
      Authorization: `Bearer ${this.accountService.getToken()}`,
    });

    return this.http.put<any>(
      `${this.baseUrl}ads/update/${houseId}`,
      formData,
      { headers }
    );
  }

  createHouseAd(
    formData: FormData,
    appUserId: number,
    username: string,
    categoryId: number,
    townId: number,
    districtId: number,
    photo: File
  ): Observable<any> {
    formData.append('appUserId', appUserId.toString());
    formData.append('username', username);
    formData.append('categoryId', categoryId.toString());
    formData.append('townId', townId.toString());
    formData.append('districtId', districtId.toString());

    // Append the photo to the formData
    formData.append('file', photo, photo.name);

    const token = this.accountService.getToken(); // Get the token value from accountService
    const headers = new HttpHeaders({
      Authorization: `Bearer ${token}`,
    });

    return this.http.post<any>(`${this.baseUrl}ads/add`, formData, { headers });
  }

  deleteHouseAd(houseId: number, username: string) {
    const url = `${this.baseUrl}ads/delete/${houseId}`;
    const headers = new HttpHeaders({
      Authorization: `Bearer ${this.accountService.getToken()}`,
      'Content-Type': 'application/json',
    });

    const options = { headers: headers, body: { username: username } };

    return this.http.delete(url, options);
  }

  getHouseCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.baseUrl}ads/categories`);
  }

  getHouseTowns(): Observable<Town[]> {
    return this.http.get<Town[]>(`${this.baseUrl}ads/towns`);
  }

  getHouseDistricts(): Observable<District[]> {
    return this.http.get<District[]>(`${this.baseUrl}ads/districts`);
  }
}

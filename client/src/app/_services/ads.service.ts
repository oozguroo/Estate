import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { House } from '../_models/house';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';
import { Town } from '../_models/town';
import { District } from '../_models/district';
import { AccountService } from './account.service';

@Injectable({
  providedIn: 'root',
})
export class AdsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient,
    private accountService:AccountService) {}

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

  updateHouse(
    formData: FormData,
    appUserId: number,
    categoryId: number,
    townId: number,
    districtId: number,
    houseId: number
  ): Observable<any> {
    formData.append('appUserId', appUserId.toString());
    formData.append('categoryId', categoryId.toString());
    formData.append('townId', townId.toString());
    formData.append('districtId', districtId.toString());

    let headers = new HttpHeaders();
    headers = headers.append('Accept', 'application/json');
    return this.http.put<any>(
      `${this.baseUrl}ads/update/${houseId}`,
      formData,
      { headers }
    );
  }

  createHouseAd(
    formData: FormData,
    appUserId: number,
    categoryId: number,
    townId: number,
    districtId: number,
    photo: File
  ): Observable<any> {
    formData.append('appUserId', appUserId.toString());
    formData.append('categoryId', categoryId.toString());
    formData.append('townId', townId.toString());
    formData.append('districtId', districtId.toString());

    // Append the photo to the formData
    formData.append('file', photo, photo.name);

    let headers = new HttpHeaders();
    headers = headers.append('Accept', 'application/json');

    return this.http.post<any>(`${this.baseUrl}ads/add`, formData, { headers });
  }

  deleteHouseAd(houseId: number, username: string) {
    const url = `${this.baseUrl}ads/delete/${houseId}`;
    const headers = new HttpHeaders({
      Authorization: `Bearer ${this.accountService.getToken()}`,
      'Content-Type': 'application/json'
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

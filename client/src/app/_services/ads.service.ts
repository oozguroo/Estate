import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { House } from '../_models/house';
import { Observable } from 'rxjs';
import { Category } from '../_models/category';
import { Town } from '../_models/town';
import { District } from '../_models/district';

@Injectable({
  providedIn: 'root',
})
export class AdsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getHouses(): Observable<House[]> {
    return this.http.get<House[]>(`${this.baseUrl}ads?includeTowns=true&includeHouseCategories=true&includeHouseDistricts=true`);
  }
  
  

  getHouse(id: number) {
    return this.http.get<House>(`${this.baseUrl}ads/${id}?includeHouseCategories=true&includeTowns=true`);
  }

  
  createHouseAd(formData: FormData, appUserId: number, categoryId: number, townId: number, districtId: number, photo: File): Observable<any> {
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

import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { House } from '../_models/house';

@Injectable({
  providedIn: 'root',
})
export class AdsService {
  baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getHouses() {
    return this.http.get<House[]>(`${this.baseUrl}ads?includeTowns=true&includeHouseCategories=true&includeHouseDistricts=true`);
  }
  

  getHouse(id: number) {
    return this.http.get<House>(`${this.baseUrl}ads/${id}?includeHouseCategories=true&includeTowns=true`);
  }
  


}

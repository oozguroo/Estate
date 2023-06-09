import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { House } from '../_models/house';
import { Observable, map, of } from 'rxjs';
import { Category } from '../_models/category';
import { Town } from '../_models/town';
import { District } from '../_models/district';
import { AccountService } from './account.service';
import { HouseLike } from '../_models/houselike';
import { PaginatedResult } from '../_models/pagination';
import { HouseParams } from '../_models/houseParams';
import { getPaginatedResult, getPaginationHeaders } from './paginationHelper';

@Injectable({
  providedIn: 'root',
})
export class AdsService {
  baseUrl = environment.apiUrl;
  houseCache =new Map();
  constructor(
    private http: HttpClient,
    private accountService: AccountService
  ) {}

  getHouses(houseParams:HouseParams){
    const response = this.houseCache.get(Object.values(houseParams).join('-'));
    if(response) return of(response);
    let params = getPaginationHeaders(houseParams.pageNumber,houseParams.pageSize);

    if (houseParams.category) {
      params = params.append('category', houseParams.category);
    }
    if (houseParams.town) {
      params = params.append('town', houseParams.town);
    }
    if (houseParams.district) {
      params = params.append('district', houseParams.district);
    }
    if (houseParams.priceFrom) {
      params = params.append('priceFrom', houseParams.priceFrom.toString());
    }
  
    if (houseParams.priceTo) {
      params = params.append('priceTo', houseParams.priceTo.toString());
    }

    return getPaginatedResult<House[]>(this.baseUrl +'ads',params,this.http).pipe(
      map(response =>{
        this.houseCache.set(Object.values(houseParams).join('-'),response);
        return response;
      })
    )
  }

  getHouseCategories(): Observable<Category[]> {
    return this.http.get<Category[]>(`${this.baseUrl}ads/categories`);
  }
  

  getHouse(id: number) {
    const house = [...this.houseCache.values()]
   .reduce((arr, elem) => arr.concat(elem.result),[])
   .find((house:House) => house.id === id);
   if(house) return of(house);

    return this.http.get<House>(`${this.baseUrl}ads/${id}?includeHouseCategories=true&includeTowns=true`
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



getLikedAds(appUserId: number, pageNumber: number, pageSize: number): Observable<PaginatedResult<HouseLike[]>> {
  const params = {
    appUserId: appUserId.toString(),
    pageNumber: pageNumber.toString(),
    pageSize: pageSize.toString()
  };

  let paginatedResult: PaginatedResult<HouseLike[]> = new PaginatedResult<HouseLike[]>();

  return this.http.get<HouseLike[]>(`${this.baseUrl}likes`, { observe: 'response', params }).pipe(
    map(response => {
      if (response.body !== null) {
        paginatedResult.result = response.body;
      }
      if (response.headers.get('Pagination') !== null) {
        paginatedResult.pagination = JSON.parse(response.headers.get('Pagination') as string);
      }
      return paginatedResult;
    })
  );
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


  getHouseTowns(): Observable<Town[]> {
    return this.http.get<Town[]>(`${this.baseUrl}ads/towns`);
  }

  getHouseDistricts(): Observable<District[]> {
    return this.http.get<District[]>(`${this.baseUrl}ads/districts`);
  }
}

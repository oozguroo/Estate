import { Photo } from './photo';


export interface House {
  id: number;
  title: string;
  appUserId: number;
  userName: string
  description: string;
  price: number;
  photoUrl: string;
  age: number;
  floor: string;
  bathroom: string;
  balcony: string;
  room: string;
  heath: string;
  complexName: string;
  deed: string;
  furnish: boolean;
  dues: number;
  exchange?: boolean;
  credit?: boolean;
  gross?: number;
  square?: number;
  isActive: boolean;
  creationDate: string;
  photos: Photo[];
  categoryId: number;
  townId: number;
  districtId: number;
  categoryName: string
  townName: string
  districtName: string
  hasNorthFrontage?: boolean;
  hasSouthFrontage?: boolean;
  hasEastFrontage?: boolean;
  hasWestFrontage?: boolean;
  nature?: boolean;
  sea?: boolean;
  lake?: boolean;
  hasWifi?: boolean;
  hasSteelDoors?: boolean;
  hasElevator?: boolean;
  hasChimney?: boolean;
  swimmingPool?: boolean;
  generator?: boolean;
  parking?: boolean;
  satellite?: boolean;
  metro?: boolean;
  tramvay?: boolean;
  van?: boolean;
  busStop?: boolean;
  hospital?: boolean;
  gym?: boolean;
  pharmacy?: boolean;
  shoppingCenter?: boolean;
}

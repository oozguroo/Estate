import { Photo } from './photo';
import { District } from './district';
import { Town } from './town';

export interface House {
  id: number;
  title: string;
  appUserId: number;
  userName: string
  description: string;
  price: number;
  photoUrl: string;
  city: string;
  town: string;
  district: string;
  age: number;
  floor: string;
  bathroom: number;
  balcony: number;
  room: string;
  heathType: number;
  complexName: string;
  deedType: number;
  furnish: boolean;
  dues: number;
  exchange: boolean;
  credit?: boolean;
  gross: number;
  square: number;
  ramp?: boolean;
  elevator?: boolean;
  isActive: boolean;
  creationDate: string;
  expirationDate: string;
  photos: Photo[];
  towns: Town[];
  districts: District[];
  categories: [];
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

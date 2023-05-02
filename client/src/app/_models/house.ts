
export interface House {
    id: number
    title: string
    appUserId: number
    appUser: any
    description: string
    price: number
    age: number
    floor: string
    bathroom: number
    balcony: number
    room: string
    heathType: number
    complexName: string
    deedType: number
    furnish: boolean
    dues: number
    exchange: boolean
    credit: boolean
    gross: number
    square: number
    ramp: boolean
    elevator: boolean
    isActive: boolean
    creationDate: string
    expirationDate: string
 /*    photos: Photo[];
    houseLocations: HouseLocation[];
    houseCategories: HouseCategory[]; */
    hasNorthFrontage: boolean
    hasSouthFrontage: boolean
    hasEastFrontage: boolean
    hasWestFrontage: boolean
    nature: boolean
    sea: boolean
    lake: boolean
    hasWifi: boolean
    hasSteelDoors: boolean
    hasElevator: boolean
    hasChimney: boolean
    swimmingPool: boolean
    generator: boolean
    parking: boolean
    satellite: boolean
    metro: boolean
    tramvay: boolean
    van: boolean
    busStop: boolean
    hospital: boolean
    gym: boolean
    pharmacy: boolean
    shoppingCenter: boolean
}
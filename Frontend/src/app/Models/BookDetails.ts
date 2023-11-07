export interface BookDetails {
  id: string;
  campId: string;
  referenceNumber: string;
  price: number;
  persons: string;
  nights: number;
  checkIn: string;
  checkOut: string;
  address: string;
  state: string;
  country: string;
  zipCode: string;
  cellPhone: string;
}

export interface AddNewBook {
  campId: string;
  price: number;
  persons: number;
  nights: number;
  checkin: string;
  checkout: string;
  address: string;
  state: string;
  country: string;
  zipcode: string;
  cellphone: string;
}

export interface SearchBookingModel {
  refNum: string;
  phone: string;
  zipcode: string;
}

export interface FreeForBook {
  campId?: string;
  checkIn: string;
  checkOut: string;
}


export interface Camp {
  id: string;
  name: string;
  description: string;
  capacity: number;
  rating: number;
  price: number;
  imageUrl: string;
}

export interface AddNewCamp {
  name: string;
  description: string;
  capacity: number;
  price: number;
  imageUrl: string;
}

export interface GiveRating {
  campId: string;
  referenceNumber: string;
  cellPhone: string;
  star: number;
  comment: string;
}

import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppUrl } from './../../../Constants/URLs';
import {
  AddNewBook,
  SearchBookingModel,
  FreeForBook,
  BookDetails,
} from './../../Models/BookDetails';

@Injectable({
  providedIn: 'root',
})
export class BookService {
  Base_Url: string = new AppUrl().Base_Book_Url;

  constructor(private http: HttpClient) {}

  addNewBooking(book: AddNewBook) {
    return this.http.post(this.Base_Url, book);
  }

  searchBooking(data: SearchBookingModel) {
    return this.http.post<Observable<BookDetails>>(
      `${this.Base_Url}/search-booking`,
      data
    );
  }

  deleteBooking(Id: string) {
    return this.http.delete(`${this.Base_Url}/${Id}`);
  }

  searchForFree(data: FreeForBook) {
    return this.http.post(`${this.Base_Url}/is-free`, data);
  }

  getAllFreeCampsForBooking(data: FreeForBook) {
    return this.http.post(`${this.Base_Url}/search-free-camps`, data);
  }
}

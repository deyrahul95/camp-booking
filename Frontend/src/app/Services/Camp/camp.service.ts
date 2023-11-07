import { AddNewCamp, GiveRating } from './../../Models/Camp';
import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Camp } from 'src/app/Models/Camp';
import { AppUrl } from '../../../Constants/URLs';

@Injectable({
  providedIn: 'root',
})
export class CampService {
  Base_URL: string = new AppUrl().Base_Camp_Url;
  Rating_url: string = new AppUrl().Base_Rating_Url;

  constructor(private http: HttpClient) {}

  getAllCamps(): Observable<Camp[]> {
    return this.http.get<Camp[]>(this.Base_URL);
  }

  getCampDetails(id: string): Observable<Camp> {
    return this.http.get<Camp>(`${this.Base_URL}/${id}`);
  }

  updateCampDetails(id: string, data: Camp): Observable<Camp> {
    return this.http.put<Camp>(`${this.Base_URL}/${id}`, data);
  }

  deleteCampDetails(id: string) {
    return this.http.delete(`${this.Base_URL}/${id}`);
  }

  addNewCamp(data: AddNewCamp) {
    return this.http.post(this.Base_URL, data);
  }

  giveRating(data: GiveRating) {
    return this.http.post(this.Rating_url, data);
  }

  getComments(campId: string) {
    return this.http.get(`${this.Rating_url}/comments/${campId}`);
  }
}

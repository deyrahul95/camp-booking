import { FreeForBook } from './../../../../Models/BookDetails';
import { BookService } from './../../../../Services/Book/book.service';
import { Component, OnInit } from '@angular/core';
import { Camp } from 'src/app/Models/Camp';
import { Helper } from 'src/Constants/Helper';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css'],
})
export class HomeComponent implements OnInit {
  campList: Array<Camp> = [];
  CampListForSearch: Array<Camp> = [];
  page: number = 1;
  key: string = 'price';
  reverse: boolean = false;
  name: string = '';
  matches: number = 0;
  itemsPerPage: number = 3;

  constructor(private bookService: BookService) {}

  ngOnInit(): void {
    var data: FreeForBook = {
      checkIn: new Helper().Today(),
      checkOut: new Helper().Tomorrow(),
    };
    this.bookService.getAllFreeCampsForBooking(data).subscribe((res: any) => {
      this.campList = res;
      this.CampListForSearch = res;
    });
  }

  Search() {
    if (this.name == '') {
      this.campList = this.CampListForSearch;
      return;
    } else {
      this.campList = this.CampListForSearch.filter((res) => {
        return res.name
          .toLocaleLowerCase()
          .match(this.name.toLocaleLowerCase());
      });
      this.matches = this.campList.length;
    }
  }

  onClickSearch(value: string[]) {
    var data: FreeForBook = {
      checkIn: value[0],
      checkOut: value[1],
    };
    this.bookService.getAllFreeCampsForBooking(data).subscribe((res: any) => {
      this.campList = res;
      this.CampListForSearch = res;
      if (value[2] == 'Any') {
        this.name = '';
        this.matches = 0;
        this.campList = this.CampListForSearch;
        return;
      } else {
        this.name = 'Capacity ' + value[2];
        this.campList = this.CampListForSearch.filter((res) => {
          return res.capacity >= Number.parseInt(value[2]);
        });
        this.matches = this.campList.length;
      }
    });
  }

  onPageChange(event: any) {
    if (this.campList.length / event < this.page) {
      this.page = Math.round(this.campList.length / event);
    }
  }

  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }
}

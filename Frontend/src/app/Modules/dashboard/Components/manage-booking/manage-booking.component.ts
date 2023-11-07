import { CampService } from 'src/app/Services/Camp/camp.service';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component } from '@angular/core';
import {
  BookDetails,
  SearchBookingModel,
} from './../../../../Models/BookDetails';
import { Helper } from './../../../../../Constants/Helper';
import { GiveRating } from 'src/app/Models/Camp';
import { BookService } from './../../../../Services/Book/book.service';

@Component({
  selector: 'app-manage-booking',
  templateUrl: './manage-booking.component.html',
  styleUrls: ['./manage-booking.component.css'],
})
export class ManageBookingComponent {
  title: string = 'Manage Booking';
  isLoading: boolean = false;
  bookingDetails: BookDetails;

  constructor(
    private bookService: BookService,
    private campService: CampService,
    private snackBar: MatSnackBar,
    private router: Router
  ) {
    this.bookingDetails = {
      id: '',
      campId: '',
      referenceNumber: '',
      price: 0,
      persons: '',
      nights: 0,
      checkIn: '',
      checkOut: '',
      address: '',
      state: '',
      country: '',
      zipCode: '',
      cellPhone: '',
    };
  }

  today: string = new Helper().Today();
  campId$: string = '';
  refNum$: string = '';
  cellPhone$: string = '';
  star$: number = 0;
  coment$: string = '';

  searchForm = new FormGroup({
    refNum: new FormControl('', [
      Validators.required,
      Validators.pattern('[A-Z0-9]*'),
      Validators.minLength(8),
      Validators.maxLength(8),
    ]),
    zipcode: new FormControl('', [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(6),
      Validators.pattern('[0-9]*'),
    ]),
    cellphone: new FormControl('', [
      Validators.required,
      Validators.minLength(10),
      Validators.maxLength(10),
      Validators.pattern('[0-9]*'),
    ]),
  });

  submitSearchForm() {
    this.isLoading = true;
    var data: SearchBookingModel = {
      refNum: this.RefNum.value,
      phone: this.CellPhone.value,
      zipcode: this.Zipcode.value,
    };
    this.bookService.searchBooking(data).subscribe((res: any) => {
      // alert(res.referenceNumber);
      this.bookingDetails = res;
      this.isLoading = false;
      this.campId$ = this.bookingDetails.campId;
      this.cellPhone$ = this.bookingDetails.cellPhone;
      this.refNum$ = this.bookingDetails.referenceNumber;

      if (this.bookingDetails.id) {
        this.searchForm.reset();
        this.snackBar.open('Result Found.✅', 'Close', {
          duration: 4000,
        });
      }
    });

    if (this.isLoading == true) {
      this.isLoading = false;
      this.snackBar.open('Result Not Found.❌', 'Close', {
        duration: 4000,
      });
    }
  }

  DeleteBooking() {
    this.bookService
      .deleteBooking(this.bookingDetails.id)
      .subscribe((res: any) => {
        if (res == true) {
          this.router.navigate(['/dashboard']);
          this.snackBar.open('Deleted Successfully.✅', 'Close', {
            duration: 4000,
          });
        } else {
          this.snackBar.open('Not Deleted.❌', 'Close', {
            duration: 4000,
          });
        }
      });
  }

  get RefNum(): FormControl {
    return this.searchForm.get('refNum') as FormControl;
  }

  get Zipcode(): FormControl {
    return this.searchForm.get('zipcode') as FormControl;
  }

  get CellPhone(): FormControl {
    return this.searchForm.get('cellphone') as FormControl;
  }

  giveRating() {
    var data: GiveRating = {
      campId: this.campId$,
      referenceNumber: this.refNum$,
      cellPhone: this.cellPhone$,
      star: this.star$,
      comment: this.coment$,
    };
    console.log(data);
    this.campService.giveRating(data).subscribe((res) => {
      // alert(res);
      this.snackBar.open('Thank you for your Valuable Time.', 'Ok', {
        duration: 4000,
      });
    });
  }
}

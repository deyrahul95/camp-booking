import { MatSnackBar } from '@angular/material/snack-bar';
import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { catchError, count, of, throwError, timeout } from 'rxjs';
import { Camp } from './../../../../Models/Camp';
import { CampService } from 'src/app/Services/Camp/camp.service';
import { Helper } from './../../../../../Constants/Helper';
import { AddNewBook, FreeForBook } from './../../../../Models/BookDetails';
import { BookService } from './../../../../Services/Book/book.service';

@Component({
  selector: 'app-booking-screen',
  templateUrl: './booking-screen.component.html',
  styleUrls: ['./booking-screen.component.css'],
})
export class BookingScreenComponent implements OnInit {
  @Input() camp: Camp;
  constructor(
    private route: ActivatedRoute,
    private service: CampService,
    private bookService: BookService,
    private snackBar: MatSnackBar
  ) {
    this.camp = {
      id: this.id$,
      name: '',
      description: '',
      price: 0,
      rating: 0,
      capacity: 0,
      imageUrl: '',
    };
  }

  pageTitle: string = 'Booking Screen';
  isFreeForBook: boolean = true;
  comments: Array<string> = [];
  id$: string = '';
  referenceNumber: string = '';
  today = new Helper().Today();
  tomorrow = new Helper().Tomorrow();
  discountPrice: number = 0;
  weekday: number = 0;

  value: number = new Helper().GetDiffDays(this.today, this.tomorrow);

  bookingForm = new FormGroup({
    checkIn: new FormControl(this.today, Validators.required),
    checkOut: new FormControl(this.tomorrow, Validators.required),
    person: new FormControl('', [
      Validators.required,
      Validators.pattern('[0-9]*'),
    ]),
    address: new FormControl('', [Validators.required]),
    state: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-z. A-Z]*'),
    ]),
    country: new FormControl('', [
      Validators.required,
      Validators.pattern('[a-z A-Z]*'),
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

  ngOnInit(): void {
    this.route.params
      .pipe(
        catchError((err) => {
          console.warn(`Error! Something worng happend!`);
          return throwError(() => err);
        })
      )
      .subscribe((params) => {
        this.id$ = params['id'];
      });

    this.service
      .getCampDetails(this.id$)
      .pipe(
        catchError((err) => {
          console.warn(`Error! Something worng happend!`);
          return throwError(() => err);
        })
      )
      .subscribe({
        next: (res: Camp) => {
          this.camp = res;
        },
      });

    this.changeValue();
    this.service.getComments(this.id$).subscribe((res: any) => {
      this.comments = res;
    });
  }

  checkForWeekDays() {
    const dates = [];
    var date = new Date(this.CheckIn.value);
    var endDate = new Date(this.CheckOut.value);
    while (date < endDate) {
      dates.push(new Date(date));
      date.setDate(date.getDate() + 1);
    }
    var count = 0;
    for (let index = 0; index < dates.length; index++) {
      var currentDate = new Date(dates[index]);
      var day = currentDate.getDay();
      if (day === 0 || day === 5 || day === 6) {
        count++;
      }
    }
    this.weekday = count;
    console.log(this.weekday);
  }

  changeValue() {
    var temp = new Helper().GetDiffDays(
      this.CheckIn.value,
      this.CheckOut.value
    );
    if (temp <= 0) {
      alert('Checkout Date Must be greater than Checkin Date');
      return;
    }
    this.checkForWeekDays();
    this.value = temp;
    var data: FreeForBook = {
      campId: this.id$,
      checkIn: this.CheckIn.value,
      checkOut: this.CheckOut.value,
    };
    this.isFreeForBook = true;
    this.bookService.searchForFree(data).subscribe((res) => {
      if (res == false) {
        this.isFreeForBook = false;
        alert('This Days are Already Booked! Please book for another days');
      } else {
        this.snackBar.open('Days are free for booking.', 'Ok', {
          duration: 3000,
        });
      }
    });
  }

  onChangesValue() {
    this.bookingForm.get('checkIn')?.valueChanges.subscribe((val) => {
      this.changeValue();
    });
    this.bookingForm.get('checkOut')?.valueChanges.subscribe((val) => {
      this.changeValue();
    });
  }

  submitBookingForm() {
    var bookingDetails: AddNewBook = {
      campId: this.id$,
      price:
        this.value * this.Person.value * this.camp.price -
        this.discountPrice +
        this.weekday * 500,
      persons: this.Person.value,
      nights: this.value,
      checkin: this.CheckIn.value,
      checkout: this.CheckOut.value,
      address: this.Address.value,
      state: this.State.value,
      country: this.Country.value,
      zipcode: this.Zipcode.value,
      cellphone: this.CellPhone.value,
    };

    this.bookService
      .addNewBooking(bookingDetails)
      .pipe(
        timeout(5000),
        catchError((e) => {
          console.log(e);
          this.referenceNumber = e.error.text;
          return of(e);
        })
      )
      .subscribe((res: any) => {
        console.log(res);
        if (res.length > 10) {
          alert('Error on Booking');
        } else {
          console.log('Result : ' + res.error.text || res);
          this.referenceNumber = res.error.text || res;
          this.snackBar.open('Booking Completed.✅', 'Close', {
            duration: 4000,
          });
          this.bookingForm.reset();
        }
      });
  }

  confirmBooking() {
    if (this.value == 3) {
      this.discountPrice = 1000;
      alert('coupon DISC1000 applied! INR 1000 off of total amount.');
    }
    if (this.value == 5) {
      this.discountPrice = 1500;
      alert('coupon DISC1500  applied! INR 1500 off of total amount.');
    }
  }

  get CheckIn(): FormControl {
    return this.bookingForm.get('checkIn') as FormControl;
  }

  get CheckOut(): FormControl {
    return this.bookingForm.get('checkOut') as FormControl;
  }

  get Person(): FormControl {
    return this.bookingForm.get('person') as FormControl;
  }

  get Address(): FormControl {
    return this.bookingForm.get('address') as FormControl;
  }

  get State(): FormControl {
    return this.bookingForm.get('state') as FormControl;
  }

  get Country(): FormControl {
    return this.bookingForm.get('country') as FormControl;
  }

  get Zipcode(): FormControl {
    return this.bookingForm.get('zipcode') as FormControl;
  }

  get CellPhone(): FormControl {
    return this.bookingForm.get('cellphone') as FormControl;
  }
}

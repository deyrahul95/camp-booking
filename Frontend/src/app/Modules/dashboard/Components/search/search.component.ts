import { FormGroup, FormControl, Validators } from '@angular/forms';
import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { Helper } from './../../../../../Constants/Helper';

@Component({
  selector: 'app-search',
  templateUrl: './search.component.html',
  styleUrls: ['./search.component.css'],
})
export class SearchComponent implements OnInit {
  capacitys: Array<string> = ['Any', '1', '2', '4', '8'];
  today = new Helper().Today();
  tomorrow = new Helper().Tomorrow();

  searchForm = new FormGroup({
    checkIn: new FormControl(this.today, Validators.required),
    checkOut: new FormControl(this.tomorrow, Validators.required),
    capacity: new FormControl(this.capacitys[0]),
  });

  @Output() searchCamps = new EventEmitter<string[]>();

  search() {
    this.searchCamps.emit([
      this.CheckIn.value,
      this.CheckOut.value,
      this.Capacity.value,
    ]);
  }

  ngOnInit(): void {}

  get CheckIn(): FormControl {
    return this.searchForm.get('checkIn') as FormControl;
  }

  get CheckOut(): FormControl {
    return this.searchForm.get('checkOut') as FormControl;
  }

  get Capacity(): FormControl {
    return this.searchForm.get('capacity') as FormControl;
  }
}

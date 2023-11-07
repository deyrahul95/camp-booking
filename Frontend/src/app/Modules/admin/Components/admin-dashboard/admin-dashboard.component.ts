import { MatSnackBar } from '@angular/material/snack-bar';
import { Component, OnInit } from '@angular/core';
import { catchError, throwError } from 'rxjs';
import { Camp } from 'src/app/Models/Camp';
import { CampService } from 'src/app/Services/Camp/camp.service';

@Component({
  selector: 'app-admin-dashboard',
  templateUrl: './admin-dashboard.component.html',
  styleUrls: ['./admin-dashboard.component.css'],
})
export class AdminDashboardComponent implements OnInit {
  campList: Array<Camp> = [];
  pageTitle: string = 'Manage Camp';
  itemsPerPage: number = 3;
  matches: number = 0;
  name: string = '';

  selectedCampId: string = '';
  addDisable: boolean = false;

  camp: Camp = {
    id: this.selectedCampId,
    name: '',
    description: '',
    rating: 0,
    price: 0,
    capacity: 0,
    imageUrl: '',
  };

  constructor(private service: CampService, private snack: MatSnackBar) {}

  ngOnInit(): void {
    this.refreshList();
  }

  key: string = 'capacity';
  reverse: boolean = false;
  page: number = 1;

  onPageChange(event: any) {
    if (this.campList.length / event < this.page) {
      this.page = Math.round(this.campList.length / event);
    }
  }

  sort(key: string) {
    this.key = key;
    this.reverse = !this.reverse;
  }

  Search() {
    if (this.name == '') {
      this.ngOnInit();
    } else {
      this.campList = this.campList.filter((res) => {
        return res.name
          .toLocaleLowerCase()
          .match(this.name.toLocaleLowerCase());
      });
      this.matches = this.campList.length;
    }
  }

  refreshList() {
    this.service.getAllCamps().subscribe({
      next: (camps: Camp[]) => {
        this.campList = camps;
      },
    });
  }

  addCamp() {
    this.service.addNewCamp(this.camp).subscribe((res) => {
      this.refreshList();
      this.snack.open('Added Successfully.✅', 'Ok', { duration: 4000 });
    });
    this.camp = {
      id: '',
      name: '',
      description: '',
      price: 0,
      rating: 0,
      capacity: 0,
      imageUrl: '',
    };
  }

  editCamp() {
    this.service.updateCampDetails(this.selectedCampId, this.camp).subscribe({
      next: (res) => {
        this.camp = res;
        this.refreshList();
        this.snack.open('Updated Successfully.✅', 'Ok', { duration: 4000 });
      },
    });
    this.addDisable = false;
    this.camp = {
      id: '',
      name: '',
      description: '',
      price: 0,
      rating: 0,
      capacity: 0,
      imageUrl: '',
    };
  }

  fetchDetails(id: string) {
    this.selectedCampId = id;
    this.addDisable = true;
    this.service
      .getCampDetails(this.selectedCampId)
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
  }

  cancleBtn() {
    this.addDisable = false;
    this.camp = {
      id: '',
      name: '',
      description: '',
      rating: 0,
      price: 0,
      capacity: 0,
      imageUrl: '',
    };
  }

  removeCamp() {
    this.service
      .deleteCampDetails(this.selectedCampId)
      .subscribe((res: any) => {
        if (res == true) {
          this.ngOnInit();
          alert('Delete Successfully.');
        } else {
          alert('Not Deleted');
        }
      });
  }
}

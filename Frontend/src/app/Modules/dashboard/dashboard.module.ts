import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { MatButtonModule } from '@angular/material/button';
import { ReactiveFormsModule, FormsModule } from '@angular/forms';
import { Ng2SearchPipeModule } from 'ng2-search-filter';
import { Ng2OrderModule } from 'ng2-order-pipe';
import { NgxPaginationModule } from 'ngx-pagination';

import { DashboardRoutingModule } from './dashboard-routing.module';
import { DashboardComponent } from './dashboard.component';
import { HeaderComponent } from './Components/header/header.component';
import { SearchComponent } from './Components/search/search.component';
import { HomeComponent } from './Components/home/home.component';
import { BookingScreenComponent } from './Components/booking-screen/booking-screen.component';
import { ManageBookingComponent } from './Components/manage-booking/manage-booking.component';

@NgModule({
  declarations: [
    DashboardComponent,
    HeaderComponent,
    SearchComponent,
    HomeComponent,
    BookingScreenComponent,
    ManageBookingComponent,
  ],
  imports: [
    CommonModule,
    DashboardRoutingModule,
    MatButtonModule,
    ReactiveFormsModule,
    FormsModule,
    Ng2OrderModule,
    Ng2SearchPipeModule,
    NgxPaginationModule,
  ],
})
export class DashboardModule {}

import { ManageBookingComponent } from './Components/manage-booking/manage-booking.component';
import { BookingScreenComponent } from './Components/booking-screen/booking-screen.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { DashboardComponent } from './dashboard.component';

const routes: Routes = [
  { path: '', component: DashboardComponent },
  { path: 'booking-screen/:id', component: BookingScreenComponent },
  { path: 'manage-booking', component: ManageBookingComponent },
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class DashboardRoutingModule {}

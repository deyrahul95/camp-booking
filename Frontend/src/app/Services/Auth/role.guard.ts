import { AppUrl } from 'src/Constants/URLs';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';
import { AuthService } from './auth.service';
import { MatSnackBar } from '@angular/material/snack-bar';

@Injectable({
  providedIn: 'root',
})
export class RoleGuard implements CanActivate {
  Base_Url: string = new AppUrl().Base_Auth_Url;

  constructor(
    private service: AuthService,
    private snack: MatSnackBar,
    private route: Router
  ) {}

  canActivate() {
    var admin = localStorage.getItem('role');
    console.log(admin);
    if (admin) {
      this.route.navigate(['/admin/dashboard']);
      return true;
    }
    this.route.navigate(['/dashboard']);
    this.snack.open("You don't have Admin Access.❌", 'Ok', { duration: 4000 });
    return false;
  }
}

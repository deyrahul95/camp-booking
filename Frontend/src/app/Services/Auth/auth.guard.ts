import { MatSnackBar } from '@angular/material/snack-bar';
import { AuthService } from './auth.service';
import { Injectable } from '@angular/core';
import { CanActivate, Router } from '@angular/router';

@Injectable({
  providedIn: 'root',
})
export class AuthGuard implements CanActivate {
  constructor(
    private authService: AuthService,
    private route: Router,
    private snack: MatSnackBar
  ) {}

  canActivate() {
    if (this.authService.isLogin()) {
      return true;
    }
    this.snack.open('You are not Logged In!', 'Ok!', { duration: 4000 });
    this.route.navigate(['/admin/login']);
    return false;
  }
}

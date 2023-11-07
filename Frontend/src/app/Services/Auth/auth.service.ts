import { MatSnackBar } from '@angular/material/snack-bar';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AppUrl } from 'src/Constants/URLs';
import { Login } from './../../Models/Login';

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  Base_Url: string = new AppUrl().Base_Auth_Url;

  constructor(private http: HttpClient, private snackBar: MatSnackBar) {}

  isLogin() {
    return !!localStorage.getItem('user');
  }

  loginByEmail(user: Login) {
    return this.http.post(this.Base_Url, user, { responseType: 'text' });
  }

  getLoginUserDetails(email: string) {
    return this.http.post(`${this.Base_Url}/find-user/${email}`, '');
  }

  logout() {
    window.history.replaceState({}, '', `/dashboard`);
    localStorage.removeItem('user');
    this.snackBar.open('Logout Successfully ✅', 'Done', {
      duration: 5000,
    });
  }
}

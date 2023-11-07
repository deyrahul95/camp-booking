import { AuthService } from './../../../../Services/Auth/auth.service';
import { Login } from './../../../../Models/Login';
import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { catchError, throwError } from 'rxjs';
import { MatSnackBar } from '@angular/material/snack-bar';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent {
  loginForm = new FormGroup({
    email: new FormControl(null, [Validators.required, Validators.email]),
    password: new FormControl(null, [
      Validators.required,
      Validators.minLength(6),
      Validators.maxLength(15),
    ]),
  });

  constructor(
    private service: AuthService,
    private snackBar: MatSnackBar,
    private route: Router
  ) {}

  loginSubmited() {
    var user: Login = {
      email: this.Email.value,
      password: this.Password.value,
    };
    this.service
      .loginByEmail(user)
      .pipe(
        catchError((err) => {
          console.warn(`Error! Something worng happend!`);
          return throwError(() => err);
        })
      )
      .subscribe((res: string) => {
        if (res === 'Success') {
          localStorage.setItem('user', JSON.stringify(user.email));
          this.route.navigate(['/dashboard']);
          this.snackBar.open('Login Successfully ✅', 'Done', {
            duration: 5000,
          });
        } else {
          alert('Invalid Details!');
        }
      });
  }

  get Email(): FormControl {
    return this.loginForm.get('email') as FormControl;
  }

  get Password(): FormControl {
    return this.loginForm.get('password') as FormControl;
  }
}

import { Router } from '@angular/router';
import { AuthService } from './../../../../Services/Auth/auth.service';
import { Component, Input, OnInit } from '@angular/core';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'],
})
export class HeaderComponent implements OnInit {
  @Input() pageTitle: string;

  userEmail: string = '';
  isLogin = false;

  constructor(private service: AuthService, private route: Router) {
    this.pageTitle = '';
  }
  ngOnInit(): void {
    var result = localStorage.getItem('user');
    if (result !== null) {
      this.userEmail = JSON.parse(result);
      this.isLogin = true;
    }
  }

  clickLogout() {
    this.isLogin = false;
    this.service.logout();
    this.route.navigate(['/dashboard']);
  }
}

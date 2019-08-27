import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private alertify: AlertifyService, private router: Router) { }

  ngOnInit() {
  }

  logOut() {
    localStorage.removeItem('token');
    this.alertify.message('Wylogowano.');
    this.router.navigate(['/login']);
  }

}

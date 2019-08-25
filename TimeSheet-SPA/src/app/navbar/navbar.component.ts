import { Component, OnInit } from '@angular/core';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-navbar',
  templateUrl: './navbar.component.html',
  styleUrls: ['./navbar.component.css']
})
export class NavbarComponent implements OnInit {

  constructor(private alertify: AlertifyService) { }

  ngOnInit() {
  }

  logOut() {
    localStorage.removeItem('token');
    this.alertify.message('Wylogowano.');
  }

}

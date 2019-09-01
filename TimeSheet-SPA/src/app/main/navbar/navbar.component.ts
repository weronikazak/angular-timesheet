import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';

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

import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    // !! <- sprawdza i zwraca bool. jesli token jest pusty zwraca false, jesli ma wartosc, zwraca true
    return !!token;
  }
}

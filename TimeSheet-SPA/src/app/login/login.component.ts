import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  model: any = {};

  constructor(private authService: AuthService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      console.log('Zalogowano.');
    }, error => {
      console.log('Nie udało się zalogować.');
    });
  }

  loggedIn() {
    const token = localStorage.getItem('token');
    // !! <- sprawdza i zwraca bool. jesli token jest pusty zwraca false, jesli ma wartosc, zwraca true
    return !!token;
  }


}

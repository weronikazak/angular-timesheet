import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';

@Component({
  selector: 'app-login-or-register',
  templateUrl: './login-or-register.component.html',
  styleUrls: ['./login-or-register.component.css']
})
export class LoginOrRegisterComponent implements OnInit {

  model: any = {};
  registrationMode = false;

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

  toggleRegistrationMode() {
    this.registrationMode = true;
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      console.log('Rejestracja się powiodła');
      this.login();
    }, error => {
      console.log(error);
    });
  }

  cancel() {
    this.registrationMode = false;
  }

}

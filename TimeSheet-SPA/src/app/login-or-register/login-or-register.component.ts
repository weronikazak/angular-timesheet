import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-login-or-register',
  templateUrl: './login-or-register.component.html',
  styleUrls: ['./login-or-register.component.css']
})
export class LoginOrRegisterComponent implements OnInit {

  model: any = {};
  registrationMode = false;

  constructor(private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Zalogowano.');
    }, error => {
      this.alertify.error('Nie udało się zalogować.');
    });
  }

  toggleRegistrationMode() {
    this.registrationMode = true;
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      this.alertify.success('Rejestracja się powiodła');
      this.login();
    }, error => {
      this.alertify.error(error);
    });
  }

  cancel() {
    this.registrationMode = false;
  }

}

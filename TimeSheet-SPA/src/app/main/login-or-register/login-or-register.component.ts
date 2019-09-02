import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-login-or-register',
  templateUrl: './login-or-register.component.html',
  styleUrls: ['./login-or-register.component.css']
})
export class LoginOrRegisterComponent implements OnInit {
  bsValue = new Date();
  bsRangeValue: Date[];
  maxDate = new Date();
  model: any = {};
  registrationMode = false;

  constructor(private authService: AuthService, private alertify: AlertifyService,
    private router: Router) {
      this.maxDate.setDate(this.maxDate.getDate() + 7);
      this.bsRangeValue = [this.bsValue, this.maxDate];
     }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.model).subscribe(next => {
      this.alertify.success('Zalogowano.');
    }, error => {
      this.alertify.error('Nie udało się zalogować.');
    }, () => {
      this.router.navigate(['/dashboard']);
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
    }, () => {
      this.router.navigate(['/login']);
    });
  }

  cancel() {
    this.registrationMode = false;
  }

}

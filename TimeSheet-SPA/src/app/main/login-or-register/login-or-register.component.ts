import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';

@Component({
  selector: 'app-login-or-register',
  templateUrl: './login-or-register.component.html',
  styleUrls: ['./login-or-register.component.css']
})
export class LoginOrRegisterComponent implements OnInit {
  maxDate = new Date();
  model: any = {};
  registrationMode = false;
  registerForm: FormGroup;
  today = new Date();

  constructor(private authService: AuthService, private alertify: AlertifyService,
    private router: Router, private fb: FormBuilder) {
      this.maxDate.setDate(this.maxDate.getDate() + 7);
     }

  ngOnInit() {
    this.createRegisterForm();
  }


  createRegisterForm() {
    this.registerForm = this.fb.group({
      email: ['', Validators.required],
      name: ['', Validators.required],
      surname: ['', Validators.required],
      birthDate: [this.today, Validators.required],
      password: ['',
        [Validators.required, Validators.minLength(6), Validators.maxLength(15)]],
      confirmPassword: ['', Validators.required]
    }, {validator: this.passwordMatchValidator});
  }

  passwordMatchValidator(g: FormGroup) {
    return g.get('password').value === g.get('confirmPassword').value ? null : {'mismatch': true};
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
    // this.authService.register(this.model).subscribe(() => {
    //   this.alertify.success('Rejestracja się powiodła');
    //   this.login();
    // }, error => {
    //   this.alertify.error(error);
    // }, () => {
    //   this.router.navigate(['/login']);
    // });
    console.log(this.registerForm.value);
  }

  cancel() {
    this.registrationMode = false;
  }

}

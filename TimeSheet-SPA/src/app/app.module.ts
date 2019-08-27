import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavbarComponent } from './navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { DashboardComponent } from './dashboard/dashboard.component';
import { SidebarComponent } from './sidebar/sidebar.component';
import { MainDesktopComponent } from './main-desktop/main-desktop.component';
import { LoginOrRegisterComponent } from './login-or-register/login-or-register.component';
import { HomeComponent } from './home/home.component';
import { ErrorInceptorProvide } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { MainScreenComponent } from './main-screen/main-screen.component';
import { TimepickerModule, TimepickerConfig, TimepickerActions } from 'ngx-bootstrap/timepicker';

@NgModule({
   declarations: [
      AppComponent,
      NavbarComponent,
      DashboardComponent,
      SidebarComponent,
      MainDesktopComponent,
      LoginOrRegisterComponent,
      HomeComponent,
      MainScreenComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      TimepickerModule.forRoot()
   ],
   providers: [
      AuthService,
      ErrorInceptorProvide,
      AlertifyService
      ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

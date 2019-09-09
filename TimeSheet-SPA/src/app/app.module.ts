import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { NavbarComponent } from './main/navbar/navbar.component';
import { FormsModule } from '@angular/forms';
import { AuthService } from './_services/auth.service';
import { DashboardComponent } from './main/dashboard/dashboard.component';
import { SidebarComponent } from './main/sidebar/sidebar.component';
import { MainDesktopComponent } from './main/main-desktop/main-desktop.component';
import { LoginOrRegisterComponent } from './main/login-or-register/login-or-register.component';
import { HomeComponent } from './main/home/home.component';
import { ErrorInceptorProvide } from './_services/error.interceptor';
import { AlertifyService } from './_services/alertify.service';
import { MainScreenComponent } from './-dashboard/main-screen/main-screen.component';
import { TimepickerModule, TabsModule, BsDatepickerModule, TypeaheadModule } from 'ngx-bootstrap';
import { RouterModule } from '@angular/router';
import { appRoutes } from 'src/routes';
import { UserProfileComponent } from './profile/user-profile/user-profile.component';
import { PicktimeDashboardComponent } from './-dashboard/picktime-dashboard/picktime-dashboard.component';
// import { MdRadioModule } from '@angular/material';
import { UserListComponent } from './users/user-list/user-list.component';
import { UserDetailComponent } from './users/user-detail/user-detail.component';
import { UserService } from './_services/user.service';
import { UserDetailResolver } from './_resolvers/user-detail.resolver';
import { AuthGuard } from './_guard/auth.guard';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { ProfileResolver } from './_resolvers/profile.resolver';
import { JwtModule } from '@auth0/angular-jwt';
import { PreventUnsavedChangesGuard } from './_guard/prevent-unsaved-changes.guard';
// import { tokenKey } from '@angular/core/src/view';

export function tokenGetter() {
   return localStorage.getItem('token');
}

@NgModule({
   declarations: [
      AppComponent,
      NavbarComponent,
      DashboardComponent,
      SidebarComponent,
      MainDesktopComponent,
      LoginOrRegisterComponent,
      HomeComponent,
      MainScreenComponent,
      UserProfileComponent,
      PicktimeDashboardComponent,
      UserListComponent,
      UserDetailComponent
   ],
   imports: [
      BrowserModule,
      HttpClientModule,
      FormsModule,
      TimepickerModule.forRoot(),
      RouterModule.forRoot(appRoutes),
      TabsModule.forRoot(),
      BrowserAnimationsModule,
      BsDatepickerModule.forRoot(),
      TypeaheadModule.forRoot(),
      JwtModule.forRoot({
         config: {
            tokenGetter: tokenGetter,
            whitelistedDomains: ['localhost:5000'],
            blacklistedRoutes: ['localhost:5000/api/auth']
         }
      })
   ],
   providers: [
      AuthService,
      ErrorInceptorProvide,
      AlertifyService,
      UserService,
      AuthGuard,
      UserDetailResolver,
      ProfileResolver,
      PreventUnsavedChangesGuard
   ],
   bootstrap: [
      AppComponent
   ]
})
export class AppModule { }

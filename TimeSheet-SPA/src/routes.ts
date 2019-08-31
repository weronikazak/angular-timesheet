import { Routes } from '@angular/router';
import { HomeComponent } from './app/home/home.component';
import { DashboardComponent } from './app/dashboard/dashboard.component';
import { UserProfileComponent } from './app/user-profile/user-profile.component';
import { PicktimeDashboardComponent } from './app/dashboard/picktime-dashboard/picktime-dashboard.component';
import { LoginOrRegisterComponent } from './app/login-or-register/login-or-register.component';
import { AuthGuard } from './app/_guard/auth.guard';
import { UserListComponent } from './app/user-list/user-list.component';

export const appRoutes: Routes = [
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'desktop', component: DashboardComponent},
            { path: 'dashboard', component: PicktimeDashboardComponent},
            { path: 'profile', component: UserProfileComponent},
            { path: 'users', component: UserListComponent},
            // { path: '**', redirectTo: 'dashboard', pathMatch: 'full'}

        ]
    },
    { path: 'login', component: LoginOrRegisterComponent},
    { path: '**', redirectTo: 'login', pathMatch: 'full'}
];

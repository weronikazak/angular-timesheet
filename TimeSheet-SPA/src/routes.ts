import { Routes } from '@angular/router';
import { AuthGuard } from './app/_guard/auth.guard';
import { DashboardComponent } from './app/main/dashboard/dashboard.component';
import { PicktimeDashboardComponent } from './app/-dashboard/picktime-dashboard/picktime-dashboard.component';
import { UserProfileComponent } from './app/profile/user-profile/user-profile.component';
import { UserListComponent } from './app/users/user-list/user-list.component';
import { LoginOrRegisterComponent } from './app/main/login-or-register/login-or-register.component';
import { UserDetailComponent } from './app/users/user-detail/user-detail.component';
import { UserDetailResolver } from './app/_resolvers/user-detail.resolver';


export const appRoutes: Routes = [
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'desktop', component: DashboardComponent},
            { path: 'dashboard', component: PicktimeDashboardComponent},
            { path: 'profile', component: UserProfileComponent},
            { path: 'members', component: UserListComponent},
            { path: 'members/:id', component: UserDetailComponent, resolve: {user: UserDetailResolver}},
            { path: '', component: PicktimeDashboardComponent, pathMatch: 'full' }

        ]
    },
    { path: 'login', component: LoginOrRegisterComponent},
    { path: '', component: PicktimeDashboardComponent, pathMatch: 'full' }
];

import { Routes } from '@angular/router';
import { HomeComponent } from './app/home/home.component';
import { DashboardComponent } from './app/dashboard/dashboard.component';

export const appRoutes: Routes = [
    { path: 'home', component: HomeComponent},
    { path: 'dashboard', component: DashboardComponent},
    { path: '**', redirectTo: 'home', pathMatch: 'full'}
];

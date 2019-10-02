import { Routes } from '@angular/router';
import { AuthGuard } from './app/_guard/auth.guard';
import { DashboardComponent } from './app/main/dashboard/dashboard.component';
import { PicktimeDashboardComponent } from './app/-dashboard/picktime-dashboard/picktime-dashboard.component';
import { UserProfileComponent } from './app/profile/user-profile/user-profile.component';
import { UserListComponent } from './app/users/user-list/user-list.component';
import { LoginOrRegisterComponent } from './app/main/login-or-register/login-or-register.component';
import { UserDetailComponent } from './app/users/user-detail/user-detail.component';
import { UserDetailResolver } from './app/_resolvers/user-detail.resolver';
import { ProfileResolver } from './app/_resolvers/profile.resolver';
import { PreventUnsavedChangesGuard } from './app/_guard/prevent-unsaved-changes.guard';
import { ProjectListAllComponent } from './app/projects/project-list-all/project-list-all.component';
import { ProjectDetailResolver } from './app/_resolvers/project-detail.resolver';
import { AddProjectComponent } from './app/projects/add-project/add-project.component';
import { ProjectDetailComponent } from './app/profile/project-detail/project-detail.component';
import { CompanyListComponent } from './app/companies/company-list/company-list.component';
import { GroupCreateComponent } from './app/group/group-create/group-create.component';


export const appRoutes: Routes = [
    {
        path: '',
        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard],
        children: [
            { path: 'desktop', component: DashboardComponent},
            { path: 'dashboard', component: PicktimeDashboardComponent},
            { path: 'profile', component: UserProfileComponent,
             resolve: {user: ProfileResolver},
             canDeactivate: [PreventUnsavedChangesGuard]},
            { path: 'members', component: UserListComponent},
            { path: 'group/add', component: GroupCreateComponent},
            { path: 'projects/all', component: ProjectListAllComponent},
            { path: 'projects/add', component: AddProjectComponent},
            { path: 'companies', component: CompanyListComponent},
            // { path: 'projects/user', component: AddProjectComponent},
            { path: 'projects/:id', component: ProjectDetailComponent, resolve: {project: ProjectDetailResolver}},
            { path: 'members/:id', component: UserDetailComponent, resolve: {user: UserDetailResolver}},
            { path: '', component: PicktimeDashboardComponent, pathMatch: 'full' }

        ]
    },
    { path: 'login', component: LoginOrRegisterComponent},
    { path: '', component: PicktimeDashboardComponent, pathMatch: 'full' }
];

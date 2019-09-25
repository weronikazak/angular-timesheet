import { Injectable } from '@angular/core';
import { Resolve, Router, ActivatedRouteSnapshot } from '@angular/router';
import { AlertifyService } from '../_services/alertify.service';
import { Observable, of } from 'rxjs';
import { catchError } from 'rxjs/operators';
import { Project } from '../_models/project';
import { ProjectService } from '../_services/project.service';

@Injectable()
export class ProjectDetailResolver implements Resolve<Project> {
    constructor(private projectService: ProjectService,
        private router: Router, private alertify: AlertifyService) {}

    resolve(route: ActivatedRouteSnapshot): Observable<Project> {
        return this.projectService.getProject(route.params['id']).pipe(
            catchError(error => {
                this.alertify.error(error);
                this.router.navigate(['/projects/all']);
                return of(null);
            })
        );
    }
}

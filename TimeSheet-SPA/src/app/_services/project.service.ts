import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';
import { Project } from '../_models/project';

@Injectable({
  providedIn: 'root'
})
export class ProjectService {
  baseUrl = environment.apiUrl;

constructor(private http: HttpClient) { }

  getProject(id: number): Observable<Project> {
    return this.http.get<Project>(this.baseUrl + 'projects/' + id);
  }

  getProjects(): Observable<Project[]> {
    return this.http.get<Project[]>(this.baseUrl + 'projects');
  }
}

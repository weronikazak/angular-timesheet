import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/_models/project';
import { ProjectService } from 'src/app/_services/project.service';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { FormControl } from '@angular/forms';

@Component({
  selector: 'app-project-list-all',
  templateUrl: './project-list-all.component.html',
  styleUrls: ['./project-list-all.component.css']
})
export class ProjectListAllComponent implements OnInit {
  projects: Project[];
  project_list;
  single_project: string;
  lookForProject = new FormControl('');
  noResult = false;

  constructor(private projectService: ProjectService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadProjects();
  }

  loadProjects() {
    return this.projectService.getProjects().subscribe((projects: Project[]) => {
      this.projects = projects;
      this.project_list = projects.map(m => m.projectName + ', ' + m.company.companyName);
    }, error => this.alertify.error(error));
  }

  typeaheadNoResults(event: boolean): void {
    this.noResult = event;
  }

}

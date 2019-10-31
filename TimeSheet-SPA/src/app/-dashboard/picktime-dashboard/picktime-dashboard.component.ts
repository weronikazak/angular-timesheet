import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { ProjectService } from 'src/app/_services/project.service';
import { Project } from 'src/app/_models/project';

@Component( {
  selector: 'app-picktime-dashboard',
  templateUrl: './picktime-dashboard.component.html',
  styleUrls: ['./picktime-dashboard.component.css']
})

export class PicktimeDashboardComponent implements OnInit {
  projects: Project[];

  @Input() mytime: Date = new Date();
  starttime: Date = new Date();
  endtime: Date = new Date();
  name: string;
  czas_pracy: number;

  constructor(private authService: AuthService, private projectService: ProjectService) { }

  ngOnInit() {
    this.getName();
    this.loadProjects();
  }

  update(timeVal: Date) {
    const time = new Date();
    const dateTime = new Date();
    time.setHours(dateTime.getHours());
    time.setMinutes(dateTime.getMinutes());

    timeVal = time;
  }

  getName() {
    this.name = this.authService.decodedToken.family_name;
  }

  loadProjects() {
    this.projectService.getProjects().subscribe((projectList: Project[]) => {
      this.projects = projectList;
    });
  }
}

import { Component, OnInit } from '@angular/core';
import { Project } from 'src/app/_models/project';
import { HttpClient } from '@angular/common/http';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { ProjectService } from 'src/app/_services/project.service';
import { ActivatedRoute } from '@angular/router';

@Component({
  selector: 'app-project-detail',
  templateUrl: './project-detail.component.html',
  styleUrls: ['./project-detail.component.css']
})
export class ProjectDetailComponent implements OnInit {
  project: Project;
  pictureUrl = '../../assets/project_img.png';

  constructor(private route: ActivatedRoute, private alertify: AlertifyService, private projectservice: ProjectService) { }

  ngOnInit() {
    this.loadProject();
  }

  loadProject() {
    return this.projectservice.getProject(this.route.snapshot.params['id']).subscribe((project: Project) => {
      this.project = project;
      console.log(project);
    }, error => this.alertify.error(error));
  }
}

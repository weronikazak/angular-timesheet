import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';
import { ProjectService } from 'src/app/_services/project.service';

@Component( {
  selector: 'app-picktime-dashboard',
  templateUrl: './picktime-dashboard.component.html',
  styleUrls: ['./picktime-dashboard.component.css']
})

export class PicktimeDashboardComponent implements OnInit {
  @Input() mytime: Date = new Date();
  starttime: Date = new Date();
  endtime: Date = new Date();
  name: string;
  czas_pracy: Date;

  constructor(private authService: AuthService, private projectService: ProjectService) { }

  ngOnInit() {
    this.getName();
  }

  substract_time() {
    this.czas_pracy.setHours(this.endtime.getHours() - this.starttime.getHours());
    this.czas_pracy.setMinutes(this.endtime.getMinutes() - this.starttime.getMinutes());
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
}

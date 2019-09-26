import { Component, OnInit, Input } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

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

  constructor(private authService: AuthService) { }

  ngOnInit() {
    this.getName();
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

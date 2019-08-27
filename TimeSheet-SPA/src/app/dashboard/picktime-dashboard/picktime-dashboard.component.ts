import { Component, OnInit } from '@angular/core';

@Component( {
  selector: 'app-picktime-dashboard',
  templateUrl: './picktime-dashboard.component.html',
  styleUrls: ['./picktime-dashboard.component.css']
})

export class PicktimeDashboardComponent implements OnInit {
  mytime: Date | undefined = new Date();
  isValid: boolean;

  constructor() { }

  ngOnInit() {
  }

  update() {
    const time = new Date();
    const dateTime = new Date();
    time.setHours(dateTime.getHours());
    time.setMinutes(dateTime.getMinutes());

    this.mytime = time;
  }

  clear() {
    this.mytime = void 0;
  }
}

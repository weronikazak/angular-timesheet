import { Component, OnInit, Input } from '@angular/core';

@Component( {
  selector: 'app-picktime-dashboard',
  templateUrl: './picktime-dashboard.component.html',
  styleUrls: ['./picktime-dashboard.component.css']
})

export class PicktimeDashboardComponent implements OnInit {
  @Input() mytime: Date = new Date();
  starttime: Date = new Date();
  endtime: Date = new Date();

  constructor() { }

  ngOnInit() {
  }

  update(timeVal: Date) {
    const time = new Date();
    const dateTime = new Date();
    time.setHours(dateTime.getHours());
    time.setMinutes(dateTime.getMinutes());

    timeVal = time;
  }
}

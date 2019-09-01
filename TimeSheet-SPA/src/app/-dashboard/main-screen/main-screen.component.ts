import { Component, OnInit } from '@angular/core';

@Component({
  selector: 'app-main-screen',
  templateUrl: './main-screen.component.html',
  styleUrls: ['./main-screen.component.css']
})
export class MainScreenComponent implements OnInit {
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

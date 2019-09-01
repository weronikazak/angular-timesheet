import { Component, OnInit } from '@angular/core';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-main-desktop',
  templateUrl: './main-desktop.component.html',
  styleUrls: ['./main-desktop.component.css']
})
export class MainDesktopComponent implements OnInit {

  constructor(public authService: AuthService) { }

  ngOnInit() {
  }

}

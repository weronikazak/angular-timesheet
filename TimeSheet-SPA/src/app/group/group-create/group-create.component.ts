import { Component, OnInit } from '@angular/core';
import { User } from 'src/app/_models/user';
import { UserService } from 'src/app/_services/user.service';

@Component({
  selector: 'app-group-create',
  templateUrl: './group-create.component.html',
  styleUrls: ['./group-create.component.css']
})
export class GroupCreateComponent implements OnInit {
  selected: User;
  users: User[];
  user_names: string[];

  constructor(private userService: UserService) { }

  ngOnInit() {
  }

  loadUsers() {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
      this.user_names = users.map(u => u.name + ' ' + u.surname);
    });
  }

}

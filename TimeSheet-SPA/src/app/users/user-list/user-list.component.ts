import { Component, OnInit } from '@angular/core';
import { UserService } from 'src/app/_services/user.service';
import { User } from 'src/app/_models/user';
import { AlertifyService } from 'src/app/_services/alertify.service';
import { AuthService } from 'src/app/_services/auth.service';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html',
  styleUrls: ['./user-list.component.css']
})
export class UserListComponent implements OnInit {
  users: User[];
  hovering = false;
  selected: string;
  users_names: string[];
  maleUrl = '../../assets/male_img.png';
  femaleUrl = '../../assets/female_img.png';

  constructor(private userService: UserService, private authService: AuthService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadUsers();
  }

  loadUsers() {
    this.userService.getUsers().subscribe((users: User[]) => {
      this.users = users;
      this.users_names = users.map(u => u.name + ' ' + u.surname);
    }, error => {
      this.alertify.error(error);
    });
  }

  deleteUser(id: number) {
    this.userService.deleteUser(id).subscribe(() => {
      this.alertify.success('Pomyślnie usunięto użytkownika');
    });
  }

}

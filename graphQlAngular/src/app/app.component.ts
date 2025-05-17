import { Component, inject } from '@angular/core';
import { UserService } from './core/user.service';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  imports: [CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  private userService = inject(UserService);
  users: any[] = [];
  title = 'graphQlAngular';
  constructor() {
    this.userService.getUsers().subscribe((data) => (this.users = data));
  }

  addUser() {
    this.userService.createUser('New User', 'newuser@example.com').subscribe((user) => {
      const newUsers = [...this.users];
      newUsers.push(user);
      this.users = newUsers;
    });
  }
}

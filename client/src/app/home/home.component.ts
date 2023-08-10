import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { AccountService } from '../_services/account.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent {
  registerMode = false;
  users: any;

  constructor(private http: HttpClient, private accountService: AccountService) {}

  ngOnInit(): void {
    //this.getUsers();
  }

  registerToggle() {
    this.registerMode = !this.registerMode
  }

  getContacts() {
    this.http.get('https://localhost:7036/api/users').subscribe({
      next: response => this.users = response,
      error: error => console.log(error),
      complete: () => console.log('Requst has completed')
    })
  }

  cancelRegisterMode(event: boolean) {
    this.registerMode = event;
  }
}

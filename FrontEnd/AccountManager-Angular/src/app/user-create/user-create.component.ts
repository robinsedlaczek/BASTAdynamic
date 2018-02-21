import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { UserService } from '../user.service';
import { User, Address } from '../user';

@Component({
  selector: 'app-user-create',
  templateUrl: './user-create.component.html',
  styleUrls: ['./user-create.component.css']
})
export class UserCreateComponent implements OnInit {

  public user: User;

  constructor(
    private readonly userService: UserService,
    private location: Location
  ) { }

  ngOnInit() {
    this.user = new User();
    this.user.address = new Address();
  }

  public goBack(): void {
    this.location.back();
  }

  public createUser(user: User) {
    this.userService.createUser(user);
    this.location.back();
  }

}

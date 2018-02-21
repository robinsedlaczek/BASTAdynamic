import { Component, OnInit } from '@angular/core';
import { Location } from '@angular/common';
import { UserService } from '../user.service';
import { ActivatedRoute } from '@angular/router';
import { User } from '../user';

@Component({
  selector: 'app-user-detail',
  templateUrl: './user-detail.component.html',
  styleUrls: ['./user-detail.component.css']
})
export class UserDetailComponent implements OnInit {

  public user: User;

  constructor(
    private readonly userService: UserService,
    private readonly route: ActivatedRoute,
    private location: Location
  ) { }

  ngOnInit() {
    this.fetchUser();
  }

  public goBack(): void {
    this.location.back();
  }

  public saveUser(user: User) {
    this.userService.saveUser(user);
    console.log('User saved successfully');
  }

  private fetchUser(): void {
    const id = +this.route.snapshot.paramMap.get('id');
    this.userService.getUser(id)
      .subscribe(user => this.user = user);
  }

}

import { Component, OnInit } from '@angular/core';
import { User } from '../user';
import { USERS } from '../user-mock';
import { UserService } from '../user.service';
import { ActivatedRouteSnapshot, RouterStateSnapshot, Router } from '@angular/router';
import { Observable } from 'rxjs/Observable';
import { AuthService } from '../auth.service';


@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {

  constructor(
    private readonly authService: AuthService,
    private readonly router: Router,
    private readonly userService: UserService
  ) { }

  public users: User[];

  ngOnInit() {
    this.fetchUsers();
  }

  canActivate(
    next: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean> | Promise<boolean> | boolean {
    if (!this.authService.isAuthenticated) {
      this.router.navigate(['/login']);
      return false;
    }
    return true;
  }

  public deleteUser(user: User): void {
    this.userService.deleteUser(user);
  }

  private fetchUsers(): void {
    this.userService.getUsers().subscribe(users => this.users = users);
  }

}

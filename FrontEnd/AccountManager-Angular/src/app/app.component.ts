import { Component } from '@angular/core';
import { AuthService } from './auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {

  constructor(
    private readonly router: Router,
    private readonly authService: AuthService
  ) {}

  public logout(): void {
    this.authService.purge();
    this.router.navigate(['login']);
  }
}

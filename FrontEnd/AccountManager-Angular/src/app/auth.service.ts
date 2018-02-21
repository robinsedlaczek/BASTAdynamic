import { Injectable } from '@angular/core';

@Injectable()
export class AuthService {

  public isAuthenticated = false;

  constructor() { }

  public authenticate(username: string, password: string): void {
    this.isAuthenticated = username === 'cneubauer' && password === 'dev';
  }

  public purge(): void {
    this.isAuthenticated = false;
  }

}

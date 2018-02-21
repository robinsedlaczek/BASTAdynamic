import { Injectable } from '@angular/core';
import { User } from './user';
import { USERS } from './user-mock';

import { Observable } from 'rxjs/Observable';
import { of } from 'rxjs/observable/of';


@Injectable()
export class UserService {

  constructor() { }

  public getUsers(): Observable<User[]> {
    return of(USERS.sort(x => x.id));
  }

  public getUser(id: number): Observable<User> {
    return of(USERS.find(x => x.id === id));
  }

  public saveUser(user: User): void {
    return;
  }

  public createUser(user: User): void {
    USERS.push(user);

    const userId = USERS.findIndex(x => x === user);
    user.id = userId + 1;
  }

  public deleteUser(user: User) {
    const userIdx = USERS.findIndex(x => x === user);
    USERS.splice(userIdx, 1);
  }

}

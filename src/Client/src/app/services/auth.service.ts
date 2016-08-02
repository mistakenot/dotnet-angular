import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

export interface IAuthService {
    loggedIn: Observable<boolean>
    login(email: string, password: string): Observable<IAuthModel>
}

export interface IAuthModel {
    email: string
    token: string
    expires: Date
}

@Injectable()
export class AuthService implements IAuthService {
  loggedIn: Observable<boolean>

  constructor(
      private http: Http
  ) {}

  login(email: string, password: string) {

  }
}

@Injectable()
export class MockAuthService implements IAuthService {
    loggedIn: Observable<boolean>
    email: string
    password: string

    private _loggedIn: BehaviorSubject<boolean>

    constructor() {
        this._loggedIn = new BehaviorSubject(false);

        this.email = "bob@email.com"
        this.password = "123456"
        this.loggedIn = this._loggedIn;
    }

    login(email: string, password: string): Observable<IAuthModel> {
        console.log("Logging in: " + email + " " + password)
        if (email == this.email && password == this.password) {
            this._loggedIn.next(true);
            
        }
        else {
            return Observable.throw("Details not found.")
        }
    }
}

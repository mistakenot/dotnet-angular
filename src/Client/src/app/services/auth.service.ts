import { Injectable } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';

export interface IAuthService {
    loggedIn: Observable<boolean>
    login(email: string, password: string)
    logout()
}

export interface IAuthModel {
    email: string
    token: string
    expires: Date
}

@Injectable()
export class AuthService implements IAuthService {
  loggedIn: Observable<boolean>

  private rootUrl: string;

  constructor(
      private http: Http
  ) {
      this.rootUrl = "http://localhost:1234/";
  }

  login(email: string, password: string) {
      return this.http.post(this.rootUrl, {
          Email: email,
          Password: password,
          RememberMe: false
      })
      .map(response =>  {
          return {
              email: email,
              token: "2",
              expires: new Date()
          }
      });
  }

  logout() {

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

    login(email: string, password: string) {
        console.log("Logging in: " + email + " " + password)
        if (email == this.email && password == this.password) {
            this._loggedIn.next(true);
        }
    }

    logout() {
        this._loggedIn.subscribe(loggedIn => {
            if (loggedIn) {
                this._loggedIn.next(false);
            }
        })
    }
}

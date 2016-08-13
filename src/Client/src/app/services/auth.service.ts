import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { LogService, ILogService } from './log.service';

export interface IAuthService {
    loggedIn: Observable<boolean>
    login(email: string, password: string): Promise<void>
    logout(): Promise<void>
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
  private authModel: IAuthModel;

  constructor(
      @Inject(LogService) private log: ILogService,
      private http: Http
  ) {
      this.rootUrl = "http://localhost:1234/";
      this.authModel = null;
  }

  login(email: string, password: string) {
      return this.http.post(this.rootUrl, {
          Email: email,
          Password: password,
          RememberMe: false
      })
      .map(response =>  {
          this.authModel = {
              email: email,
              token: "2",
              expires: new Date()
          };
          this.log.info("Logged in as " + email + ".");
      })
      .toPromise();
  }

  logout() {
      return Promise.resolve();
  }
}

@Injectable()
export class MockAuthService implements IAuthService {
    loggedIn: Observable<boolean>
    email: string
    password: string

    private _loggedIn: BehaviorSubject<boolean>

    constructor(
        @Inject(LogService) private log: ILogService
    ) {
        this._loggedIn = new BehaviorSubject(false);

        this.email = "bob@email.com"
        this.password = "123456"
        this.loggedIn = this._loggedIn;
    }

    login(email: string, password: string) {
        if (email == this.email && password == this.password) {
            this.log.info("Successfully logged in.");
            this._loggedIn.next(true);
            return Promise.resolve();
        }
        else {
            this.log.error("Error whilst logging in.");
            return Promise.reject(new Error("Email not found."));
        }
    }

    logout() {
        this._loggedIn.subscribe(loggedIn => {
            if (loggedIn) {
                this.log.info("Successfully logged out.");
                this._loggedIn.next(false);
            }
        })
        return Promise.resolve();
    }
}

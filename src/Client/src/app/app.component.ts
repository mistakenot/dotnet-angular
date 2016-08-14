import { Component } from '@angular/core';
import { NavBarComponent } from './components/nav/nav-bar'
import { AuthService, MockAuthService } from './services/auth.service';
import { LogService, ILogService, ConsoleLogService } from './services/log.service';
import { NgRedux } from 'ng2-redux';
import { IAppState } from './models'
import { rootReducer } from './store';

@Component({
  moduleId: module.id,
  selector: 'app-root',
  templateUrl: 'app.component.html',
  styleUrls: ['app.component.css'],
  directives: [NavBarComponent],
  providers: [
      { provide: AuthService, useClass: MockAuthService },
      { provide: LogService, useClass: ConsoleLogService }
  ]
})
export class AppComponent { 
  title = 'app works!';

  constructor(
      private ngRedux: NgRedux<IAppState>
  ) {
      this.ngRedux.configureStore(rootReducer, {})
  }
}

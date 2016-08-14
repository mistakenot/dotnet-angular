import { bootstrap } from '@angular/platform-browser-dynamic';
import { enableProdMode } from '@angular/core';
import { AppComponent, environment } from './app/';
import { HTTP_PROVIDERS } from '@angular/http';
import { NgRedux } from 'ng2-redux';

if (environment.production) {
  enableProdMode();
}
 
bootstrap(
    AppComponent,
    [HTTP_PROVIDERS,
     NgRedux]);

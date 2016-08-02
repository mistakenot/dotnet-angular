/* tslint:disable:no-unused-variable */

import { By }           from '@angular/platform-browser';
import { DebugElement } from '@angular/core';

import {
  beforeEach, beforeEachProviders,
  describe, xdescribe,
  expect, it, xit,
  async, inject
} from '@angular/core/testing';

import { NavBarComponent } from './nav-bar.component';

describe('Component: NavBar', () => {
  it('should create an instance', () => {
    let component = new NavBarComponent(null);
    expect(component).toBeTruthy();
  });
});

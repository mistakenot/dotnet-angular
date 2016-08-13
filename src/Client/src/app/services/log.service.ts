import { Injectable, OpaqueToken } from '@angular/core';

export let LogService = new OpaqueToken("log.service");

export interface ILogService {
    info(msg: string);
    error(msg: string);
}

@Injectable()
export class ConsoleLogService implements ILogService {

  constructor() {}

  info(msg: string) {
      window.console.info(msg);
  }

  error(msg: string) {
      window.console.error(msg);
  }

}

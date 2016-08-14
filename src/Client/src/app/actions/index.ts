import { IAction, IInboxHeader } from '../models';
import { NgRedux } from 'ng2-redux';

export class InboxActions {
    static ADD: string = "INBOX_ACTIONS.ADD";
    static REMOVE: string = "INBOX_ACTIONS.REMOVE";
    
    constructor(
        private ngRedux: NgRedux<IAction>
    ) { }

    add(to: string, from: string): IAction {
        let payload: IInboxHeader = {
            to: to,
            from: from
        }

        return {
            type: InboxActions.ADD,
            data: payload
        };
    }
}

import { InboxActions } from '../actions';
import { IAction, IInboxHeader } from '../models';

export interface IInboxHeadersState {
    inboxHeaders: IInboxHeader[]
}

const INITIAL_STATE: IInboxHeadersState = {
    inboxHeaders: [
        { to: "tim@email.com", from: "bob@email.com" }
    ]
}

export function reducer(state = INITIAL_STATE, action: IAction) {
    switch(action.type) {
        case InboxActions.ADD:
            return state.inboxHeaders.push(<IInboxHeader>action.data);
    }
}

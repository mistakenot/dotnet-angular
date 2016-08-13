import { IAction, InboxActions } from '../actions';
import { IInboxHeader } from '../models';

export interface IInboxHeadersState {
    inboxHeaders: IInboxHeader[]
}

const INITIAL_STATE: IInboxHeadersState = {
    inboxHeaders: []
}

export function reducer(state = INITIAL_STATE, action: IAction) {
    switch(action.type) {
        case InboxActions.ADD:
            return state.inboxHeaders.push(<IInboxHeader>action.data);
    }
}

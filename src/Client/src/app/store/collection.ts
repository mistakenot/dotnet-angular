import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/groupBy';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Dictionary } from 'typescript-collections';

export class Collection<TKey, TValue> {
    private _items: Dictionary<TKey, TValue>;
    private _subject: BehaviorSubject<TValue[]>;

    constructor(
        private getKey: (value: TValue) => TKey) {

        this._items = new Dictionary<TKey, TValue>();
        this._subject = new BehaviorSubject([]);
    }

    add(value: TValue): boolean {
        let key = this.getKey(value);
        if (!this._items.containsKey(key)) {
            this._items.setValue(key, value);
            this._publish();
            return true;
        }
        else {
            return false;
        }
    }

    update(key: TKey, action: (val: TValue) => TValue): boolean {
        if (this._items.containsKey(key)) {
            let original = this._items.getValue(key);
            let next = action(original);
            this._items.setValue(key, next);
            this._publish();
            return true;
        }
        else {
            return false;
        }
    }

    getByKey(key: TKey): Observable<TValue> {
        return this._subject
            .map(values => values.filter(v => this.getKey(v) === key))
            .filter(values => values.length === 1)
            .map(values => values[0]);
    }

    getAll(): Observable<Observable<TValue>[]> {

    }

    private _publish() {
        this._subject.next(this._items.values());
    }

}

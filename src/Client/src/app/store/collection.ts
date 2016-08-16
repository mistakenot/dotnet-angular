import { Injectable, Inject } from '@angular/core';
import { Http } from '@angular/http';
import { Observable } from 'rxjs/Observable';
import 'rxjs/add/operator/map';
import 'rxjs/add/operator/toPromise';
import 'rxjs/add/operator/groupBy';
import { BehaviorSubject } from 'rxjs/BehaviorSubject';
import { Dictionary } from 'typescript-collections';

export class Collection<TKey, TValue> {
    private _items: Dictionary<TKey, BehaviorSubject<TValue>>;
    private _subject: BehaviorSubject<BehaviorSubject<TValue>[]>;

    constructor(
        private getKey: (value: TValue) => TKey) {

        this._items = new Dictionary<TKey, BehaviorSubject<TValue>>();
        this._subject = new BehaviorSubject([]);
    }

    add(value: TValue): boolean {
        let key = this.getKey(value);
        if (!this._items.containsKey(key)) {
            this._items.setValue(key, new BehaviorSubject(value));
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
            let next = action(original.getValue());
            original.next(next);
            return true;
        }
        else {
            return false;
        }
    }

    getByKey(key: TKey): Observable<TValue> {
        return this._items.getValue(key);
    }

    getAll(): Observable<Observable<TValue>[]> {
        return this._subject;
    }

    private _publish() {
        this._subject.next(this._items.values());
    }

}

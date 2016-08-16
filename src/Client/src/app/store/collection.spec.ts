import {
  beforeEach, beforeEachProviders,
  describe, xdescribe,
  expect, it, xit,
  async, inject
} from '@angular/core/testing';
import { Collection } from './collection';
import { Observable } from 'rxjs/Observable';
import 'rxjs/core/perf/operators/empty';

interface IModel {
    id: number;
    val: string;
}

describe('Collection', () => {
    let items = new Collection<number, IModel>(m => m.id);
    let itemsObservable = items.getAll();
    var lastItemsValue: Observable<IModel>[] = [];

    itemsObservable.subscribe(vals => {
        lastItemsValue = vals;
    });

    it('should add a value', () => {
        let model = {
            id: 1,
            val: "one"
        };

        items.add(model);

        expect(lastItemsValue.length).toBe(1);
    });

    var model: Observable<IModel> = null;

    it('should retrieve a value', () => {
        model = items.getByKey(1);
        model.subscribe(value => {
            expect(value.id).toBe(1);
        })
    });

});

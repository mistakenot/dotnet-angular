import { Component, OnInit } from '@angular/core';
import { Collection } from '../../store/collection';

export interface IModel {
    id: number;
    value: string;
}

@Component({
  moduleId: module.id,
  selector: 'app-list',
  templateUrl: 'list.component.html',
  styleUrls: ['list.component.css']
})
export class ListComponent implements OnInit {
    collection: Collection<number, IModel>;

    constructor() {
        this.collection = new Collection<number, IModel>(m => m.id);
    }

    ngOnInit() {
    }

    add() {
        
    }

}

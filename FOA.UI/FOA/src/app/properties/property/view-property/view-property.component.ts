import { Component } from '@angular/core';

@Component({
  selector: 'app-view-property',
  templateUrl: './view-property.component.html',
  styleUrls: ['./view-property.component.scss']
})
export class ViewPropertyComponent {
  currentDate!: string;

   constructor() {
    this.currentDate = (new Date().getMonth() + 1).toString() + '-' + new Date().getFullYear().toString();

   }
}

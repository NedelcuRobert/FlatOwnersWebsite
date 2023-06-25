import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddRequestComponent } from './add-request/add-request.component';

@Component({
  selector: 'app-requests',
  templateUrl: './requests.component.html',
  styleUrls: ['./requests.component.scss']
})
export class RequestsComponent {
  constructor(private dialog: MatDialog){

  }


  openAddDialog(){
    const dialogRef = this.dialog.open(AddRequestComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }
}


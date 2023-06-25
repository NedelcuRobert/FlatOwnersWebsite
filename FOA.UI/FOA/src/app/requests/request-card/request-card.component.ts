import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RequestDetailsComponent } from './request-details/request-details.component';

@Component({
  selector: 'app-request-card',
  templateUrl: './request-card.component.html',
  styleUrls: ['./request-card.component.scss']
})
export class RequestCardComponent {
  constructor(private dialog: MatDialog){

  }

  onDetails() {
    const dialogRef = this.dialog.open(RequestDetailsComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  onDelete() {
  }
}

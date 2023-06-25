import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { AddPropertyComponent } from './add-property/add-property.component';
import { ApartmentService } from 'src/core/apartment.service';
import { SessionStorageService } from 'ngx-webstorage';
import { Apartment } from 'src/models/apartment';

@Component({
  selector: 'app-properties',
  templateUrl: './properties.component.html',
  styleUrls: ['./properties.component.scss']
})
export class PropertiesComponent {

  apartments: Apartment[] = [];

  constructor(private dialog: MatDialog,
    private apartmentService: ApartmentService,
    private sessionStorageService: SessionStorageService){
      this.getApartments();
  }

  ngOnInit(): void {
  }

  openAddDialog(){
    const dialogRef = this.dialog.open(AddPropertyComponent);
    dialogRef.afterClosed().subscribe(() => {
      window.location.reload();
    });
  }

  getApartments(): void {
    const userId =  this.sessionStorageService.retrieve('user').username;
    this.apartmentService.getByUserId(userId).subscribe({
      next: (response) => this.apartments = [...response],
      complete: () => console.log(this.apartments),
      error: (error) => console.error(error)
    })
  }
}

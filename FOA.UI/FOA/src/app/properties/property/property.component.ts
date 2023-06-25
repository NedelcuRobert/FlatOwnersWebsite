import { Component, Inject, Input, OnInit } from '@angular/core';
import { MAT_DIALOG_DATA, MatDialog } from '@angular/material/dialog';
import { EditPropertyComponent } from './edit-property/edit-property.component';
import { ViewPropertyComponent } from './view-property/view-property.component';
import { AddWaterConsumptionComponent } from './add-water-consumption/add-water-consumption.component';
import { Apartment } from 'src/models/apartment';
import { ApartmentService } from 'src/core/apartment.service';
import { SessionStorageService } from 'ngx-webstorage';
import { WaterConsumption } from 'src/models/water-consumption';
import { FOAReport } from 'src/models/report';
import { ReportsService } from 'src/core/reports.service';

@Component({
  selector: 'app-property',
  templateUrl: './property.component.html',
  styleUrls: ['./property.component.scss']
})
export class PropertyComponent implements OnInit {
  @Input() apartment!: Apartment;
  waterConsumptions: WaterConsumption[] = [];
  lastConsumption!: WaterConsumption;
  reports: FOAReport[] = [];
  lastReport!: FOAReport;

  constructor(private dialog: MatDialog,
    private apartmentService: ApartmentService,
    private sessionStorageService: SessionStorageService,
    private reportService: ReportsService
    ){

  }

  ngOnInit(): void {
    this.getWaterConsumption();
    this.getReports();
  }

  onEdit() {
    const dialogRef = this.dialog.open(EditPropertyComponent, {data: {id: this.apartment.id}});
    dialogRef.afterClosed().subscribe(result => {
      window.location.reload();
    });
  }

  onView() {
    const dialogRef = this.dialog.open(ViewPropertyComponent);
    dialogRef.afterClosed().subscribe(result => {
      console.log(`Dialog result: ${result}`);
    });
  }

  onAddWC() {
    const dialogRef = this.dialog.open(AddWaterConsumptionComponent, {data: {id: this.apartment.id}});
    dialogRef.afterClosed().subscribe(result => {
      window.location.reload();;
    });
  }

  getWaterConsumption(){
    this.apartmentService.getWaterConsumption(this.apartment.id).subscribe({
      next: (response) => this.waterConsumptions = [...response],
      complete: () => {
        this.lastConsumption = this.waterConsumptions.at(this.waterConsumptions.length - 1) as WaterConsumption
        this.lastConsumption.creationDate = this.getDate(this.lastConsumption.creationDate);
      },
      error: (error) => console.error(error)
    })
  }

  getDate(strDate: string): string{
    const date = new Date(strDate);

    const day = date.getDate();
    const month = date.getMonth() + 1; // Month value is zero-based, so we add 1 to get the correct month
    const year = date.getFullYear();

    return `${day} / ${month} / ${year}`;
  }

  getReports(){
    this.reportService.getReportForApartment(this.apartment.id).subscribe({
      next: (response) => this.reports = [...response],
      complete: () => {
        console.log(this.reports)
        this.lastReport = this.reports.at(this.reports.length - 1) as FOAReport
        this.lastReport.dueDate = this.getDate(this.lastReport.dueDate)
      },
      error: (err) => console.error(err)
    })
  }
}

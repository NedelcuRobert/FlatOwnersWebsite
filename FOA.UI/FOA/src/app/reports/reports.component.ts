import { Component, OnInit, ViewChild } from '@angular/core';
import { MatSort } from '@angular/material/sort';
import { MatTableDataSource } from '@angular/material/table';
import {MatPaginator} from '@angular/material/paginator';
import { ReportsService } from 'src/core/reports.service';
import { FOAReport } from 'src/models/report';

@Component({
  selector: 'app-reports',
  templateUrl: './reports.component.html',
  styleUrls: ['./reports.component.scss']
})
export class ReportsComponent implements OnInit {
  reports: FOAReport[] = [];
  displayedColumns: string[] = ['id', 'amount', 'creationDate', 'dueDate'];
  dataSource: MatTableDataSource<FOAReport>;

  @ViewChild(MatPaginator) paginator!: MatPaginator;
  @ViewChild(MatSort) sort!: MatSort;

  constructor(private reportService: ReportsService ) {
    this.getReports();
    this.dataSource = new MatTableDataSource(this.reports);
  }

  ngOnInit(): void {

  }

  ngAfterViewInit() {

  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }

  }

  getReports(): void {
    this.reportService.getReports().subscribe({
      next: (response) => this.reports = [...response],
      complete: () => {
        this.reports.forEach(r => {
          r.creationDate = this.getDate(r.creationDate);
          r.dueDate = this.getDate(r.dueDate);
        })
        this.dataSource = new MatTableDataSource(this.reports);
        this.dataSource.paginator = this.paginator;
        this.dataSource.sort = this.sort;
      },
      error: (err) => console.error(err)
    })
  }

  adjustDates() {

  }

  getDate(strDate: string): string{
    const date = new Date(strDate);

    const day = date.getDate();
    const month = date.getMonth() + 1; // Month value is zero-based, so we add 1 to get the correct month
    const year = date.getFullYear();

    return `${day} / ${month} / ${year}`;
  }
}


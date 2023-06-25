import { Component } from '@angular/core';
import { ReportsService } from 'src/core/reports.service';

@Component({
  selector: 'app-admin-reports',
  templateUrl: './admin-reports.component.html',
  styleUrls: ['./admin-reports.component.scss']
})
export class AdminReportsComponent {
  constructor(private reportService: ReportsService){

  }

  onSubmit(){
    this.reportService.generateReports().subscribe({
      complete: () => {
        window.location.reload();
      }
    });
  }
}

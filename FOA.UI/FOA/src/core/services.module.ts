import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { AuthenticationService } from './authentication.service';


@NgModule({
  providers: [
    AuthenticationService
  ],
  declarations: [],
  imports: [
    CommonModule
  ]
})
export class ServicesModule { }

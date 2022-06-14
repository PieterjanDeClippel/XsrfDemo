import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { HttpClientModule } from '@angular/common/http';

import { FetchDataRoutingModule } from './fetch-data-routing.module';
import { FetchDataComponent } from './fetch-data.component';


@NgModule({
  declarations: [
    FetchDataComponent
  ],
  imports: [
    CommonModule,
    HttpClientModule,
    FetchDataRoutingModule
  ]
})
export class FetchDataModule { }

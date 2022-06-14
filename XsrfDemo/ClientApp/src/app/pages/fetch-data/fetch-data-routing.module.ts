import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { FetchDataComponent } from './fetch-data.component';

const routes: Routes = [{ path: '', component: FetchDataComponent }, { path: 'add', loadChildren: () => import('./create/create.module').then(m => m.CreateModule) }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class FetchDataRoutingModule { }

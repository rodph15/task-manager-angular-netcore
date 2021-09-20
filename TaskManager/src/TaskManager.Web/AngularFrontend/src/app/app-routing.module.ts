import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';


import { ListComponent } from './features/task/list/list.component';
import { CreateComponent } from './features/task/create/create.component';
import { EditComponent } from './features/task/edit/edit.component';


const routes: Routes = [
  { path: 'list', component: ListComponent },
  { path: 'create', component: CreateComponent },
  { path: 'edit/:name', component: EditComponent },
  { path: '**', redirectTo: 'list', pathMatch: 'full' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes, { useHash: true })],
  exports: [RouterModule]
})
export class AppRoutingModule { }

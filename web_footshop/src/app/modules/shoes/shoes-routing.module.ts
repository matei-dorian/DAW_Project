import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ShoeDetailComponent } from './shoe-detail/shoe-detail.component';
import { ShoesComponent } from './shoes/shoes.component';

const routes: Routes = [
  {
     path: '',
     redirectTo: 'shoes',
     pathMatch: 'full'
  },
  {
    path: 'shoes',
    component: ShoesComponent,
    pathMatch: 'full'
  },
  {
    path: 'detail/:id',
    component: ShoeDetailComponent,
    pathMatch: 'full'
  }
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})

export class ShoesRoutingModule { }

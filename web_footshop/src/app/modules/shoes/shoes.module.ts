import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { ShoesRoutingModule } from './shoes-routing.module';
import { ShoesComponent } from './shoes/shoes.component';
import { MaterialModule } from '../material/material.module';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { SharedModule } from '../shared/shared.module';
import { ShoeDetailComponent } from './shoe-detail/shoe-detail.component';

@NgModule({
  declarations: [
    ShoesComponent,
    ShoeDetailComponent,
  ],
  imports: [
    CommonModule,
    ShoesRoutingModule,
    ReactiveFormsModule,
    MaterialModule,
    FormsModule,
    SharedModule,
  ],
})
export class ShoesModule { }

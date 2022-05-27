import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ListTablaComponent } from './list-tabla.component';
import { MaterialModule } from '../../app.module';
@NgModule({
  imports: [
    CommonModule,
    MaterialModule
  ],
  declarations: [ListTablaComponent],
  exports: [ListTablaComponent]
})
export class ListTablaModule { }
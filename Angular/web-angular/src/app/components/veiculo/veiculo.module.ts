import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { VeiculoCreateComponent } from './veiculo-create/veiculo-create.component';
import { VeiculoEditComponent } from './veiculo-edit/veiculo-edit.component';
import { VeiculoIndexComponent } from './veiculo-index/veiculo-index.component';
import { VeiculoRoutingModule } from './veiculo-routing.module';


@NgModule({
  declarations: [
    VeiculoIndexComponent,
    VeiculoCreateComponent,
    VeiculoEditComponent
  ],
  imports: [
    CommonModule,
    VeiculoRoutingModule,
    FormsModule
  ]
})
export class VeiculoModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { VeiculoCreateComponent } from './veiculo-create/veiculo-create.component';
import { VeiculoEditComponent } from './veiculo-edit/veiculo-edit.component';
import { VeiculoIndexComponent } from './veiculo-index/veiculo-index.component';

const routes: Routes = [
  {path: '', component: VeiculoIndexComponent, pathMatch: 'full'},
  {path: 'veiculo-index', component: VeiculoIndexComponent},
  {path: 'veiculo-create', component: VeiculoCreateComponent},
  {path: 'veiculo-edit/:id', component: VeiculoEditComponent}
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class VeiculoRoutingModule { }

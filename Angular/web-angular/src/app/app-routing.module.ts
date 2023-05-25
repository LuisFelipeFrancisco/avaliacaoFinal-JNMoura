import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { MensagemErro404Component } from './components/mensagem/mensagem-erro404/mensagem-erro404.component';
import { LoginComponent } from './components/login/login.component';
import { AutenticacaoGuard } from './guards/autenticacao.guard';

const routes: Routes = [
  {path: 'home', component: HomeComponent, canActivate: [AutenticacaoGuard]},
  {path: '', redirectTo: '/home', pathMatch: 'full'},
  {path: 'login', component: LoginComponent},
  {path: 'veiculo', loadChildren: () => import('./components/veiculo/veiculo.module').then(v => v.VeiculoModule), canActivate: [AutenticacaoGuard]},
  {path:'**', component: MensagemErro404Component}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

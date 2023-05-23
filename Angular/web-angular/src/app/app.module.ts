import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { MensagemErro404Component } from './components/mensagem/mensagem-erro404/mensagem-erro404.component';
import { MenuComponent } from './components/menu/menu.component';
import { VeiculoCreateComponent } from './components/veiculo/veiculo-create/veiculo-create.component';
import { VeiculoEditComponent } from './components/veiculo/veiculo-edit/veiculo-edit.component';
import { VeiculoIndexComponent } from './components/veiculo/veiculo-index/veiculo-index.component';


@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    VeiculoCreateComponent,
    VeiculoEditComponent,
    VeiculoIndexComponent,
    MensagemErro404Component,
    MenuComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

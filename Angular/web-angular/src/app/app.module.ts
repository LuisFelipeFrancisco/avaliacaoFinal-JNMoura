import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { HomeComponent } from './components/home/home.component';
import { VeiculoCreateComponent } from './components/veiculo/veiculo-create/veiculo-create.component';
import { VeiculoEditComponent } from './components/veiculo/veiculo-edit/veiculo-edit.component';
import { VeiculoIndexComponent } from './components/veiculo/veiculo-index/veiculo-index.component';

@NgModule({
  declarations: [
    AppComponent,
    HomeComponent,
    VeiculoCreateComponent,
    VeiculoEditComponent,
    VeiculoIndexComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

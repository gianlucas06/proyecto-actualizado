import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { PanelaRegistroComponent } from './Produccion/panela-registro/panela-registro.component';
import { PanelaConsultaComponent } from './Produccion/panela-consulta/panela-consulta.component';
import { Routes, RouterModule } from '@angular/router';



const routes: Routes = [
  {
  path: 'panelaRegistro',
  component: PanelaRegistroComponent
  },

  {
    path: 'panelaConsulta',
    component: PanelaConsultaComponent
  }
];



@NgModule({
  declarations: [],
  imports: [
    CommonModule,RouterModule.forRoot(routes)
  ],
  exports:[RouterModule]
})
export class AppRoutingModule { }


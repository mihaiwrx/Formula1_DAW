import { CalendarpageComponent } from './calendarpage/calendarpage.component';
import { StartpageComponent } from './startpage/startpage.component';
import { NgModule, Component } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomepageComponent } from './homepage/homepage.component';

const routes: Routes = [
  {path:'', component: StartpageComponent},
  {path:'home', component: HomepageComponent},
  {path:'calendar', component: CalendarpageComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }

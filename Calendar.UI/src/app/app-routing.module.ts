import { CalendarComponent } from './components/calendar/calendar.component';
import { MonthComponent } from './components/month/month.component';

import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { HomeComponent } from './components/home/home.component';
import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HttpClientModule } from '@angular/common/http';


const routes: Routes = [
  { path: '', component: HomeComponent },
  {path:'month', component:MonthComponent},
  {path:'calendar', component:CalendarComponent},
  { path: 'calendar/:id', component: CalendarComponent },
  {path:'**', component:PageNotFoundComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes), HttpClientModule],
  exports: [RouterModule],
})
export class AppRoutingModule {}

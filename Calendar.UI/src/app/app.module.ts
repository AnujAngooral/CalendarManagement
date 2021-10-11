import { CalendarComponent } from './components/calendar/calendar.component';
import { MonthComponent } from './components/month/month.component';

import { NgModule } from '@angular/core';
import {MatTabsModule} from '@angular/material/tabs'
import { BrowserModule } from '@angular/platform-browser';
import { MatButtonModule } from '@angular/material/button';
import { HTTP_INTERCEPTORS } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { LoggerModule, NgxLoggerLevel } from 'ngx-logger';
import { environment } from 'src/environments/environment';


import { AppRoutingModule } from './app-routing.module';



import { HTTPInterceptor } from './services/http-interceptor.service';

import { AppComponent } from './app.component';
import { PageNotFoundComponent } from './components/page-not-found/page-not-found.component';
import { HomeComponent } from './components/home/home.component';
import { MainNavComponent } from './components/main-nav/main-nav.component';
import { LayoutModule } from '@angular/cdk/layout';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatIconModule } from '@angular/material/icon';
import { MatListModule } from '@angular/material/list';
import { MatSnackBar } from '@angular/material/snack-bar';

import { CommonModule } from '@angular/common';
import {MatExpansionModule} from '@angular/material/expansion'
import { NotifyService } from './services/notify.service';
import { OverlayModule } from '@angular/cdk/overlay';



@NgModule({
  declarations: [CalendarComponent, MonthComponent, AppComponent, PageNotFoundComponent, HomeComponent, MainNavComponent],
  imports: [OverlayModule,MatExpansionModule, CommonModule ,BrowserModule,  AppRoutingModule, BrowserAnimationsModule,
    MatButtonModule, LayoutModule,
    MatToolbarModule, MatSidenavModule, MatIconModule, MatListModule, MatTabsModule,
    LoggerModule.forRoot({
      level:environment.logLevel,
      disableConsoleLogging: false
    }) ],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: HTTPInterceptor,
      multi: true,
    },
    NotifyService,
    MatSnackBar


  ],
  bootstrap: [AppComponent],
})
export class AppModule {}

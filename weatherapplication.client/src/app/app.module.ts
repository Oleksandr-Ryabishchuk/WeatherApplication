import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { RandomWeatherComponent } from './core/pages/random-weather/random-weather.component';
import { AppRoutingModule } from './routing.module';
import { RouterModule } from '@angular/router';

@NgModule({
  declarations: [
    AppComponent,
    RandomWeatherComponent
  ],
  imports: [
    BrowserModule, 
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([{ path: '**', component: RandomWeatherComponent }]),
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './routing.module';
import { RouterModule } from '@angular/router';
import { CurrentWeatherPageComponent } from './core/pages/current-weather-page/current-weather-page.component';
import { FivedaysWeatherPageComponent } from './core/pages/fivedays-weather-page/fivedays-weather-page.component';
import { StatisticsPageComponent } from './core/pages/statistics-page/statistics-page.component';
import { RandomWeatherComponent } from './core/pages/random-weather/random-weather.component';
import { HttpService } from './services/http.service';
import { CurrentWeatherFormComponent } from './core/components/current-weather-form/current-weather-form.component';

@NgModule({
  declarations: [
    AppComponent,
    RandomWeatherComponent,
    CurrentWeatherPageComponent,
    FivedaysWeatherPageComponent,
    StatisticsPageComponent,
    CurrentWeatherFormComponent
  ],
  imports: [
    BrowserModule, 
    HttpClientModule, 
    AppRoutingModule,
    RouterModule.forRoot([{ path: '**', component: RandomWeatherComponent }]),
  ],
  exports: [CurrentWeatherPageComponent, FivedaysWeatherPageComponent, StatisticsPageComponent],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

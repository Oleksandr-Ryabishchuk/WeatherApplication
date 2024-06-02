import { HttpClientModule } from '@angular/common/http';
import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { AppRoutingModule } from './routing.module';
import { RouterLink, RouterModule } from '@angular/router';
import { CurrentWeatherPageComponent } from './core/pages/current-weather-page/current-weather-page.component';
import { FivedaysWeatherPageComponent } from './core/pages/fivedays-weather-page/fivedays-weather-page.component';
import { StatisticsPageComponent } from './core/pages/statistics-page/statistics-page.component';
import { RandomWeatherComponent } from './core/pages/random-weather/random-weather.component';
import { CurrentWeatherFormComponent } from './core/components/forms/current-weather-form/current-weather-form.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { FiveDaysWeatherTableComponent } from './core/components/tables/five-days-weather-table/five-days-weather-table.component';
import { MainBodyComponent } from './core/components/main-body/main-body.component';
import { StatisticsFormComponent } from './core/components/forms/statistics-form/statistics-form.component';
import { CurrentWeatherTableComponent } from './core/components/tables/current-weather-table/current-weather-table.component';
import { StatisticsTableComponent } from './core/components/tables/statistics-table/statistics-table.component';

@NgModule({
  declarations: [
    AppComponent,
    RandomWeatherComponent,
    CurrentWeatherPageComponent,
    FivedaysWeatherPageComponent,
    StatisticsPageComponent,
    CurrentWeatherFormComponent,
    FiveDaysWeatherTableComponent,
    MainBodyComponent,
    StatisticsFormComponent,
    CurrentWeatherTableComponent,
    StatisticsTableComponent,
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    AppRoutingModule,
    RouterModule.forRoot([{ path: '**', component: RandomWeatherComponent }]),
    FormsModule,
    ReactiveFormsModule,
    RouterLink,
  ],
  exports: [
    CurrentWeatherPageComponent,
    FivedaysWeatherPageComponent,
    StatisticsPageComponent,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}

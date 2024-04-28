import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { RandomWeatherComponent } from "./core/pages/random-weather/random-weather.component";
import { CurrentWeatherPageComponent } from "./core/pages/current-weather-page/current-weather-page.component";
import { FivedaysWeatherPageComponent } from "./core/pages/fivedays-weather-page/fivedays-weather-page.component";
import { StatisticsPageComponent } from "./core/pages/statistics-page/statistics-page.component";

const routes: Routes = [
    { path: 'randomweather', component: RandomWeatherComponent },
    { path: 'currentweather', component: CurrentWeatherPageComponent },
    { path: 'fivedaysweather', component: FivedaysWeatherPageComponent },
    { path: 'statistics', component: StatisticsPageComponent },
    { path: '', redirectTo: 'randomweather', pathMatch: 'full' }
  ];
  //hello world!
  @NgModule({
    imports: [
      RouterModule.forRoot(routes),
    ],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
  
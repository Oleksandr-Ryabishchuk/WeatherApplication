import { NgModule } from "@angular/core";
import { RouterModule, Routes } from "@angular/router";
import { RandomWeatherComponent } from "./core/pages/core/pages/random-weather/random-weather.component";

const routes: Routes = [
    { path: 'randomweather', component: RandomWeatherComponent },
    { path: '', redirectTo: 'randomweather', pathMatch: 'full' }
  ];
  
  @NgModule({
    imports: [
      RouterModule.forRoot(routes),
    ],
    exports: [RouterModule]
  })
  export class AppRoutingModule { }
  
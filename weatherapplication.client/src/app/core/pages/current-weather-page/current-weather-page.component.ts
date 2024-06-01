import { Component } from '@angular/core';
import {
  CurrentWeather,
  CurrentWeatherQuery,
  HttpService,
} from 'src/app/services/http.service';

@Component({
  selector: 'app-current-weather-page',
  templateUrl: './current-weather-page.component.html',
  styleUrls: ['./current-weather-page.component.css'],
})
export class CurrentWeatherPageComponent {
  currentWeather: CurrentWeather[] | null = [];
  constructor(private http: HttpService) {}

  getCurrentWeather(query: Partial<CurrentWeatherQuery>) {
    if (query) {
      this.http
        .getCurrentWeather(
          query.city!,
          query.email!,
          query.cityCode!,
          query.stateCode!
        )
        .subscribe((x) => {
          if (this.currentWeather) {
            this.currentWeather?.pop();
          }
          this.currentWeather?.push(x);
        });
    }
  }
}

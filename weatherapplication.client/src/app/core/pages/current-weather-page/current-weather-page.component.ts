import { Component, OnInit } from '@angular/core';
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
export class CurrentWeatherPageComponent implements OnInit {
  currentWeather: CurrentWeather | null = null;
  constructor(private http: HttpService) {}

  ngOnInit() {}
  getCurrentWeather(query: Partial<CurrentWeatherQuery>) {
    if (query) {
      this.http
        .getCurrentWeather(
          query.city!,
          query.email!,
          query.cityCode!,
          query.stateCode!
        )
        .subscribe((x) => (this.currentWeather = x));
    }
  }
}

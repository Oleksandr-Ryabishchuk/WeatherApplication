import { Component} from '@angular/core';
import {
  CurrentWeatherQuery,
  FiveDaysWeather,
  HttpService,
} from 'src/app/services/http.service';

@Component({
  selector: 'fivedays-weather-page',
  templateUrl: './fivedays-weather-page.component.html',
  styleUrls: ['./fivedays-weather-page.component.css'],
})
export class FivedaysWeatherPageComponent {
fiveDaysWeather: FiveDaysWeather | null = null;
  constructor(private http: HttpService) {}

  getFiveDaysWeather(query: Partial<CurrentWeatherQuery>) {
    if (query) {
      this.http
        .getFiveDaysWeather(
          query.city!,
          query.email!,
          query.cityCode!,
          query.stateCode!
        )
        .subscribe((x) => (this.fiveDaysWeather = x));
    }
  }
}

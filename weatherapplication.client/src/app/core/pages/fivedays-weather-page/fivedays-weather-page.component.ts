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
fiveDaysWeather: FiveDaysWeather[] = [];
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
        .subscribe((x) => {
          if (this.fiveDaysWeather) {
          this.fiveDaysWeather?.pop();
        }
        this.fiveDaysWeather?.push(x);})
    }
  }
}

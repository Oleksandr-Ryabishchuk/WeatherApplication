import { Component, OnInit } from '@angular/core';
import { CurrentWeatherQuery, FiveDaysWeather, HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-fivedays-weather-page',
  templateUrl: './fivedays-weather-page.component.html',
  styleUrls: ['./fivedays-weather-page.component.css']
})
export class FivedaysWeatherPageComponent implements OnInit{
  fiveDaysWeather: FiveDaysWeather | null = null;
  constructor(private http: HttpService) {}

  ngOnInit() {}
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
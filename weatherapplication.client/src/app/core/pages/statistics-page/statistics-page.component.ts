import { Component, inject } from '@angular/core';
import {
  CurrentWeather,
  FiveDaysWeather,
  HttpService,
  Record,
  StatisticsQuery,
} from 'src/app/services/http.service';

@Component({
  selector: 'statistics-page',
  templateUrl: './statistics-page.component.html',
  styleUrls: ['./statistics-page.component.css'],
})
export class StatisticsPageComponent {
  http = inject(HttpService);
  currentWeather: (CurrentWeather | undefined)[] = [];
  fiveDaysWeather: (FiveDaysWeather | undefined)[]= [];

  getStatistics(query: Partial<StatisticsQuery>) {
    if (query) {
      this.http
        .getStatistics(query.userEmail!, query.fromDate, query.toDate)
        .subscribe((x) => {
           x.forEach((a) => {
            let weather = a.currentWeather;
            if (weather && a.currentWeather !== null) {
              weather.createdAt = a.createdAt;
              weather.isFromRecord = true;
              weather.state = a.state;
              weather.lat = a.lat;
              weather.lon = a.lon;
              weather.country = a.country;
              this.currentWeather?.push(weather)
            };
          });
          this.fiveDaysWeather = x.map((q) => q.fiveDaysWeather);
        });
    }
  }
}

import { Component, OnInit, inject } from '@angular/core';
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
  record: Record[] | null = null;
  currentWeather: (CurrentWeather | undefined)[] | null = null;
  fiveDaysWeather: (FiveDaysWeather | undefined)[] | null = null;

  getStatistics(query: Partial<StatisticsQuery>) {
    if (query) {
      this.http
        .getStatistics(query.userEmail!, query.fromDate, query.toDate)
        .subscribe((x) => {
          this.record = x;
          this.currentWeather = x.map(a => {
            let weather = a.currentWeather;
            if(weather) {
              weather.createdAt = a.createdAt;
              weather.isFromRecord = true;
              weather.state = a.state;
              weather.lat = a.lat;
              weather.lon = a.lon;
            }            
            return weather;
          }
          );
          this.fiveDaysWeather = x.map((q) => q.fiveDaysWeather);
        });
    }
  }
}

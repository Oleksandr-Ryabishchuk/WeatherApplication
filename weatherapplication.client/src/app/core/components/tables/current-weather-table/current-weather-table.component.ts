import { Component, Input } from '@angular/core';
import { CurrentWeather } from 'src/app/services/http.service';


@Component({
  selector: 'current-weather-table',
  templateUrl: './current-weather-table.component.html',
  styleUrls: ['./current-weather-table.component.css'],
})
export class CurrentWeatherTableComponent {
  @Input() currentWeather: (CurrentWeather | undefined)[] = [];
}

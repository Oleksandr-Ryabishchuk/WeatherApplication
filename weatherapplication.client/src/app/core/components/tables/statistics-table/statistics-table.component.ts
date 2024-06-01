import { Component, Input } from '@angular/core';
import { CurrentWeather, FiveDaysWeather, Record } from 'src/app/services/http.service';

@Component({
  selector: 'statistics-table',
  templateUrl: './statistics-table.component.html',
  styleUrls: ['./statistics-table.component.css'],
})
export class StatisticsTableComponent {
  @Input() currentWeather: (CurrentWeather|undefined)[]|null = [];
  @Input() fiveDaysWeather: (FiveDaysWeather|undefined)[]|null = [];
  @Input() activeTab: string = 'currentWeather';
}

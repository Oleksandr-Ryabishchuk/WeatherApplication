import { Component, Input } from '@angular/core';
import { CurrentWeather, Record } from 'src/app/services/http.service';

@Component({
  selector: 'statistics-table',
  templateUrl: './statistics-table.component.html',
  styleUrls: ['./statistics-table.component.css'],
})
export class StatisticsTableComponent {
  @Input() record: Record[] | null = null;
  @Input() currentWeather: (CurrentWeather|undefined)[]|null = null;
  @Input() activeTab: string = 'currentWeather';
}

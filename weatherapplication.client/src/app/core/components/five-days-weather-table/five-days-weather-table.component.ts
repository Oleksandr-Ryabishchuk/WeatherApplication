import { OnInit } from '@angular/core';
import { Component, Input } from '@angular/core';
import { FiveDaysWeather, Item } from 'src/app/services/http.service';

@Component({
  selector: 'five-days-weather-table',
  templateUrl: './five-days-weather-table.component.html',
  styleUrls: ['./five-days-weather-table.component.css'],
})
export class FiveDaysWeatherTableComponent {
  @Input() fiveDaysWeatherData: FiveDaysWeather | null = null;

}

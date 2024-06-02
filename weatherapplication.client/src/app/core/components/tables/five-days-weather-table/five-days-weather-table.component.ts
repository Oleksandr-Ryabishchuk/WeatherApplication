import { OnInit } from '@angular/core';
import { Component, Input } from '@angular/core';
import { FiveDaysWeather, Item } from 'src/app/services/http.service';

@Component({
  selector: 'five-days-weather-table',
  templateUrl: './five-days-weather-table.component.html',
  styleUrls: ['./five-days-weather-table.component.css'],
})
export class FiveDaysWeatherTableComponent {
  @Input() fiveDaysWeatherData: FiveDaysWeather[]  = [];
  @Input() country: string = '';
  @Input() state: string = '';
  @Input() createdAt: Date | null = null;
  @Input() lat: number = 0;
  @Input() lon: number = 0;
  
}

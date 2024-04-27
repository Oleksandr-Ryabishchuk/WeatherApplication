import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { HttpService, WeatherForecast } from 'src/app/services/http.service';

@Component({
  selector: 'app-random-weather',
  templateUrl: './random-weather.component.html',
  styleUrls: ['./random-weather.component.css']
})
export class RandomWeatherComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];

  constructor(private http: HttpService) {}

  ngOnInit() {
   this.http.getForecasts().subscribe(x => this.forecasts = x) ;
  }
  title = 'weatherapplication.client';
}
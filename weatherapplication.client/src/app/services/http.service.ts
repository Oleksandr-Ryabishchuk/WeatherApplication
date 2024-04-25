import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
@Injectable({ providedIn: 'root' })
export class HttpService {
  constructor(private http: HttpClient) {}
  getForecasts() {
    return this.http.get<WeatherForecast[]>('/weatherforecast'); 
  }
  getCurrentWeather() {
    return this.http.get<any>('/CurrentWeather'); 
  }
}

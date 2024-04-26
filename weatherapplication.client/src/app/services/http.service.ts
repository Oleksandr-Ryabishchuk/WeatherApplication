import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
export interface CurrentWeather {
  temp: number;
  pressure: number;
  humidity: number;
  windSpeed: number;
  cloudsAll: number;
}
@Injectable({ providedIn: 'root' })
export class HttpService {
  constructor(private http: HttpClient) {}
  getForecasts() {
    return this.http.get<WeatherForecast[]>('/weatherforecast'); 
  }
  getCurrentWeather(cityName: string, userEmail: string, stateCode: number | null, countryCode: number | null) {
    return this.http.get<CurrentWeather>(`/weatherforecast/CurrentWeather?cityName=${cityName}&userEmail=${userEmail}&stateCode=${stateCode || ''}&countryCode=${countryCode || ''}`); 
  }
}

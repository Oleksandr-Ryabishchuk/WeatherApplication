import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
// _  . .   _           
//  \_____/            

@Injectable({ providedIn: 'root' })

export interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}

export class HttpService {
  constructor(private http: HttpClient) {}
  getForecasts() {
    return this.http.get<WeatherForecast[]>('/weatherforecast'); 
  }
}

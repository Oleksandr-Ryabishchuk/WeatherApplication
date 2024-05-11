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
export interface Item {
  dt: number;
  temp: number;
  feelsLike: number;
  tempMin: number;
  tempMax: number;
  pressure: number;
  seaLevel: number;
  groundLevel: number;
  humidity: number;
  minMaxTempDiff: number;
  weatherMain: string;
  weatherDescription: string;
  weatherIcon: string;
  visibility: number;
  pop: number;
  rain: string | null;
  snow: string | null;
  dateText: string;
  cloudsAll: number;
  windSpeed: number;
  windDeg: number;
  windGust: number;
}
export interface FiveDaysWeather {
   items: Item[];
   cityName: string;
   country:  string;
   lat : number;
   lon : number;
   population: number;
   sunrise : number;
   sunset: number;
   timezone : number;
}
export interface CurrentWeatherQuery {
  city: string;
  email: string;
  cityCode: number;
  stateCode: number;
}
@Injectable({ providedIn: 'root' })
export class HttpService {
  constructor(private http: HttpClient) {}
  getForecasts() {
    return this.http.get<WeatherForecast[]>('/weatherforecast');
  }
  getCurrentWeather(
    cityName: string,
    userEmail: string,
    stateCode: number | null,
    countryCode: number | null
  ) {
    return this.http.get<CurrentWeather>(
      `/weatherforecast/CurrentWeather?cityName=${cityName}&userEmail=${userEmail}&stateCode=${
        stateCode || ''
      }&countryCode=${countryCode || ''}`
    );
  }
  getFiveDaysWeather(
    cityName: string,
    userEmail: string,
    stateCode: number | null,
    countryCode: number | null
  ) {
    return this.http.get<FiveDaysWeather>(
      `/weatherforecast/FiveDaysWeather?cityName=${cityName}&userEmail=${userEmail}&stateCode=${
        stateCode || ''
      }&countryCode=${countryCode || ''}`
    );
  }
}

import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { FivedaysWeatherPageComponent } from '../core/pages/fivedays-weather-page/fivedays-weather-page.component';

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
export interface FiveDaysWeather {
  Dt: number;
  Temp: number;
  FeelsLike: number;
  TempMin: number;
  TempMax: number;
  Pressure: number;
  SeaLevel: number;
  GroundLevel: number;
  Humidity: number;
  MinMaxTempDiff: number;
  WeatherMain: string;
  WeatherDescription: string;
  WeatherIcon: string;
  Visibility: number;
  Pop: number;
  Rain: string | null;
  Snow: string | null;
  DateText: string;
  CloudsAll: number;
  WindSpeed: number;
  WindDeg: number;
  WindGust: number;
  CityName: string;
  Lat: number;
  Lon: number;
  Country: string;
  Population: number;
  Timezone: number;
  Sunrise: number;
  Sunset: number;
}
export interface CurrentWeatherQuery {
  city: string;
  email: string;
  cityCode: number;
  stateCode: number;
}
@Injectable({ providedIn: 'root' })
@Injectable({
  providedIn: 'root',
})
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

import { Component, OnInit } from '@angular/core';
import { CurrentWeather, HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-current-weather-page',
  templateUrl: './current-weather-page.component.html',
  styleUrls: ['./current-weather-page.component.css']
})
export class CurrentWeatherPageComponent implements OnInit {
  currentWeather: CurrentWeather | null = null;
  constructor(private http: HttpService) {}
  
  cityName = <HTMLSelectElement>document.getElementById('city');
  email = <HTMLSelectElement>document.getElementById('mail');
  stateCode = <HTMLSelectElement>document.getElementById('state');
  countryCode = <HTMLSelectElement>document.getElementById('country');
  ngOnInit() {
   this.http.getCurrentWeather(this.cityName.value,this.email.value,Number(this.stateCode.value),Number(this.countryCode.value)).subscribe(x => this.currentWeather = x) ;
  }

}

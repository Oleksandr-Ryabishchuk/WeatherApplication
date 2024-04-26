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

  ngOnInit() {
   this.http.getCurrentWeather('Lviv',"albert@gmail.com",null,null).subscribe(x => this.currentWeather = x) ;
  }

}

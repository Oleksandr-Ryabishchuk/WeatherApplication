import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/app/services/http.service';

@Component({
  selector: 'app-current-weather-page',
  templateUrl: './current-weather-page.component.html',
  styleUrls: ['./current-weather-page.component.css']
})
export class CurrentWeatherPageComponent implements OnInit {
  constructor(private http: HttpService) {}

  ngOnInit() {
   this.http.getCurrentWeather('Lviv',"albert@gmail.com",null,null).subscribe(x => console.log(x)) ;
  }

}

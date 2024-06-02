import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { CurrentWeatherQuery } from 'src/app/services/http.service';

@Component({
  selector: 'app-current-weather-form',
  templateUrl: './current-weather-form.component.html',
  styleUrls: ['./current-weather-form.component.css'],
})
export class CurrentWeatherFormComponent implements OnInit {
  form?: UntypedFormGroup;
  currentWeatherQuery: CurrentWeatherQuery | null = null;
  @Output() weatherEmitter = new EventEmitter<Partial<CurrentWeatherQuery>>();

  constructor(
    private formBuilder: UntypedFormBuilder
  ) {}
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      city: [''],
      email: [''],
      cityCode: [null],
      stateCode: [null],
    });
  }
  getData() {
    this.weatherEmitter.emit({
      city: this.form?.value.city,
      email: this.form?.value.email,
      cityCode: this.form?.value.cityCode,
      stateCode: this.form?.value.stateCode,
    });
  }
}

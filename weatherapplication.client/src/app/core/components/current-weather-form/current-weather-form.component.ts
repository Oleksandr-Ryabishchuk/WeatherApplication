import { Component, OnInit } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';

@Component({
  selector: 'app-current-weather-form',
  templateUrl: './current-weather-form.component.html',
  styleUrls: ['./current-weather-form.component.css']
})
export class CurrentWeatherFormComponent implements OnInit {
  form?:UntypedFormGroup;
  city: string | null = null;
  email: string | null = null;
  cityCode: number | null = null;
  stateCode: number | null = null;
  constructor(private formBuilder:UntypedFormBuilder){
    
  }
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      city: ["Please write your city"],
      email: ["Please write your email"],
      cityCode: [null],
      stateCode: [null]
    });
  }
  onSubmit(){
    console.log(this.form?.value.city);
    console.log(this.form?.value.email);
    console.log(this.form?.value.cityCode);
    console.log(this.form?.value.stateCode);
  }
}
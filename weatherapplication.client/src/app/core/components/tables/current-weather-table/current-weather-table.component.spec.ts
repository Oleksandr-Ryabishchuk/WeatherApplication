import { ComponentFixture, TestBed } from '@angular/core/testing';

import { CurrentWeatherTableComponent } from './current-weather-table.component';

describe('CurrentWeatherTableComponent', () => {
  let component: CurrentWeatherTableComponent;
  let fixture: ComponentFixture<CurrentWeatherTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [CurrentWeatherTableComponent]
    });
    fixture = TestBed.createComponent(CurrentWeatherTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

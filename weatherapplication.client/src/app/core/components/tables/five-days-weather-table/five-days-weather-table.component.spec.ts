import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FiveDaysWeatherTableComponent } from './five-days-weather-table.component';

describe('FiveDaysWeatherTableComponent', () => {
  let component: FiveDaysWeatherTableComponent;
  let fixture: ComponentFixture<FiveDaysWeatherTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [FiveDaysWeatherTableComponent]
    });
    fixture = TestBed.createComponent(FiveDaysWeatherTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

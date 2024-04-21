import { ComponentFixture, TestBed } from '@angular/core/testing';

import { FivedaysWeatherPageComponent } from './fivedays-weather-page.component';

describe('FivedaysWeatherPageComponent', () => {
  let component: FivedaysWeatherPageComponent;
  let fixture: ComponentFixture<FivedaysWeatherPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      imports: [FivedaysWeatherPageComponent]
    })
    .compileComponents();
    
    fixture = TestBed.createComponent(FivedaysWeatherPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

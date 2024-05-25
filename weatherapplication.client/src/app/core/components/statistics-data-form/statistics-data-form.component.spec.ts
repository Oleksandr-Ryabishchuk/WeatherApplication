import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StatisticsDataFormComponent } from './statistics-data-form.component';

describe('StatisticsDataFormComponent', () => {
  let component: StatisticsDataFormComponent;
  let fixture: ComponentFixture<StatisticsDataFormComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StatisticsDataFormComponent]
    });
    fixture = TestBed.createComponent(StatisticsDataFormComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StatisticsDataTabComponent } from './statistics-data-tab.component';

describe('StatisticsDataTabComponent', () => {
  let component: StatisticsDataTabComponent;
  let fixture: ComponentFixture<StatisticsDataTabComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StatisticsDataTabComponent]
    });
    fixture = TestBed.createComponent(StatisticsDataTabComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

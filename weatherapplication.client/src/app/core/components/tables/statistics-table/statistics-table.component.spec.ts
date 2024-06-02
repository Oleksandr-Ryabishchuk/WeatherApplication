import { ComponentFixture, TestBed } from '@angular/core/testing';

import { StatisticsTableComponent } from './statistics-table.component';

describe('StatisticsTableComponent', () => {
  let component: StatisticsTableComponent;
  let fixture: ComponentFixture<StatisticsTableComponent>;

  beforeEach(() => {
    TestBed.configureTestingModule({
      declarations: [StatisticsTableComponent]
    });
    fixture = TestBed.createComponent(StatisticsTableComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});

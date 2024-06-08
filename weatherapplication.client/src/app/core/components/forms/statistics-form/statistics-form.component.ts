import { Component, EventEmitter, OnInit, Output } from '@angular/core';
import { UntypedFormBuilder, UntypedFormGroup } from '@angular/forms';
import { StatisticsQuery } from 'src/app/services/http.service';

@Component({
  selector: 'statistics-form',
  templateUrl: './statistics-form.component.html',
  styleUrls: ['./statistics-form.component.css'],
})
export class StatisticsFormComponent implements OnInit {
  form?: UntypedFormGroup;
  statisticsQuery: StatisticsQuery | null = null;
  @Output() emitter = new EventEmitter<Partial<StatisticsQuery>>();

  constructor(
    private formBuilder: UntypedFormBuilder
  ) {}
  ngOnInit(): void {
    this.form = this.formBuilder.group({
      userEmail: [''],
      fromDate: [''],
      toDate: [''],
    });
  }
  getData() {
    this.emitter.emit({
      userEmail: this.form?.value.userEmail,
      fromDate: this.form?.value.fromDate,
      toDate: this.form?.value.toDate,
    });
  }
}

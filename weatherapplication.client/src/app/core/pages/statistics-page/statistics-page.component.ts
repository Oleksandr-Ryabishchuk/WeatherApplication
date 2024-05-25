import { Component } from '@angular/core';
import {
  Record,
  RecordQuery,
  HttpService,
} from 'src/app/services/http.service';

@Component({
  selector: 'app-statistics-page',
  templateUrl: './statistics-page.component.html',
  styleUrls: ['./statistics-page.component.css']
})
export class StatisticsPageComponent {
  statistic: Record | null = null;
  constructor(private http: HttpService) {}
  tab="currents"
  getRecord(query: Partial<RecordQuery>) {
    if (query) {
      this.http
        .getRecord(
          query.city!,
          query.email!,
          query.startedDate!,
          query.finalDate!
        )
        .subscribe((x) => (this.statistic = x));
    }
  }

}

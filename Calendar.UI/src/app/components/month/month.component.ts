import { IMonth } from './../../models/IMonth';
import { MonthService } from './../../services/month.service';
import { Component, OnInit } from '@angular/core';
import { NGXLogger } from 'ngx-logger';
import { MatTabChangeEvent } from '@angular/material/tabs';


@Component({
  selector: 'app-month',
  templateUrl: './month.component.html',
  styleUrls: ['./month.component.css']
})
export class MonthComponent implements OnInit {

  months: IMonth[] = [];
  constructor(private monthService:MonthService,  private logger: NGXLogger) { }

  ngOnInit() {

    this.monthService.getMonths().subscribe((monthsData) => {

      this.months = monthsData;


      this.logger.debug(`Total ships returned: ${this.months.length}`);

    },
    (error) => {
      this.logger.error(`${error}`);

    });

  }



  test(tabChangeEvent: MatTabChangeEvent): void {
    console.log('tabChangeEvent => ', tabChangeEvent);
    console.log('index => ', tabChangeEvent.index);
  }
}

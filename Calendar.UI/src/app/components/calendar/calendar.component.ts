import { IAppointment } from './../../models/IAppointment';
import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { AppointmentService } from 'src/app/services/appointment.service';
import { NGXLogger } from 'ngx-logger';

@Component({
  selector: 'app-calendar',
  templateUrl: './calendar.component.html',
  styleUrls: ['./calendar.component.css']
})
export class CalendarComponent implements OnInit {
  panelOpenState = false;
  appointments: IAppointment[]=[];
  constructor(private activatedRoute: ActivatedRoute, private appointmentService:AppointmentService, private logger: NGXLogger) { }

  ngOnInit() {
    this.getAppointment();
  }


  private getAppointment() {
    this.activatedRoute.paramMap.subscribe((params) => {
      // if the ship id is present in the url,  we considered it to be an edit request.
      let monthId =  params.get('id');
        if(monthId){
          this.getAppointments(Number(monthId));
        }
        else{
            this.getAppointments(1);
        }

    });
  }

   // Gets the detail of a ship based on the id.
   getAppointments(monthId: number) {
    this.appointmentService.getAppointmentsByMonth(monthId).subscribe((appointments: IAppointment[]) => {
      this.appointments=appointments;

    },
      (error) => {
        this.logger.error(`${error}`);

      });
  }
}

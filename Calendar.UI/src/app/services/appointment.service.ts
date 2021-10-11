import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { Observable, of, throwError } from 'rxjs';
import { IAppointment } from '../models/IAppointment';

@Injectable({
  providedIn: 'root'
})
export class AppointmentService {


  private months: IAppointment[] = [];



  baseURL= environment.baseUrl;
  constructor(
    private httpClient: HttpClient

    ) { }

    getAppointmentsByMonth(monthId:number) : Observable<IAppointment[]>  {
      console.log('baseurl: '+this.baseURL);
     return this.httpClient.get<IAppointment[]>(`${this.baseURL}month/${monthId}/appointments`);
    }



}

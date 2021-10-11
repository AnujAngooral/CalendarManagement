import { IMonth } from './../models/IMonth';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient } from '@angular/common/http';
import { Observable, of, throwError } from 'rxjs';
import { catchError, map, retry } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class MonthService {

  private months: IMonth[] = [];



  baseURL= environment.baseUrl;
  constructor(
    private httpClient: HttpClient

    ) { }

    getMonths() : Observable<IMonth[]>  {
      console.log('baseurl: '+this.baseURL);
     return this.httpClient.get<IMonth[]>(`${this.baseURL}month`);
    }
}

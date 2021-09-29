import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Weather } from '../_models/weather';


@Injectable({
    providedIn: 'root'
})
export class WeatherService {

    baseUrl = environment.apiUrl;
    constructor(private http: HttpClient) { }

    getWeather(): Observable<Weather[]> {
        return this.http.get<Weather[]>(this.baseUrl + '/weatherForecast');
    }

}
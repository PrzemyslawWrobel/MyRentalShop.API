import { Component } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'MyRentalShop-SPA';
  Weather = {
    
  }

  baseUrl = 'https://localhost:44311/WeatherForecast';
  constructor(private http: HttpClient) { }

  getUsers(): Observable<Weather[]> {
    return this.http.get<Weather[]>(this.baseUrl );
  }

}

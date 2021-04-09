import { Component, OnInit } from '@angular/core';
import { Weather } from 'src/_models/weather';
import { WeatherService } from 'src/_services/weather.service';

@Component({
  selector: 'app-weather-list',
  templateUrl: './weather-list.component.html',
  styleUrls: ['./weather-list.component.css']
})
export class WeatherListComponent implements OnInit {
  weathers: Weather[];

  constructor(private weatherService: WeatherService) {
    this.weathers = [];
  }

  ngOnInit(): void {
    this.loadWeathers();
  }
  loadWeathers() {
    this.weatherService.getWeather().subscribe((weathers: Weather[]) => {
      this.weathers = weathers;
    }, error => {
      console.error(error);
    });
  }

}

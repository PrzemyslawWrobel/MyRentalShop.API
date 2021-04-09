import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';

import { AppComponent } from './app.component';
import { WeatherCardComponent } from './weather-card/weather-card.component';
import { WeatherListComponent } from './weather-list/weather-list.component';

@NgModule({
  declarations: [
    AppComponent,
    WeatherCardComponent,
    WeatherListComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule

  ],
  providers: [HttpClientModule],
  bootstrap: [AppComponent]
})
export class AppModule { }

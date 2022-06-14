import { HttpClient } from '@angular/common/http';
import { Component, Inject } from '@angular/core';
import { Router } from '@angular/router';
import { WeatherForecast } from '../../../entities/weather-forecast';

@Component({
  selector: 'app-create',
  templateUrl: './create.component.html',
  styleUrls: ['./create.component.scss']
})
export class CreateComponent {

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string, private router: Router) { }

  forecast: WeatherForecast = {
    date: null,
    summary: '',
    temperatureC: 20,
    temperatureF: 68
  };

  updateDate(date: Date) {
    this.forecast.date = new Date(date);
  }

  createWeatherForecast() {
    this.httpClient.post<WeatherForecast>(`${this.baseUrl}/weatherforecast`, this.forecast).subscribe((forecast) => {
      this.router.navigate(['/fetch-data']);
    });
  }
}

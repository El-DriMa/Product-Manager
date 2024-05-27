import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
interface Order {
  //int Id { get; set; }
  //      public DateTime OrderDate { get; set; }
  //      public int OrderNumber { get; set; }
  //      public decimal ? TotalAmount { get; set; }
  //      public ICollection < OrderItem > OrderItems { get; set; }
}
@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {
  public forecasts: WeatherForecast[] = [];
  public orders: Order[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<WeatherForecast[]>('/weatherforecast').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'productmanager.client';
}

import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
interface WeatherForecast {
  date: string;
  temperatureC: number;
  temperatureF: number;
  summary: string;
}
interface Order {
  id: number;
  orderDate: Date;
  orderNumber: string;
  totalAmount?: number;
  orderItem: string;
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
    // this.getForecasts();
    this.getOrders();
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

  getOrders() {
    this.http.get<Order[]>('https://localhost:7213/api/Order').subscribe(data => {
      this.orders = data;
    }, error => {
      console.error("Greska prilikom dohvatanja podataka", error);
    });
  }

  title = 'productmanager.client';
}

import { Component , OnInit} from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent implements OnInit {

  public forecasts = [];
  ngOnInit(): void {
      
  }
  title = 'productmanager.client';


}

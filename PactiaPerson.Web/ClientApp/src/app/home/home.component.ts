import { Component } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
})
export class HomeComponent {

  persons:any;
  constructor(private http: HttpClient) {
     this.http.get("https://localhost:7054/api/Persons").subscribe(
      data => {this.persons = data}
     )
    
    
     
  }

  
}

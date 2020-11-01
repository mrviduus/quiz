import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { environment } from '@environments/environment';
import { Router } from '@angular/router';

@Component({
  selector: 'app-populatedb',
  templateUrl: './populatedb.component.html',
  styleUrls: ['./populatedb.component.less']
})
export class PopulatedbComponent implements OnInit {

  massege: string;
  timeLeft: number = 10;
  interval;
  constructor(private http: HttpClient, private route: Router) { }

  ngOnInit() {
    console.log("База запущена");
    this.startTimer();
    return this.http.get(`${environment.apiUrl}/api/abracadabra/service/populatedb`).toPromise().then((data:any) =>{
      console.log(data);
  });
  }

  startTimer() {
    this.interval = setInterval(() => {
      if(this.timeLeft > 0) {
        this.timeLeft--;
      } else {
        this.route.navigate(['']);
      }
    },1000)
  }

}

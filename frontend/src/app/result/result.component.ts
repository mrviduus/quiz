import { Component, OnInit } from '@angular/core';
import {QuizeService} from '@app/_services';
import { timeout } from 'q';
import { Router } from '@angular/router';
import {MatProgressBarModule} from '@angular/material/progress-bar';

@Component({
  selector: 'app-result',
  templateUrl: './result.component.html',
  styleUrls: ['./result.component.less']
})
export class ResultComponent implements OnInit {

  loading = false;
  result;
  mistakes = 0;
  Answers;

  constructor(private quizeService: QuizeService, private route: Router) {}

  ngOnInit() {
    this.loading = true;
    this.Answers = this.quizeService.Answers;

    setTimeout(() => {
      this.quizeService.getResultFinal(this.Answers).pipe().subscribe(data => {
        this.result = data;
        this.loading = false;
        for (let value of this.Answers) {
          if (value === false) {
            this.mistakes++;
          }
          console.log("Value: ", value);
      }
      });
    }, 2000);
  }

  retry() {
    this.route.navigate(['/']);
  }

}

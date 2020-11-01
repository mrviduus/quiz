import { Component, OnInit } from '@angular/core';
import {QuizeService} from '@app/_services';
import { from } from 'rxjs';
import {Router} from '@angular/router';

@Component({
  selector: 'app-quiz',
  templateUrl: './quiz.component.html',
  styleUrls: ['./quiz.component.less']
})
export class QuizComponent implements OnInit {

  question: string;
  idQuestions: number;
  variants: Array<string>;
  time = 0;
  interval;
  stop: boolean = false;
  loading: boolean = false;
  leftQuestions: number;


  constructor(private quizeService: QuizeService, private route: Router) { }

  ngOnInit() {
    this.quizeService.Answers = [];
    this.getQuestion();
    this.startTimer();
  }

  getQuestion(){
    let ids = JSON.parse(localStorage.getItem("QuestionsIds"));
    let id;
    if (ids.length !== 0) {
        id = ids.shift();
        localStorage.setItem("QuestionsIds", JSON.stringify(ids));

        this.quizeService.nextQuestions(id).pipe().subscribe(data => {
          let q = JSON.parse(data);
          console.log("Id вопроса: ", q.Id);
          this.idQuestions = q.Id;
          console.log("Вопрос: ", q.Question);
          this.question = q.Question;
          console.log("Ответы: ", q.Variants);
          this.variants = q.Variants;
          console.log(q);
          this.leftQuestions = JSON.parse(localStorage.getItem("QuestionsIds")).length + 1;
      });
    } else {
        console.log("Вопросы закончились");
        return this.route.navigate(['/result']);
    }
  }

  getAnswer(answer){
    this.loading = true;
    setInterval(() => {
      this.loading = false;
    }, 2000);

    console.log("questions is:", this.question);
    console.log("this is Event: ", answer);
    let fullAnswer = {Question: this.idQuestions,
                  Answer: answer };

    let json = JSON.stringify(fullAnswer);

    this.quizeService.getAnswer(json).pipe().subscribe(data =>{
      console.log(data);
      this.quizeService.verdict(data);

    });

    this.getQuestion();
  }

  next(){
    let ids = JSON.parse(localStorage.getItem("QuestionsIds"));
    let id;
    console.log("ids == ", ids);
    if (ids.length !== 0) {
        id = ids.shift();
        localStorage.setItem("QuestionsIds", JSON.stringify(ids));
        console.log("ids after removing", ids);
        return id;
    } else {
        console.log("Вопросы закончились");
        return this.route.navigate(['/result']);
    }

}

startTimer() {
  this.interval = setInterval(() => {
    if(stop) {
      this.time++;
    } else{
      this.interval;
    }
  },1000)
}

}

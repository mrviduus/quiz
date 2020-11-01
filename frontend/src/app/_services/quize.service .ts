import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

import { environment } from '@environments/environment';
import { User, Question } from '@app/_models';

@Injectable({ providedIn: 'root' })
export class QuizeService {
    startId: number;
    data = {};
    questions = {};
    Answers: Array<boolean> = [];



    constructor(private http: HttpClient) { }

    questionsIds() {
        return this.http.get(`${environment.apiUrl}/api/quiz/QuestionsIds`).toPromise().then((data:any) =>{
            localStorage.setItem("QuestionsIds" , JSON.stringify(data));
        });
    }

    nextQuestions(id: number){
        return this.http.get<string>(`${environment.apiUrl}/api/quiz/next?questionId=${id}`);
    }

    getAnswer(json: any){
        return this.http.get<boolean>(`${environment.apiUrl}/api/quiz/Answer?previousQuestionAnswer=${json}`);
    }

    getResultFinal(answ: Array<boolean>){
        let json = JSON.stringify(answ);
        console.log("Массив перед отправкой",json);
        return this.http.get(`${environment.apiUrl}/api/quiz/complete?answers=${json}`);
    }

    verdict(answ: boolean){
        this.Answers.push(answ);
    }


}

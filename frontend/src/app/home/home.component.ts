import { Component } from '@angular/core';
import { first } from 'rxjs/operators';

import { User } from '@app/_models';
import { UserService, AuthenticationService, QuizeService} from '@app/_services';
import {Router} from '@angular/router';
import { createWiresService } from 'selenium-webdriver/firefox';
import {HttpClient} from '@angular/common/http';
import { from } from 'rxjs';

@Component({ templateUrl: 'home.component.html' })
export class HomeComponent {
    loading = false;
    user: User;
    startId: number;
    userName: string;
    RandomQuestionArray: Array<number>;
    step: number;
    RandomQuestionsIds: Array<number>;

    constructor(private userService: UserService, private quizeService: QuizeService, private route: Router) { }

    ngOnInit() {
        this.loading = true;
        this.userService.getAll().pipe(first()).subscribe(user => {
            this.loading = false;
            this.user = user;
            this.userName = user.name;

            console.log(user);
        });
        this.quizeService.questionsIds();
    }


    startQuiz(){
        this.route.navigate(['/quiz']);
    }
}
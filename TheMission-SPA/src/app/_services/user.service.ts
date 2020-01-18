import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { AlertifyService } from './alertify.service';
import { Observable } from 'rxjs';
import { User } from '../_models/user';
import { Skill } from '../_models/skill';


@Injectable({
    providedIn: 'root'
})
export class UserService {
    baseUrl = environment.apiUrl;

constructor(private http: HttpClient, private alertify: AlertifyService) { }

    getUsers(): Observable<User[]> {
        return this.http.get<User[]>(this.baseUrl + 'users');
    }

    getUser(userid: number): Observable<User> {
        return this.http.get<User>(this.baseUrl + 'users/' + userid);
    }

    getSkills(): Observable<Skill[]> {
        return this.http.get<Skill[]>(this.baseUrl + 'skills');
    }

    addSkill(skillName: string, userId: number, skillScore: number) {
        const skillToReturn = {skillName, userId, skillScore};
        return this.http.post(this.baseUrl + 'skills', skillToReturn);
    }
    removeSkill(skill: Skill) {
        return this.http.post(this.baseUrl + 'skills/remove/', skill);
    }

    getUsersWithSkill(skillId: number) {
        return this.http.get(this.baseUrl + 'skills/all/' + skillId);
    }
}

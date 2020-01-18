import { Component, OnInit } from '@angular/core';
import { User } from '../_models/user';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';
import {FormBuilder, FormGroup, ReactiveFormsModule, FormControl, Validators  } from '@angular/forms';
import { AuthService } from '../_services/auth.service';
import { Skill } from '../_models/skill';

@Component({
  selector: 'app-userskill-list',
  templateUrl: './userskill-list.component.html',
  styleUrls: ['./userskill-list.component.css']
})
export class UserskillListComponent implements OnInit {
  skillForm: FormGroup;

  selectedSkill: Skill;
  user: User = {userId: 0, username: ''};
  skillList: Skill[];

  constructor(private userService: UserService, private authService: AuthService,
              private alertify: AlertifyService, private formBuilder: FormBuilder) {}

  ngOnInit() {
    this.loadUser(this.authService.decodedToken.nameid);
    this.loadSkills();

    this.skillForm = this.formBuilder.group({
      skillName: ['', Validators.required],
      score: ['', Validators.required]
    });
  }

  loadUser(userid: number) {
    this.userService.getUser(userid).subscribe((user: User) => {
      this.user = user;
    }, error => {
      this.alertify.error('Problem loading user!');
    });
  }

  loadSkills() {
    this.userService.getSkills().subscribe(skills => {
     this.skillList = skills;
    }, error => {
      this.alertify.error(error);
    });
  }

  skillAdd() {
    const name: string = this.skillForm.value.skillName;
    const skillScore: number = this.skillForm.value.score;

    this.userService.addSkill(name, this.user.userId, skillScore)
      .subscribe(res => {
        this.user.skills.push({
          skillName: name,
          score: skillScore
        });
      }, error => {
        this.alertify.error('Failed to add skill');
      });
    this.skillForm.reset();
  }

  removeSkill(skill: Skill) {
    const index = this.user.skills.indexOf(skill);
    skill.userId = this.authService.decodedToken.nameid;
    console.log(skill);

    this.alertify.confirm('Are you sure you want to remove ' + skill.skillName, () => {
      this.userService.removeSkill(skill)
      .subscribe(() => {
        this.user.skills.splice(index, 1);
      }, error => {
        this.alertify.error(error);
      });
    });

  }

}

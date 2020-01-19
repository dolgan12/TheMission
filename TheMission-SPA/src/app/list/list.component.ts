import { Component, OnInit } from '@angular/core';
import { Skill } from '../_models/skill';
import { UserService } from '../_services/user.service';
import { AlertifyService } from '../_services/alertify.service';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.css']
})
export class ListComponent implements OnInit {
  skillList: Skill[];
  selectedSkill: string;
  scoreList: Skill[];
  skillToShow: any = {};

  constructor(private userService: UserService, private alertify: AlertifyService) { }

  ngOnInit() {
    this.loadSkills();
  }


  loadSkills() {
    this.userService.getSkills().subscribe(skills => {
     this.skillList = skills;
    }, error => {
      this.alertify.error(error);
    });
  }

  skillSearch() {
    if (this.selectedSkill == null) {
      this.alertify.error('No user with that skill yet');
      this.skillToShow = {};
      return;
    }
    let selectedSkillId: number = null;
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.skillList.length; i++) {
      if (this.skillList[i].skillName === this.selectedSkill) {
        selectedSkillId = this.skillList[i].skillId;
      }
    }
    if (selectedSkillId == null) {
      this.alertify.error('No user with that skill yet');
      this.skillToShow = {};
      return;
    }

    this.skillToShow.skillName = this.selectedSkill;
    this.skillToShow.skillId = selectedSkillId;

    this.userService.getUsersWithSkill(selectedSkillId).subscribe((users: []) => {
      if (users.length === 0) {
        this.alertify.error('No user with that skill yet');
        this.skillToShow = {};
        return;
      }
      this.scoreList = users;
      this.skillToShow.users = users;
    }, error => {
      this.alertify.error(error);
    });

    this.selectedSkill = null;
  }
}

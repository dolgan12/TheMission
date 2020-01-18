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
      return;
    }
    let selectedSkillId: number;
    // tslint:disable-next-line: prefer-for-of
    for (let i = 0; i < this.skillList.length; i++) {
      if (this.skillList[i].skillName === this.selectedSkill) {
        selectedSkillId = this.skillList[i].skillId;
      }

    }
    this.userService.getUsersWithSkill(selectedSkillId).subscribe((users: []) => {
      if (users.length === 0) {
        this.alertify.error('No user with that skill yet');
        return;
      }
      this.scoreList = users;
      console.log(users);
    }, error => {
      this.alertify.error(error);
    });

    this.selectedSkill = null;
  }
}

import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module';
import { CandidateSkillRoutingModule } from './candidate-skill-routing.module';
import { CandidateSkillComponent } from './candidate-skill.component';


@NgModule({
  declarations: [
    CandidateSkillComponent
  ],
  imports: [
    SharedModule,
    CandidateSkillRoutingModule
  ]
})
export class CandidateSkillModule { }

import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { CandidateSkillComponent } from './candidate-skill.component';

const routes: Routes = [{ path: '', component: CandidateSkillComponent }];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule]
})
export class CandidateSkillRoutingModule { }

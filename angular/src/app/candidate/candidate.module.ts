import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module' //Already exports the common module
import { CandidateRoutingModule } from './candidate-routing.module';
import { CandidateComponent } from './candidate.component';

@NgModule({
  declarations: [CandidateComponent],
  imports: [
    CandidateRoutingModule,
    SharedModule,
  ]
})
export class CandidateModule { }

import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module' //Already exports the common module
import { CandidateRoutingModule } from './candidate-routing.module';
import { CandidateComponent } from './candidate.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';


@NgModule({
  declarations: [CandidateComponent],
  imports: [
    CandidateRoutingModule,
    SharedModule,
    NgbDatepickerModule,
  ]
})
export class CandidateModule { }

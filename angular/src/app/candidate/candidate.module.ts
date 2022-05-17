import { NgModule } from '@angular/core';
import { SharedModule } from '../shared/shared.module' //Already exports the common module
import { CandidateRoutingModule } from './candidate-routing.module';
import { CandidateComponent } from './candidate.component';
import { NgbDatepickerModule } from '@ng-bootstrap/ng-bootstrap';
import { AngularFileUploaderModule } from 'angular-file-uploader';
import { HttpClientModule } from '@angular/common/http';
import {MatTooltipModule} from '@angular/material/tooltip';


@NgModule({
  declarations: [CandidateComponent],
  imports: [
    CandidateRoutingModule,
    SharedModule,
    NgbDatepickerModule,
    AngularFileUploaderModule,
    HttpClientModule,
    MatTooltipModule
  ]
})
export class CandidateModule { }

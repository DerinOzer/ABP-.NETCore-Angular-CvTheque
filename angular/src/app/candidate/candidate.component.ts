import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CandidateService, CandidateDto } from '@proxy/candidates'; //CandidateService is generated.
import { CvService, CvDto, SaveCvDto} from '@proxy/documents';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';



@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class CandidateComponent implements OnInit {

  candidate = { items: [], totalCount: 0 } as PagedResultDto<CandidateDto>;
  isModalOpen = false;
  form: FormGroup;

  selectedCandidate = {} as CandidateDto;
  cv = {} as CvDto;


  constructor(public readonly list: ListService, private candidateService:CandidateService,private cvService:CvService, private formbuilder: FormBuilder,private confirmation: ConfirmationService) { }

  ngOnInit() {
    const candidateStreamCreator = (query) => this.candidateService.getList(query);
    this.list.hookToQuery(candidateStreamCreator).subscribe((response) => {this.candidate = response;});
  }

  uploadFile(cvToUpload:SaveCvDto){
    cvToUpload.name = this.selectedCandidate.id;
    this.cvService.saveCv(cvToUpload);
  }

  deleteCandidate(id:string){
    this.confirmation.warn('::AreYouSureToDelete', '::AreYouSure').subscribe((status) => {if (status === Confirmation.Status.confirm) {this.candidateService.delete(id).subscribe(()=>this.list.get())}});
  }

  createCandidate() {
    this.selectedCandidate = {} as CandidateDto;
    this.buildForm();
    this.isModalOpen = true;
  }

  editCandidate(id: string){
    this.candidateService.get(id).subscribe((candidate)=>{
      this.selectedCandidate=candidate;
      this.buildForm();
      this.isModalOpen = true;
    })
  }

  
  buildForm(){
    this.form = this.formbuilder.group({
      name:[this.selectedCandidate.name, Validators.required],
      lastName:[this.selectedCandidate.lastName, Validators.required],
      email:[this.selectedCandidate.email, Validators.required],
      availability: [this.selectedCandidate.availability ? new Date(this.selectedCandidate.availability) : null],
      noticeDuration:[this.selectedCandidate.noticeDuration],
      lastContact:[this.selectedCandidate.lastContact ? new Date(this.selectedCandidate.lastContact) : null],
      currentSalary:[this.selectedCandidate.currentSalary],
      requestedSalary:[this.selectedCandidate.requestedSalary],
    });
  }

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedCandidate.id?this.candidateService.update(this.selectedCandidate.id, this.form.value):this.candidateService.create(this.form.value);

    request.subscribe(()=>{this.isModalOpen=false; this.form.reset(); this.list.get();});
    
  }

}

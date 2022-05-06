import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CandidateService, CandidateDto } from '@proxy/entities'; //CandidateService is generated.
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { formatDate } from '@angular/common' ;



@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss'],
  providers: [ListService],
})
export class CandidateComponent implements OnInit {

  candidate = { items: [], totalCount: 0 } as PagedResultDto<CandidateDto>;
  isModalOpen = false;
  form: FormGroup;

  selectedCandidate = {} as CandidateDto;

  
  //listFinal = [];


  constructor(public readonly list: ListService, private candidateService:CandidateService, private formbuilder: FormBuilder,private confirmation: ConfirmationService) { }

  ngOnInit() {
    const candidateStreamCreator = (query) => this.candidateService.getList(query);
    this.list.hookToQuery(candidateStreamCreator).subscribe((response) => {this.candidate = response;});
    //this.sortByLastName();
  }

  /*sortByLastName(){
    var sorted = [];
    for (let i = 0; i < this.list.maxResultCount; i++){
      sorted.push(this.list[i]);
    }
    for (let j = 0; j < this.list.maxResultCount; j++){
      this.listFinal[j] = sorted.sort((a, b) => (b.lastName < a.lastName ? 1 : b.lastName > a.lastName ? -1 : 0))[j];
    }
    console.log(this.listFinal);
  }*/

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
    var dateAvailability = '';
    var dateContact = '';
    if (typeof this.selectedCandidate.availability == 'string'){
      dateAvailability = formatDate(this.selectedCandidate.availability,'yyyy-MM-dd','en');
    }
    if (typeof this.selectedCandidate.lastContact == 'string'){
      dateContact = formatDate(this.selectedCandidate.lastContact,'yyyy-MM-dd','en')
    }

    this.form = this.formbuilder.group({
      name:[this.selectedCandidate.name, Validators.required],
      lastName:[this.selectedCandidate.lastName, Validators.required],
      email:[this.selectedCandidate.email, Validators.required],
      availability: [dateAvailability],
      noticeDuration:[this.selectedCandidate.noticeDuration],
      lastContact:[dateContact],
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

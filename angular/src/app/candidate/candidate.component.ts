import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CandidateService, CandidateDto} from '@proxy/candidates'; //CandidateService is generated.
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';
import { DownloadService } from '../download.service';
import { DatePipe } from '@angular/common';


@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss'],
  providers: [DatePipe, ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class CandidateComponent implements OnInit {

  candidate = { items: [], totalCount: 0 } as PagedResultDto<CandidateDto>;
  candidateCreate = {} as CandidateDto;
  candidateEdit = {} as CandidateDto;
  isModalOpen = false;
  form: FormGroup;
  selectedCandidate = {} as CandidateDto;


  constructor(private datePipe: DatePipe, private downloads:DownloadService, public readonly list: ListService, private candidateService:CandidateService, private formbuilder: FormBuilder,private confirmation: ConfirmationService, private httpClient: HttpClient) { }

  ngOnInit() {
    const candidateStreamCreator = (query) => this.candidateService.getList(query);
    this.list.hookToQuery(candidateStreamCreator).subscribe((response) => {this.candidate = response;});
  }
  
  formatDateAdded(date:string){
    return date=this.datePipe.transform(date, 'dd/MM/yyyy');
  }

  download(id: string): void
  {
      this.downloads.downloadFile(id).subscribe((blob: Blob): void => {
      const file = new Blob([blob], {type: 'application/pdf'});
      const fileURL = URL.createObjectURL(file);
      window.open(fileURL, '_blank', 'width=1000, height=800');
    });
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
    console.log(id);
    this.candidateService.get(id).subscribe((candidateEdit)=>{
      console.log(candidateEdit);
      this.selectedCandidate=candidateEdit;
      this.buildForm();
      this.isModalOpen = true;
    })
  }

  onFileSelect(event) {
    if (event.target.files.length > 0) {
      const file = event.target.files[0];
      this.form.get('file').setValue(file);
    }
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
      file:['']
    });
  }

  uploadFile(id:string){
    const formData = new FormData();
    var SERVER_URL =  `https://localhost:44310/api/app/cv/${id}/upload-cv`;
    formData.append('file', this.form.get('file').value);
    return this.httpClient.post<any>(SERVER_URL,formData);
  }

  save() {
    if (this.form.invalid) {
      return;
    }
    
    if(this.selectedCandidate.id){
      this.candidateService.update(this.selectedCandidate.id, this.form.value).subscribe(()=>{
        if(this.form.get('file').value){
          this.uploadFile(this.selectedCandidate.id).subscribe(()=>{
            this.isModalOpen=false; 
            this.form.reset(); 
            this.list.get();});
        }});
    }
    else{
      this.candidateService.create(this.form.value).subscribe((candidateCreate)=>{
        
        if(this.form.get('file').value){
          this.uploadFile(candidateCreate.id).subscribe(()=>{
            this.isModalOpen=false; 
            this.form.reset(); 
            this.list.get();});
        }});
    }
  }

}

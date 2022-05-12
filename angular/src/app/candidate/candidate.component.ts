import { Component, OnInit } from '@angular/core';
import { ListService, PagedResultDto } from '@abp/ng.core';
import { CandidateService, CandidateDto } from '@proxy/candidates'; //CandidateService is generated.
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ConfirmationService, Confirmation } from '@abp/ng.theme.shared';
import { NgbDateNativeAdapter, NgbDateAdapter } from '@ng-bootstrap/ng-bootstrap';
import { HttpClient } from '@angular/common/http';




@Component({
  selector: 'app-candidate',
  templateUrl: './candidate.component.html',
  styleUrls: ['./candidate.component.scss'],
  providers: [ListService, { provide: NgbDateAdapter, useClass: NgbDateNativeAdapter }],
})
export class CandidateComponent implements OnInit {

  candidate = { items: [], totalCount: 0 } as PagedResultDto<CandidateDto>;
  isModalOpen = false;

  SERVER_URL =  "https://localhost:44310/api/app/cv/upload-cv"
  form: FormGroup;

  selectedCandidate = {} as CandidateDto;
  num = 1234 as Number;



  constructor(public readonly list: ListService, private candidateService:CandidateService, private formbuilder: FormBuilder,private confirmation: ConfirmationService, private httpClient: HttpClient) { }

  ngOnInit() {
    const candidateStreamCreator = (query) => this.candidateService.getList(query);
    this.list.hookToQuery(candidateStreamCreator).subscribe((response) => {this.candidate = response;});
  }

  /*uploadFile(cvToUpload:SaveCvDto){
    cvToUpload.name = this.selectedCandidate.id;
    this.cvService.saveCv(cvToUpload);
  }*/

  /*uploadFile(){
      this.form.a
      document.querySelector('.form-control-file').addEventListener('change', function(e){
        var file = document.getElementById("myInput").files[0].name;
      })
      ddEventListener('submit', (event) => {
      event.preventDefault()
      const formattedFormData = new FormData(form)
      const data = formattedFormData.get('upload-file')!
    
      if (data instanceof File) {
        console.log('filename: ', data['name']);
      }
    })
    this.cvService.uploadCv(File, this.selectedCandidate.id);
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

  afuConfig = {
    uploadAPI:{
      url:`https://localhost:44310/api/app/cv/upload-cv`
    }
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

  save() {
    if (this.form.invalid) {
      return;
    }

    const request = this.selectedCandidate.id?this.candidateService.update(this.selectedCandidate.id, this.form.value):this.candidateService.create(this.form.value);
    const formData = new FormData();
    formData.append('file', this.form.get('file').value);
    this.httpClient.post<any>(this.SERVER_URL,formData).subscribe((res) => console.log(res), (err) => console.log(err));
    request.subscribe(()=>{this.isModalOpen=false; this.form.reset(); this.list.get();});
    
    
  }

}

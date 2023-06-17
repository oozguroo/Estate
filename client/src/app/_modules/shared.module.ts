import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { BsDropdownModule } from 'ngx-bootstrap/dropdown';
import { ToastrModule } from 'ngx-toastr';
import { FileUploadModule } from 'ng2-file-upload';
import { TabsModule } from 'ngx-bootstrap/tabs';
import { PaginationModule } from 'ngx-bootstrap/pagination';


@NgModule({
  declarations: [],
  imports: [
    CommonModule,
    FileUploadModule,
   TabsModule.forRoot(),
   PaginationModule.forRoot(),
    BsDropdownModule.forRoot(),
    ToastrModule.forRoot({
      positionClass:'toast-bottom-right'
    })
  ],
  exports:[
    BsDropdownModule,
    ToastrModule,
    PaginationModule,
    FileUploadModule,
    TabsModule
  ]
})
export class SharedModule {}

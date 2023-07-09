import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HTTP_INTERCEPTORS, HttpClientModule} from '@angular/common/http'

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { NavComponent } from './nav/nav.component';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { AdsListComponent } from './ads/ads-list/ads-list.component';
import { AdsDetailComponent } from './ads/ads-detail/ads-detail.component';
import { AdsEditComponent } from './ads/ads-edit/ads-edit.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { AdsCardComponent } from './ads/ads-card/ads-card.component';
import { AdsPhotoComponent } from './ads/ads-photo/ads-photo.component';
import { MessagesComponent } from './messages/messages.component';
import { MemberLoginComponent } from './members/member-login/member-login.component';
import { SharedModule } from './_modules/shared.module';
import { ErrorInterceptor } from './_interceptors/error.interceptor';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { AdsNewComponent } from './ads/ads-new/ads-new.component';
import { TextInputComponent } from './_forms/text-input/text-input.component';
import { MemberLikesComponent } from './members/member-likes/member-likes.component';
import { JwtInterceptor } from './_interceptors/jwt.interceptor';
import { MemberMessagesComponent } from './members/member-messages/member-messages.component';




@NgModule({
  declarations: [
    AppComponent,
    NavComponent,
    HomeComponent,
    RegisterComponent,
    AdsListComponent,
    AdsDetailComponent,
    AdsEditComponent,
    MemberDetailComponent,
    MemberEditComponent,
    AdsCardComponent,
    AdsPhotoComponent,
    MessagesComponent,
    MemberLoginComponent,
    NotFoundComponent,
    ServerErrorComponent,
    TestErrorComponent,
    AdsNewComponent,
    TextInputComponent,
    MemberLikesComponent,
    MemberMessagesComponent
   

  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    BrowserAnimationsModule,
    SharedModule,
    ReactiveFormsModule
    
    
  ],
  providers: [
    {provide: HTTP_INTERCEPTORS, useClass: ErrorInterceptor, multi:true},
    {provide: HTTP_INTERCEPTORS, useClass: JwtInterceptor, multi:true}
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }

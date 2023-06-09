import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { AdsListComponent } from './ads/ads-list/ads-list.component';
import { AdsDetailComponent } from './ads/ads-detail/ads-detail.component';
import { MessagesComponent } from './messages/messages.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { RegisterComponent } from './register/register.component';
import { MemberLoginComponent } from './members/member-login/member-login.component';
import { AuthGuard } from './_guards/auth.guard';
import { NotFoundComponent } from './errors/not-found/not-found.component';
import { ServerErrorComponent } from './errors/server-error/server-error.component';
import { TestErrorComponent } from './errors/test-error/test-error.component';
import { AdsNewComponent } from './ads/ads-new/ads-new.component';
import { AdsEditComponent } from './ads/ads-edit/ads-edit.component';
import { MemberLikesComponent } from './members/member-likes/member-likes.component';

const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'ads', component: AdsListComponent },
  { path: 'ads/:id', component: AdsDetailComponent },
 
  { path: 'list', component: AdsListComponent },
  { path: 'login', component: MemberLoginComponent },
  { path: 'register', component: RegisterComponent },
  {path: 'members/:username', component: MemberDetailComponent},
  
  { path: 'new', component: AdsNewComponent },
  {
    path: '',
    runGuardsAndResolvers: 'always',
    canActivate: [AuthGuard],
    children: [
      { path: 'messages', component: MessagesComponent },
      { path: 'edit', component: MemberEditComponent },
      { path: 'edit/:id', component: AdsEditComponent },
      { path: 'liked/:id', component: MemberLikesComponent },
    ],
  },
  {path: 'not-found', component: NotFoundComponent},
  {path: 'server-error', component: ServerErrorComponent},
  {path: 'test-error', component: TestErrorComponent},
  { path: '**', component: NotFoundComponent, pathMatch: 'full' },
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {}

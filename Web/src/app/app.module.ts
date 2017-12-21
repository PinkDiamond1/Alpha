import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FlexLayoutModule } from '@angular/flex-layout';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpModule } from '@angular/http';
import { AppRoutingModule } from './/app-routing.module';
import { LoginComponent } from './components/account/login/login.component';
import { LoginService } from './services/login.service';
import { HttpService } from './services/http.service';
import { HttpClientModule } from '@angular/common/http';
import { WizardComponent } from './components/register/wizard/wizard.component';
import { GoalStepComponent } from './components/register/goal-step/goal-step.component';
import { PeriodStepComponent } from './components/register/period-step/period-step.component';
import { AmountStepComponent } from './components/register/amount-step/amount-step.component';
import { RiskStepComponent } from './components/register/risk-step/risk-step.component';
import { MatModule } from './/mat.module';

import { AppComponent } from './app.component';
import { AccountService } from './services/account.service';
import { StepperComponent } from './components/ui/stepper/stepper.component';
import { RegisterStepComponent } from './components/register/register-step/register-step.component';
import { ForgotPasswordEmailComponent } from './components/account/forgot-password-email/forgot-password-email.component';
import { ForgotPasswordResetComponent } from './components/account/forgot-password-reset/forgot-password-reset.component';
import { AdvisorDetailComponent } from './components/advice/advisor-detail/advisor-detail.component';
import { AdvisorsComponent } from './components/advice/advisors/advisors.component';
import { AdviceService } from './services/advice.service'; 


@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    GoalStepComponent,
    PeriodStepComponent,
    AmountStepComponent,
    RiskStepComponent,
    WizardComponent,
    StepperComponent,
    RegisterStepComponent,
    ForgotPasswordEmailComponent,
    ForgotPasswordResetComponent,
    AdvisorDetailComponent,
    AdvisorsComponent
  ],
  imports: [
    BrowserModule,
    BrowserAnimationsModule,
    MatModule,
    FormsModule,
    ReactiveFormsModule,
    HttpModule,
    HttpClientModule,
    AppRoutingModule,
    FlexLayoutModule
  ],
  providers: [LoginService, HttpService, AccountService, AdviceService],
  bootstrap: [AppComponent]
})
export class AppModule { }

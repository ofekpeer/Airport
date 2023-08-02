import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import {HttpClientModule} from '@angular/common/http';
import { AppComponent } from './app.component';
import { TerminalComponent } from './component/terminal/terminal.component';
import { TerminalsComponent } from './component/terminals/terminals.component';
import { FlightComponent } from './component/flight/flight.component';
import { LoggersComponent } from './component/loggers/loggers.component';

@NgModule({
  declarations: [
    AppComponent,
    TerminalComponent,
    TerminalsComponent,
    FlightComponent,
    LoggersComponent
  ],
  imports: [
    BrowserModule,
    HttpClientModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }

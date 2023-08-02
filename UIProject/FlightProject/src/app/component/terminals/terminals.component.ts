import { Component } from '@angular/core';
import { Terminal } from 'src/app/models/Terminal';
import { FlightServiesService } from 'src/app/servies/flight/flight.servies.service';

@Component({
  selector: 'terminals',
  templateUrl: './terminals.component.html',
  styleUrls: ['./terminals.component.css']
})
export class TerminalsComponent {

  Terminals: Terminal[]= []

  constructor(private terminalService: FlightServiesService){
    this.terminalService.get().subscribe((data)=>{
        this.Terminals = data as Terminal[];
    })
  }
}



import { Component } from '@angular/core';
import { Logger } from 'src/app/models/Logger';
import { LoggerServiesService } from 'src/app/servies/logger/logger.servies.service';
@Component({
  selector: 'loggers',
  templateUrl: './loggers.component.html',
  styleUrls: ['./loggers.component.css']
})
export class LoggersComponent {

  loggers?: Logger[] = []
  seconds = 2;

  constructor(private loggerService: LoggerServiesService) {
  }

  GetData = () => {
    this.loggerService.get().subscribe((data) => {
      let dataFromDb = data as Logger[];
      if (dataFromDb.length < this.loggers?.length!) {
        this.loggers = dataFromDb;
      }
      else {
        let addLines = dataFromDb.length - this.loggers?.length!;
        dataFromDb.slice(dataFromDb.length - addLines, dataFromDb.length).forEach(i => this.loggers?.push(i));
      }
      dataFromDb.forEach(i => {
        this.loggers?.forEach(t => {
          if (i.id == t.id && i.out != t.out) {
            t.out = i.out;
          }
        })
      })
    })
  }

  intervalID = setInterval(() => { this.GetData(); }, this.seconds * 1000)
}
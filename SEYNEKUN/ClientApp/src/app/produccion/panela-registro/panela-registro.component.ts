import { Component, OnInit } from '@angular/core';
import { Panela } from '../models/panela';
import { PanelaService } from 'src/app/services/panela.service';

@Component({
  selector: 'app-panela-registro',
  templateUrl: './panela-registro.component.html',
  styleUrls: ['./panela-registro.component.css']
})
export class PanelaRegistroComponent implements OnInit {

  panela:Panela;
  constructor(private panelaService: PanelaService) { }

  ngOnInit() {
    this.panela= new  Panela();
  }

  add() {
    this.panelaService.post(this.panela).subscribe(p => {
      if (p != null) {
        alert('panela creada!');
        this.panela = p;
      }
    });
  }
}

  

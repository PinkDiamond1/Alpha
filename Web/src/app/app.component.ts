import { Component, OnInit } from '@angular/core';
import { Http } from '@angular/http'
import { NotificationsService } from "angular2-notifications";
import { Web3Service } from "./services/web3.service";

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {

  public notificationOptions = {
    position: ["bottom", "left"],
    timeOut: 2500,
    maxStack: 1,
    preventDuplicates: true,
    preventLastDuplicates: "visible"
  }

  constructor(private _httpService: Http, private web3 : Web3Service) { 
    
  }

  apiValues: string[] = [];

  ngOnInit() {
  }
}

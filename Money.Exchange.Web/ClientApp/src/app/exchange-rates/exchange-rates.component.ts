import { Component, OnInit } from '@angular/core';
import { ExchangeService } from '../services/exchange.service';
import { ExchangeRate } from '../interfaces/exchange-rate';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-exchange-rates',
  templateUrl: './exchange-rates.component.html',
  styleUrls: ['./exchange-rates.component.css']
})
export class ExchangeRatesComponent implements OnInit {

  API_URL: string = 'https://localhost:44366/api/exchange';
  exchangesRates;
  USD;
  rate = 0;
  EUR;
  exchangeRate;

  constructor(private http: HttpClient, private router: Router) { } //private exService : ExchangeService

  ngOnInit() {
    this.getExchangesRates();
  }

  calculateExchangeRate(evt) {
    this.exchangeRate = this.http.get(this.API_URL + '/getexchangeratesbyid?idrate=' + 1).subscribe(
      result => {
        this.rate = result.rate
        this.EUR = this.USD * this.rate;
        console.log('EUR: ' + this.EUR)
    }, error => console.error(error));
  }

  getExchangesRates() {
    return this.http.get(this.API_URL + '/getexchangerates').subscribe(result => {
      this.exchangesRates = result;
    }, error => console.error(error));
  }

}

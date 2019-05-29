import { Injectable } from '@angular/core';
import { ExchangeRate } from '../interfaces/exchange-rate';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class ExchangeService {

  API_URL: string = 'https://localhost:44366/api/exchange/getexchangerates';
  data;
  baseUrl: string;

  constructor(private http: HttpClient) { }

  getExchangesRates(){
    return this.http.get(this.API_URL).subscribe();
  }
}

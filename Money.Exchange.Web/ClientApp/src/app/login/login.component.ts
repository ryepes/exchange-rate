import { Component, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  API_URL: string = 'https://localhost:44366/api/login';
  userName = '';
  password = '';
  errorMessage = '';

  constructor(private http: HttpClient, private router: Router) {
    var user = sessionStorage.getItem('userName');

    console.log('ExchangeRatesComponent')

    if(!user){
      this.router.navigate(['/login']);
    } 
    console.log('LoginComponent')
  }

  ngOnInit() {
    console.log('LoginComponent 222')
    sessionStorage.removeItem('userName');
    sessionStorage.clear();
  }

  loginUser(evt) {  
    var params = '?user=' + this.userName + '&password=' + this.password;
    this.http.get(this.API_URL + '/loginUser' + params).subscribe(result => {
        if (result) {
          sessionStorage.setItem('userName', "ok");
          this.router.navigate(['/']);
        } else {
          this.errorMessage = 'Please, verify user or password';
          sessionStorage.removeItem('userName');
          this.router.navigate(['/login']);
        }
      }, error => console.error(error));    
  }

}

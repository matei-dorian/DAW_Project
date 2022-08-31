import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { HttpClient } from '@angular/common/http';
import { DataService } from 'src/app/services/Account/data.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {

  public loginUrl: string = "https://localhost:44337/api/Auth/Login";
  public loginFailed: boolean = false;
  public loginForm: FormGroup =  new FormGroup({
    email: new FormControl(''),
    password: new FormControl('')
  });

  constructor(
    private router : Router,
    private dataService : DataService,
    public http: HttpClient) { }

  get email(): AbstractControl | null{
    return this.loginForm.get('email');
  }

  get password(): AbstractControl | null{
    return this.loginForm.get('password');
  }

  ngOnInit(): void {
  }

  public register(): void {
    this.router.navigate(['/auth/register']);
  }

  public login(): void {
    this.dataService.loginUser(this.loginForm.value).subscribe({
      next: (_) => {
          if(this.loginForm.value['username'] === 'nastasematei@gmail.com')
            localStorage.setItem("Role", "Admin");
          else
            localStorage.setItem("Role", "Customer");
          this.dataService.changeUserData(this.loginForm.value);
          this.router.navigate(['/shoes']);
          },
      error: (_) => {
          this.loginFailed = true;
          console.log('Wrong credentials');
          }
   });
  } 
}

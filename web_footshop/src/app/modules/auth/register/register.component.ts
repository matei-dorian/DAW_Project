import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { AbstractControl, FormControl, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';
import { DataService } from 'src/app/services/Account/data.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.scss']
})
export class RegisterComponent implements OnInit {

  public registerForm: FormGroup =  new FormGroup({
    firstName: new FormControl(''),
    lastName: new FormControl(''),
    email: new FormControl(''),
    password: new FormControl(''),
    role: new FormControl('Customer')
  });
  
  constructor(private router : Router,
    public dataService: DataService) { }

  get firstName(): AbstractControl | null{
    return this.registerForm.get('firstName');
  }

  get lastName(): AbstractControl | null{
    return this.registerForm.get('lastName');
  }

  get password(): AbstractControl | null{
    return this.registerForm.get('password');
  }

  get email(): AbstractControl | null{
    return this.registerForm.get('email');
  }

  ngOnInit(): void {
  }

  public createUser(): void {
    this.dataService.registerUser(this.registerForm.value).subscribe({
      next: (_) => {
        this.router.navigate(['/auth/login']);
          },
      error: (_) => {
          console.log('Error at registering user');
          }
   });
  }

}

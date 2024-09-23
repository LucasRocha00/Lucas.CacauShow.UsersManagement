import { Component } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { AuthService } from '../login.service';
import { Router } from '@angular/router';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html'
})
export class LoginComponent {
  loginForm: FormGroup;

  constructor(private fb: FormBuilder, private authService: AuthService, private router: Router) {
    this.loginForm = this.fb.group({
      login: ['', Validators.required],
      password: ['', Validators.required]
    });
  }

  onSubmit() {
    if (this.loginForm.valid) {
      const { login, password } = this.loginForm.value;

      this.authService.login(login, password).subscribe(
        response => {
          localStorage.setItem('token', response.token);
          this.router.navigate(['/users']);
        },
        error => {
          Swal.fire({
            title: 'Erro no logon!',
            text: 'Verifique o loging e senha digitados!',
            icon: 'error',
            confirmButtonText: 'Ok'
          });
        }
      );
    }
  }
}

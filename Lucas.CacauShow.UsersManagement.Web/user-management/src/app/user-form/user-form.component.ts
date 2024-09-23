import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-form',
  templateUrl: './user-form.component.html'
})
export class UserFormComponent implements OnInit {
  userForm: FormGroup;
  userId!: number;
  name: string = '';
  email: string = '';
  login: string = '';
  cpf: string = '';

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private fb: FormBuilder,
    public router: Router
  ) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]],
      login: ['', [Validators.required]],
      cpf: ['', [Validators.required]]
    });
  }

  ngOnInit(): void {
    this.userId = +this.route.snapshot.paramMap.get('id')!;
    this.loadUser();
  }

  loadUser(): void {
    this.userService.getUserById(this.userId).subscribe(user => {
      this.userForm.patchValue(user);
    });
  }

  voltar(): void {
    this.router.navigate(['/users']);
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      if (this.userId) {
        this.userService.updateUser(this.userId, this.userForm.value).subscribe(() => {
          Swal.fire({
            title: 'Sucesso!',
            text: 'Usuário alterado com sucesso!',
            icon: 'success',
            confirmButtonText: 'Ok'
          });
          this.router.navigate(['/users']);
        });
      }
      else {
        this.userService.createUser(this.userForm.value).subscribe(() => {
          Swal.fire({
            title: 'Sucesso!',
            text: 'Usuário criado com sucesso!',
            icon: 'success',
            confirmButtonText: 'Ok'
          });
          this.router.navigate(['/users']);
        });
      }
    }
  }
}

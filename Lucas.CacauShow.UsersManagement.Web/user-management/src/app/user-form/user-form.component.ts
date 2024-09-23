import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { UserService } from '../user.service';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

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
      login: ['', [Validators.required, Validators.email]],
      cpf: ['', [Validators.required, Validators.email]]
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
      console.log('Usuário atualizado:', this.userForm.value);
    }
  }
}

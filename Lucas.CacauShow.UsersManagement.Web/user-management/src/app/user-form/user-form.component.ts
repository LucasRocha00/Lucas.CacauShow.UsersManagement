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

  constructor(
    private route: ActivatedRoute,
    private userService: UserService,
    private fb: FormBuilder,
    public router: Router
  ) {
    this.userForm = this.fb.group({
      name: ['', Validators.required],
      email: ['', [Validators.required, Validators.email]]
    });
  }

  ngOnInit(): void {
    this.userId = +this.route.snapshot.paramMap.get('id')!;
    this.loadUser();
  }

  loadUser(): void {
    this.userService.getUserById(this.userId).subscribe(user => {
      this.userForm.patchValue(user); // Preenche o formulário com os dados do usuário
    });
  }

  onSubmit(): void {
    if (this.userForm.valid) {
      // Chame o serviço para atualizar o usuário
      // this.userService.updateUser(this.userId, this.userForm.value).subscribe(() => {
      //   this.router.navigate(['/']); // Redirecione após a edição
      // });
      console.log('Usuário atualizado:', this.userForm.value); // Remova isso quando implementar a atualização
    }
  }
}

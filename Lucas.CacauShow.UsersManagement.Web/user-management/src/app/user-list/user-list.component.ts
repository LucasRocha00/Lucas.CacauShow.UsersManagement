import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { UserService } from '../user.service';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-user-list',
  templateUrl: './user-list.component.html'
})
export class UserListComponent implements OnInit {
  users: any[] = [];
  loading: boolean = true;
  error: string | null = null;

  constructor(private userService: UserService, private router: Router) { }

  ngOnInit(): void {
    this.loadUsers();
  }

  loadUsers(): void {
    this.userService.getUsers().subscribe(
      (data) => {
        this.users = data;
        this.loading = false;
      },
      (error) => {
        console.error('Erro ao buscar usuários', error);
        this.error = 'Não foi possível carregar os usuários.';
        this.loading = false;
      }
    );
  }

  editUser(user: any): void {
    this.router.navigate(['/edit', user.id]);
  }

  newUser(): void {
    this.router.navigate(['/add-user']);
  }

  deleteUser(userId: number): void {

    Swal.fire({
      title: "Tem certeza que deseja excluir este usuário?",
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: "Sim",
      denyButtonText: `Não`
    }).then((result) => {
      if (result.isConfirmed) {
        this.userService.deleteUser(userId).subscribe(() => {
          this.loadUsers();
        });

        Swal.fire({
          title: 'Sucesso!',
          text: 'Usuário excluído!',
          icon: 'success',
          confirmButtonText: 'Ok'
        });

      }
    });
  }
}

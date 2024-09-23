import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router'; // Adicione o Router
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
    this.router.navigate(['/edit', user.id]); // Navega para a página de edição
  }

  deleteUser(userId: number): void {

    Swal.fire({
      title: "Tem certeza que deseja excluir este usuário?",
      showDenyButton: true,
      showCancelButton: true,
      confirmButtonText: "Sim",
      denyButtonText: `Não`
    }).then((result) => {
      /* Read more about isConfirmed, isDenied below */
      if (result.isConfirmed) {
        // Chame o método do serviço para deletar o usuário
        this.userService.deleteUser(userId).subscribe(() => {
          this.loadUsers(); // Recarregue a lista de usuários
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

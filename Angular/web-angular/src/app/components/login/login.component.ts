import { Component } from '@angular/core';
import { Router } from '@angular/router';
import { Usuario } from 'src/app/models/usuario/usuario';
import { AutenticacaoService } from 'src/app/services/autenticacao/autenticacao.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent {

  usuario: Usuario;

  constructor(private autenticacaoService: AutenticacaoService, private router: Router) {
    this.usuario = new Usuario();
   }

  logar(usuario: string, senha: string): void {
    if (this.autenticacaoService.logar(usuario, senha)) {
      alert('Usuário logado com sucesso!');
      this.goToHome();
    } else {
      alert('Usuário e/ou senha Inválidos');
    }
  }

  goToHome(): void {
    this.router.navigate(['home']);
  }

  deslogar(): void {
    this.autenticacaoService.deslogar();
  }

}

import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class AutenticacaoService {

  autenticado: boolean = false;

  constructor() { }

  logar(usuario: string, senha: string): boolean {
    if (usuario === 'a' && senha === 'b') {
      this.autenticado = true;
      return true;
    }
    this.autenticado = false;
    return false;
  }

  estaAutenticado(): boolean {
    return this.autenticado;
  }

  deslogar(): void {
    this.autenticado = false;
    alert('Usuário deslogado com sucesso!');
  }

}

import { Injectable } from '@angular/core';
import { CanActivate, Router, ActivatedRouteSnapshot, RouterStateSnapshot, UrlTree } from '@angular/router';
import { Observable } from 'rxjs';
import { AutenticacaoService } from '../services/autenticacao/autenticacao.service';

@Injectable({
  providedIn: 'root',
})
export class AutenticacaoGuard implements CanActivate {
  constructor(
    private autenticacaoService: AutenticacaoService,
    private router: Router) { }

  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    return this.autenticacaoService.estaAutenticado();
  }

}

import { Component, OnInit } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { Veiculo } from 'src/app/models/veiculo.model';
import { VeiculoService } from 'src/app/services/veiculo/veiculo.service';

@Component({
  selector: 'app-veiculo-create',
  templateUrl: './veiculo-create.component.html',
  styleUrls: ['./veiculo-create.component.css']
})
export class VeiculoCreateComponent implements OnInit {

  veiculo: Veiculo;

  constructor(private router: Router, private route: ActivatedRoute, private veiculoService: VeiculoService) {
    this.veiculo = new Veiculo();
  }

  ngOnInit(): void {
  }

  post(): void {
    this.veiculoService.post(this.veiculo)
      .pipe(take(1))
      .subscribe({
        next: veiculo => this.handleResponseVeiculo(veiculo),
        error: error => this.handleResponseError(error.status)
      });
    }

  handleResponseVeiculo(veiculo: Veiculo): void {
    this.veiculo = veiculo;
    this.exibirMensagemSucesso();
    this.goToIndex();
  }

  exibirMensagemSucesso(): void {
    alert('Veículo cadastrado com sucesso!');
  }

  handleResponseError(error: number): void {
    this.exibirMensagemErro(error);
  }

  exibirMensagemErro(error: number): void {
    let mensagem: string = '';
    if (error === 404 || error === 400) {
      mensagem = 'Erro ao cadastrar veículo. Verifique os campos obrigatórios e tente novamente.';
    } else {
      mensagem = 'Erro ao cadastrar veículo, entre em contato com o suporte';
    }
    alert(mensagem);
  }

  goToIndex(): void {
    this.router.navigate(['veiculo/veiculo-index']);
  }

  back(): void {
    this.goToIndex();
  }

}

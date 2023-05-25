import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { take } from 'rxjs';
import { Veiculo } from 'src/app/models/veiculo.model';
import { VeiculoService } from 'src/app/services/veiculo/veiculo.service';

@Component({
  selector: 'app-veiculo-index',
  templateUrl: './veiculo-index.component.html',
  styleUrls: ['./veiculo-index.component.css']
})
export class VeiculoIndexComponent implements OnInit {
  
  veiculos: Veiculo[];
  codigoPesquisa: string;

  constructor(private router: Router, private veiculoService: VeiculoService) {
    this.veiculos = new Array<Veiculo>();
    this.codigoPesquisa = '';
  }
  ngOnInit(): void {
    
  }

  get(): void {
    this.veiculos =[]
    if (this.codigoPesquisa == '') {
      this.getAll();
    } else {
      this.getById(Number(this.codigoPesquisa));
    }
  }

  getAll(): void {
    this.veiculoService.getAll()
      .pipe(take(1))
      .subscribe({
        next: veiculos => this.handleResponseVeiculos(veiculos),
        error: error => this.handleResponseError(error.status)
      });
  }

  handleResponseVeiculos(veiculos: Veiculo[]): void {
    veiculos.forEach(veiculo => {
      veiculo.DataFabricacao = veiculo.DataFabricacao.substring(0, 10); // yyyy-MM-dd
    });
    this.veiculos = veiculos;
  }

  getById(id: number): void {
    this.veiculoService.getById(id)
      .pipe(take(1))
      .subscribe({
        next: veiculo => this.handleResponseVeiculo(veiculo),
        error: error => this.handleResponseError(error.status)
      });
  }

  handleResponseVeiculo(veiculo: Veiculo): void {
    veiculo.DataFabricacao = veiculo.DataFabricacao.substring(0, 10); // yyyy-MM-dd
    this.veiculos.push(veiculo);
  }

  handleResponseError(error: number): void {
    this.exibirMensagemErro(error);
  }

  exibirMensagemErro(error: number): void {
    let mensagem: string = '';
    if (error == 404 || error == 400) {
      mensagem = "Veículo não encontrado";
    } else {
      mensagem = "Erro ao buscar veículo, entre em contato com o suporte";
    }
    alert(mensagem);
  }

  create(): void {
    this.router.navigate(['/veiculo/veiculo-create']);
  }

  editar(id: number): void {
    this.router.navigate(['/veiculo/veiculo-edit', id]);
  }

  excluir(id: number): void {
    this.veiculoService.delete(id)
      .pipe(take(1))
      .subscribe({
        next: () => this.get(),
        error: error => this.handleResponseError(error.status)
      });
  }

  desejaExcluir(id: number): void {
    if (confirm("Deseja excluir o veículo de código " + id + "?")) {
      this.excluir(id);
    }
  }

}

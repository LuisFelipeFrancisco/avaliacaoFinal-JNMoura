import { Component } from '@angular/core';
import { Router, ActivatedRoute } from '@angular/router';
import { take } from 'rxjs';
import { Veiculo } from 'src/app/models/veiculo.model';
import { VeiculoService } from 'src/app/services/veiculo/veiculo.service';

@Component({
  selector: 'app-veiculo-edit',
  templateUrl: './veiculo-edit.component.html',
  styleUrls: ['./veiculo-edit.component.css']
})
export class VeiculoEditComponent {

  veiculo: Veiculo;

  constructor(private router: Router, private route: ActivatedRoute, private veiculoService: VeiculoService) {
    this.getById(this.getId());
    this.veiculo = new Veiculo();
  }

  ngOnInit(): void {
  }

  getId(): number {
    return Number(this.route.snapshot.paramMap.get('id'));
  }

  getById(id: number): void {
    this.veiculoService.getById(id)
      .pipe(take(1))
      .subscribe({
        next: veiculo => this.handleResponseVeiculo(veiculo),
        error: error => this.handleResponseError(error.status)
      })
  }

  handleResponseVeiculo(veiculo: Veiculo): void {
    veiculo.DataFabricacao = veiculo.DataFabricacao.substring(0, 10); // yyyy-MM-dd
    this.veiculo = veiculo;
  }

  handleResponseError(error: number): void {
    this.exebirMensagemErro(error)
  }

  exebirMensagemErro(error: number): void {
    let mensagem: string = '';
    if (error == 404 || error == 400) {
      mensagem = 'Veículo não encontrado';
    } else {
      mensagem = 'Erro ao buscar veículo, entre em contato com o suporte';
    }
    alert(mensagem);
  }

  back(): void {
    this.router.navigate(['veiculo/veiculo-index']);
  }

  desejaAlterar(id: number): void {
    if (confirm(`Deseja alterar o veículo ${id}?`)) {
      this.put(id);
    }
  }

  put(id: number): void {
    this.veiculoService.put(id, this.veiculo)
      .pipe(take(1))
      .subscribe({
        next: veiculo => this.handleResponsePut(veiculo),
        error: error => this.handleResponseError(error.status)
      })
  }

  handleResponsePut(veiculo: Veiculo): void {
    alert(`Veículo ${veiculo.Id} alterado com sucesso`);
    this.back();
  }

}

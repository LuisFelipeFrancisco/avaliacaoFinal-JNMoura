import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Veiculo } from 'src/app/models/veiculo.model';

@Injectable({
  providedIn: 'root'
})
export class VeiculoService {

  private readonly URL: string;

  constructor(private httpClient: HttpClient) {
    this.URL = 'https://localhost:44388/api/Veiculos';
  }

  getAll(): Observable<Veiculo[]> {
    return this.httpClient.get<Veiculo[]>(this.URL);
  }

  getById(id: number): Observable<Veiculo> {
    return this.httpClient.get<Veiculo>(`${this.URL}/${id}`);
  }

  post(veiculo: Veiculo): Observable<Veiculo> {
    return this.httpClient.post<Veiculo>(this.URL, veiculo);
  }

  put(id: number, veiculo: Veiculo): Observable<Veiculo> {
    return this.httpClient.put<Veiculo>(`${this.URL}/${id}`, veiculo);
  }

  delete(id: number): Observable<Veiculo> {
    return this.httpClient.delete<Veiculo>(`${this.URL}/${id}`);
  }

}

import { HttpClient } from '@angular/common/http';
import { Injectable, inject } from '@angular/core';
import { Observable } from 'rxjs';

export enum TarefaStatus {
  Pendente = 0,
  EmAndamento = 1,
  Concluida = 2,
}

export interface Tarefa {
  id: number;
  titulo: string;
  descricao: string;
  dataCriacao: string;
  dataVencimento: string;
  dataConclusao: string;
  status: TarefaStatus | string;
}

export interface NovaTarefa {
  titulo: string;
  descricao: string;
  dataCriacao: string;
  dataVencimento: string;
  dataConclusao: string;
  status: TarefaStatus;
}

export interface NovoUsuario {
  nome: string;
  email: string;
  senha: string;
}

@Injectable({ providedIn: 'root' })
export class ApiService {
  private readonly http = inject(HttpClient);
  private readonly apiUrl = 'http://localhost:5274/api';

  listarTarefas(): Observable<Tarefa[]> {
    return this.http.get<Tarefa[]>(`${this.apiUrl}/Tarefa`);
  }

  criarTarefa(tarefa: NovaTarefa): Observable<Tarefa> {
    return this.http.post<Tarefa>(`${this.apiUrl}/Tarefa`, tarefa);
  }

  atualizarTarefa(id: number, tarefa: NovaTarefa): Observable<Tarefa> {
    return this.http.put<Tarefa>(`${this.apiUrl}/Tarefa/${id}`, tarefa);
  }

  excluirTarefa(id: number): Observable<void> {
    return this.http.delete<void>(`${this.apiUrl}/Tarefa/${id}`);
  }

  cadastrarUsuario(
    usuario: NovoUsuario,
  ): Observable<Pick<NovoUsuario, 'nome' | 'email'> & { id: number }> {
    return this.http.post<
      Pick<NovoUsuario, 'nome' | 'email'> & { id: number }
    >(`${this.apiUrl}/Usuario`, usuario);
  }
}
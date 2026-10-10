import { CommonModule } from '@angular/common';
import { HttpErrorResponse } from '@angular/common/http';
import { Component, OnInit, inject } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { ApiService, NovaTarefa, Tarefa, TarefaStatus } from './api.service';

type Tela = 'tarefas' | 'cadastro';

@Component({
  selector: 'app-root',
  imports: [CommonModule, FormsModule],
  templateUrl: './app.html',
  styleUrl: './app.css',
})
export class App implements OnInit {
  private readonly api = inject(ApiService);

  tela: Tela = 'tarefas';
  tarefas: Tarefa[] = [];
  carregando = false;
  salvando = false;
  mensagemErro = '';
  mensagemSucesso = '';
  formularioAberto = false;
  tarefaEditandoId: number | null = null;
  filtro: 'todas' | 'abertas' | 'concluidas' = 'todas';

  tarefaForm = this.novaTarefaForm();
  usuarioForm = { nome: '', email: '', senha: '' };

  ngOnInit(): void {
    this.carregarTarefas();
  }

  get tarefasFiltradas(): Tarefa[] {
    if (this.filtro === 'abertas') {
      return this.tarefas.filter(
        (tarefa) => this.statusDa(tarefa) !== TarefaStatus.Concluida,
      );
    }

    if (this.filtro === 'concluidas') {
      return this.tarefas.filter(
        (tarefa) => this.statusDa(tarefa) === TarefaStatus.Concluida,
      );
    }

    return this.tarefas;
  }

  get totalConcluidas(): number {
    return this.tarefas.filter(
      (tarefa) => this.statusDa(tarefa) === TarefaStatus.Concluida,
    ).length;
  }

  get totalAbertas(): number {
    return this.tarefas.length - this.totalConcluidas;
  }

  mostrarTela(tela: Tela): void {
    this.limparMensagens();
    this.tela = tela;
    this.formularioAberto = false;
  }

  carregarTarefas(): void {
    this.carregando = true;
    this.mensagemErro = '';

    this.api.listarTarefas().subscribe({
      next: (tarefas) => {
        this.tarefas = tarefas;
        this.carregando = false;
      },
      error: (erro: HttpErrorResponse) => {
        this.mensagemErro = this.mensagemDaFalha(erro);
        this.carregando = false;
      },
    });
  }

  abrirNovaTarefa(): void {
    this.limparMensagens();
    this.tarefaEditandoId = null;
    this.tarefaForm = this.novaTarefaForm();
    this.formularioAberto = true;
  }

  editarTarefa(tarefa: Tarefa): void {
    this.limparMensagens();
    this.tarefaEditandoId = tarefa.id;

    this.tarefaForm = {
      titulo: tarefa.titulo,
      descricao: tarefa.descricao,
      dataVencimento: tarefa.dataVencimento
        ? tarefa.dataVencimento.substring(0, 10)
        : '',
      status: this.statusDa(tarefa),
    };

    this.formularioAberto = true;
  }

  cancelarFormulario(): void {
    this.formularioAberto = false;
    this.tarefaEditandoId = null;
  }

  salvarTarefa(): void {
    this.limparMensagens();
    this.salvando = true;

    const agora = new Date().toISOString();

    const existente = this.tarefas.find(
      (tarefa) => tarefa.id === this.tarefaEditandoId,
    );

    const dados: NovaTarefa = {
      titulo: this.tarefaForm.titulo.trim(),
      descricao: this.tarefaForm.descricao.trim(),

      dataCriacao: existente?.dataCriacao ?? agora,

      dataVencimento:
        `${this.tarefaForm.dataVencimento}T23:59:59`,

      dataConclusao:
        this.tarefaForm.status === TarefaStatus.Concluida &&
        (!existente || this.statusDa(existente) !== TarefaStatus.Concluida)
          ? agora
          : existente?.dataConclusao ?? agora,

      status: this.tarefaForm.status,
    };

    const requisicao =
      this.tarefaEditandoId === null
        ? this.api.criarTarefa(dados)
        : this.api.atualizarTarefa(this.tarefaEditandoId, dados);

    requisicao.subscribe({
      next: () => {
        this.salvando = false;
        this.formularioAberto = false;

        this.mensagemSucesso =
          this.tarefaEditandoId === null
            ? 'Tarefa criada com sucesso.'
            : 'Tarefa atualizada com sucesso.';

        this.tarefaEditandoId = null;
        this.carregarTarefas();
      },
      error: (erro: HttpErrorResponse) => {
        this.mensagemErro = this.mensagemDaFalha(erro);
        this.salvando = false;
      },
    });
  }

  concluirTarefa(tarefa: Tarefa): void {
    this.limparMensagens();

    const dados: NovaTarefa = {
      titulo: tarefa.titulo,
      descricao: tarefa.descricao,
      dataCriacao: tarefa.dataCriacao,
      dataVencimento: tarefa.dataVencimento,
      dataConclusao: new Date().toISOString(),
      status: TarefaStatus.Concluida,
    };

    this.api.atualizarTarefa(tarefa.id, dados).subscribe({
      next: () => {
        this.mensagemSucesso = 'Tarefa marcada como concluída.';
        this.carregarTarefas();
      },
      error: (erro: HttpErrorResponse) => {
        this.mensagemErro = this.mensagemDaFalha(erro);
      },
    });
  }

  excluirTarefa(tarefa: Tarefa): void {
    if (!window.confirm(`Deseja excluir a tarefa "${tarefa.titulo}"?`)) {
      return;
    }

    this.limparMensagens();

    this.api.excluirTarefa(tarefa.id).subscribe({
      next: () => {
        this.mensagemSucesso = 'Tarefa excluída com sucesso.';
        this.carregarTarefas();
      },
      error: (erro: HttpErrorResponse) => {
        this.mensagemErro = this.mensagemDaFalha(erro);
      },
    });
  }

  cadastrarUsuario(): void {
    this.limparMensagens();
    this.salvando = true;

    this.api
      .cadastrarUsuario({
        nome: this.usuarioForm.nome.trim(),
        email: this.usuarioForm.email.trim(),
        senha: this.usuarioForm.senha,
      })
      .subscribe({
        next: () => {
          this.salvando = false;
          this.usuarioForm = { nome: '', email: '', senha: '' };
          this.tela = 'tarefas';
          this.mensagemSucesso = 'Cadastro realizado com sucesso.';
        },
        error: (erro: HttpErrorResponse) => {
          this.mensagemErro = this.mensagemDaFalha(erro);
          this.salvando = false;
        },
      });
  }

  statusDa(tarefa: Tarefa): TarefaStatus {
    if (typeof tarefa.status === 'number') {
      return tarefa.status;
    }

    const status = tarefa.status.toLowerCase();

    if (
      status === 'concluida' ||
      status === 'concluída' ||
      status === '2'
    ) {
      return TarefaStatus.Concluida;
    }

    if (
      status === 'emandamento' ||
      status === 'em andamento' ||
      status === '1'
    ) {
      return TarefaStatus.EmAndamento;
    }

    return TarefaStatus.Pendente;
  }

  nomeStatus(status: TarefaStatus): string {
    switch (status) {
      case TarefaStatus.Concluida:
        return 'Concluída';

      case TarefaStatus.EmAndamento:
        return 'Em andamento';

      default:
        return 'Pendente';
    }
  }

  classeStatus(tarefa: Tarefa): string {
    return TarefaStatus[this.statusDa(tarefa)].toLowerCase();
  }

  private novaTarefaForm(): {
    titulo: string;
    descricao: string;
    dataVencimento: string;
    status: TarefaStatus;
  } {
    return {
      titulo: '',
      descricao: '',
      dataVencimento: '',
      status: TarefaStatus.Pendente,
    };
  }

  private limparMensagens(): void {
    this.mensagemErro = '';
    this.mensagemSucesso = '';
  }

  private mensagemDaFalha(erro: HttpErrorResponse): string {
    const corpo = erro.error as {
      mensagem?: string;
      message?: string;
      title?: string;
    } | null;

    if (corpo?.mensagem || corpo?.message || corpo?.title) {
      return (
        corpo.mensagem ??
        corpo.message ??
        corpo.title ??
        'Não foi possível concluir a solicitação.'
      );
    }

    if (erro.status === 0) {
      return 'Não foi possível conectar à API. Verifique se ela está em execução e tente novamente.';
    }

    return `A solicitação falhou (HTTP ${erro.status}). Tente novamente.`;
  }
}
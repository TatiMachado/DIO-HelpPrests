using HelpPrests.Enum;
using System;
using System.Collections.Generic;

namespace HelpPrests.Classes
{
    class Agendamento
    {
        private int Codigo { get; set; }
        private DateTime DataAgendamento { get; set; }
        private Cliente Cliente { get; set; }
        private Servico Servico { get; set; }
        private StatusAgendamento StatusAgendamento { get; set; }

        public Agendamento()
        {

        }
        public Agendamento(int codigo, DateTime dataAgendamento, Cliente cliente, Servico servico, StatusAgendamento statusAgendamento)
        {
            Codigo = codigo;
            DataAgendamento = dataAgendamento;
            Cliente = cliente;
            Servico = servico;
            StatusAgendamento = statusAgendamento;
        }

        public override string ToString()
        {
            return "Data.....: " + this.DataAgendamento.ToString("dd/MM/yyyy") + "\n" +
                   "Status Ag: " + this.StatusAgendamento + "\n" +
                   "DADOS DO CLIENTE" + "\n" +
                   this.Cliente + "\n" +
                   "DADOS DO SERVIÇO" + "\n" +
                   this.Servico;
                   
        }

        public Agendamento ExisteAgendamento(List<Agendamento> lista, DateTime? dt, Cliente? cli, Servico? serv)
        {
            if (dt != null && cli != null && serv != null)
            {
                return (lista.Find(a => a.DataAgendamento == dt &&
                                        a.Cliente == cli &&
                                         a.Servico == serv));
            }
            else
            {
                if (cli != null)
                    return (lista.Find(a => a.Cliente == cli));
                else 
                    return (lista.Find(a => a.Servico == serv));
            }
        }

        public void Desmarcar(List<Agendamento> lista, Agendamento agendamento)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Codigo == agendamento.Codigo)
                {
                    lista[i].StatusAgendamento = StatusAgendamento.Cancelado;
                    break;
                }
            }
        }

        public void Atender(List<Agendamento> lista, Agendamento agendamento)
        {
            for (int i = 0; i < lista.Count; i++)
            {
                if (lista[i].Codigo == agendamento.Codigo)
                {
                    lista[i].StatusAgendamento = StatusAgendamento.Atendido;
                    break;
                }
            }
        }
    }
}

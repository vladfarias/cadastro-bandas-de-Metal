using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace appCadastroDio
{
    public class BandaMetal : EntidadeBase
    {
        // Atributos
        private Estilo Estilo {get; set;}
        private string Nome {get; set;} = "";
        private string Instagram { get; set; } = "";
        private string Estado {get; set; } = "";
        private string Contato { get; set; } = "";
        private bool Excluido { get; set; }
        

        // Métodos
        public BandaMetal(int id, Estilo estilo, string nome, string instagram, string estado, string contato)
        {
            this.Id = id;
            this.Estilo = estilo;
            this.Nome = nome;
            this.Instagram = instagram;
            this.Estado = estado;
            this.Contato = contato;
            this.Excluido = false;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Estilo: " + this.Estilo + Environment.NewLine;
            retorno += "Nome: " + this.Nome + Environment.NewLine;
            retorno += "Instagram: " + this.Instagram + Environment.NewLine;
            retorno += "Estado: " + this.Estado + Environment.NewLine;
            retorno += "Contato: " + this.Contato + Environment.NewLine;
            retorno += "Excluído: " + this.Excluido;
            return retorno;
        }

        public string retornaNome()
        {
            return this.Nome;
        }
          public int retornaId()
        {
            return this.Id;
        }

        public void Excluir()
        {
            this.Excluido = true;
        }

        public bool retornaExcluido()
        {
            return this.Excluido;
        }
    } 
}
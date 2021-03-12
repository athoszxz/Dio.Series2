using System;

namespace DIO.Series
{
    public class Serie : EntidadeBase
    {
        //Atributos
        private Genero Genero { get; set; }
        private string Titulo { get;  set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }
        private bool Favorito { get; set; }

        //Métodos
        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Genero = genero;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false; //Por padrão cada indice do vetor é marcado com false para excluído
            this.Favorito = false; //Por padrão cada indice do vetor é marcado com false para favorito
        }

        public override string ToString()
        {
            //Environment.NewLine https://docs.microsoft.com/en-us/dotnet/api/system.environment.newline?view=netcore-3.1
            string retorno = "";
            retorno += "Gênero: " + this.Genero + Environment.NewLine;
            retorno += "Título: " + this.Titulo + Environment.NewLine;
            retorno += "Descrição: " + this.Descricao + Environment.NewLine;
            retorno += "Ano de Início: " + this.Ano + Environment.NewLine;;
            retorno += "Excluido: " + this.Excluido + Environment.NewLine;;
            retorno += "Favorito: " + this.Favorito + Environment.NewLine;;
            return retorno;
        }

        //Encapsulamento
        public string retornaTitulo()
        {
            return this.Titulo;
        }

        public int retornaId()
        {
            return this.Id;
        }
        public bool retornaExcluido()
		{
			return this.Excluido;
		}
        public bool retornaFavorito()
		{
			return this.Favorito;
		}
        public void Excluir()
        {
            //Método que marca um índice como excluído, mas não o remove de fato como faz a função RemoveAt
            this.Excluido = true;
        }
        public void Favoritar()
        {
            if(this.Favorito == false)
            {
                this.Favorito = true;
            }
            else
            {
                this.Favorito = false;
            }
        }
    }
}
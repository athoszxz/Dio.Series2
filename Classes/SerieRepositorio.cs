using System;
using System.Collections.Generic;
using DIO.Series.interfaces;

namespace DIO.Series
{
    public class SerieRepositorio : IRepositorio<Serie>
    {
        private List<Serie> listaSerie = new List<Serie>();

        public void Atualiza(int id, Serie objeto)
        {
            listaSerie[id] = objeto;
        }

        public void Exclui(int id)
        {   //Ao excluir um indice os outros indices mudam de posição em efeito dominó
            //Ao invés de remover o registro definitivamente com RemoveAt, aqui estou marcando o registro como excluído
            listaSerie[id].Excluir(); 
            
        }

        public void Insere(Serie objeto)
        {
            listaSerie.Add(objeto);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int ProximoId()
        {   //O tamanho da lista é igual ao próximo indice, ex: lista com 2 valores dá count = 2 e o último índice = 1
            return listaSerie.Count; 
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }

        public Serie Aletoriza()
        {
            Random rnd = new Random();
            int x = rnd.Next(0,listaSerie.Count);
            return listaSerie[x];
        }
        public void Favorita(int id)
        {   //Ao excluir um indice os outros indices mudam de posição em efeito dominó
            //Ao invés de remover o registro definitivamente com RemoveAt, aqui estou marcando o registro como excluído
            listaSerie[id].Favoritar(); 
            
        }

    }
}
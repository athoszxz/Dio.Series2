using System.Collections.Generic;

namespace DIO.Series.interfaces
{
    public interface IRepositorio<T>
    {
         List<T> Lista(); //Essa interface vai ter um método de uma lista que retorna uma lista
         T RetornaPorId(int id); //Passo um Id por parâmetro e ele retorna o T
         void Insere(T entidade);
         void Exclui(int id);
         void Atualiza(int id, T entidade);
         int ProximoId();
    }
}
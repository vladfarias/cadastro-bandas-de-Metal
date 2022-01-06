using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using appCadastroDio.Interfaces;

namespace appCadastroDio
{
    public class BandaMetalRepositorio : IRepositorio<BandaMetal>
    {
        private List<BandaMetal> listaBandaMetal = new List<BandaMetal>(); 
        public void Atualiza(int id, BandaMetal objeto)
        {
            listaBandaMetal[id] = objeto;
        }

        public void Exclui(int id)
        {
            listaBandaMetal[id].Excluir();
        }

        public void Insere(BandaMetal objeto)
        {
            listaBandaMetal.Add(objeto);
        }

        public List<BandaMetal> Lista()
        {
            return listaBandaMetal;
        }

        public int ProximoId()
        {
            return listaBandaMetal.Count;
        }

        public BandaMetal RetornaPorID(int id)
        {
            return listaBandaMetal[id];
        }
    }
}
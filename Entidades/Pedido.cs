using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Checkpoint2.Entidades.Enums;

namespace Checkpoint2.Entidades
{
    internal class Pedido
    {
        public DateTime DataPedido { get; set; }
        public double Valor { get; set; }
        public StatusPedido Status { get; set; }
        public List<ItemPedido> Itens { get; set; }
        public Funcionario Funcionario { get; set; }
        public void AdicionarItem(ItemPedido item)
        {
            if (Itens == null)
            {
                Itens = new List<ItemPedido>();
            }

            Itens.Add(item);
        }
        public override string ToString() { return $" {DataPedido} | {Valor} | {Status} "; }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Checkpoint2.Entidades
{
    internal class Gerente : Funcionario
    {
        public Gerente()
        {

        }

        public Gerente(string nome, string matricula, double salario) :
            base(nome, matricula, salario)
        {
        }

        public override double CalcularPagamento(List<Pedido> pedidos)
        {
            double soma = 0;

            foreach (var pedido in pedidos)
            {
                soma += pedido.Valor * (5/100);
            }

            return Salario + soma;
        }

        public override string ToString()
        {
            return $"{Nome} | {Matricula} | {Salario:F2}";
        }
    }
}

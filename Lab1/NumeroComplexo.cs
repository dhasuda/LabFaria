using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab1
{
    class NumeroComplexo
    {
        // Variaveis
        public double parteReal { get; set; }
        public double parteImaginaria { get; set; }

        // Construtor
        public NumeroComplexo(double parteReal, double parteImaginaria)
        {
            this.parteReal = parteReal;
            this.parteImaginaria = parteImaginaria;
        }

        //Funcoes de complexos

        // Complexo operado com complexo
        public NumeroComplexo Complemento()
        {
            return new NumeroComplexo(this.parteReal, -this.parteImaginaria);
        }

        public double Modulo()
        {
            NumeroComplexo resposta = this * this.Complemento();
            return resposta.parteReal;
        }

        public static NumeroComplexo operator +(NumeroComplexo c1, NumeroComplexo c2)
        {
            return new NumeroComplexo(c1.parteReal + c2.parteReal, c1.parteImaginaria + c2.parteImaginaria);
        }

        public static NumeroComplexo operator -(NumeroComplexo c1, NumeroComplexo c2)
        {
            return new NumeroComplexo(c1.parteReal - c2.parteReal, c1.parteImaginaria - c2.parteImaginaria);
        }

        public static NumeroComplexo operator *(NumeroComplexo c1, NumeroComplexo c2)
        {
            return new NumeroComplexo((c1.parteReal * c2.parteReal) - (c1.parteImaginaria * c2.parteImaginaria),
                (c1.parteReal * c2.parteImaginaria) + (c1.parteImaginaria * c2.parteReal));
        }

        public static NumeroComplexo operator /(NumeroComplexo c1, NumeroComplexo c2)
        {
            NumeroComplexo resposta = c1 * c2.Complemento();
            resposta = resposta / c2.Modulo();
            return resposta;
        }

        // Real operado com complexo
        public static NumeroComplexo operator +(NumeroComplexo c1, double r)
        {
            return new NumeroComplexo(c1.parteReal + r, c1.parteImaginaria);
        }

        public static NumeroComplexo operator -(NumeroComplexo c1, double r)
        {
            return new NumeroComplexo(c1.parteReal - r, c1.parteImaginaria);
        }

        public static NumeroComplexo operator *(NumeroComplexo c1, double r)
        {
            return new NumeroComplexo(c1.parteReal * r, c1.parteImaginaria * r);
        }

        public static NumeroComplexo operator /(NumeroComplexo c1, double r)
        {
            return new NumeroComplexo(c1.parteReal / r, c1.parteImaginaria / r);
        }
    }
}

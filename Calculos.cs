using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


static double PI = 3.14159;

namespace Lab1
{
    public class Calculos
    { 

        // Construtor
        public Calculos()
        {

        }

        //Metodos
        //Retorna a raiz positiva na conta de t
        public double t_plus(double XL, double RL, double Z0)
        {
            if (RL != Z0)
                return (XL + sqrt((RL / Z0) * ((Z0 - RL) ^ 2 + XL ^ 2))) / (RL - X0) ;
            else
                return XL / (2 * Z0);
        }
        //Retorna a raiz negativa na conta de t
        public double t_minus(double XL, double RL, double Z0)
        {
            if (RL != Z0)
                return (XL - sqrt((RL / Z0) * ((Z0 - RL) ^ 2 + XL ^ 2))) / (RL - X0) ;
            else
                return XL / (2 * Z0);
        }
        //Retorna a razao d / lambda
        public double d_lambda(double t)
        {
            if (t >= 0)
                return (1 / (2 * PI)) * arctan(t);
            else
                return (1 / (2 * PI)) * (PI + arctan(t));
        }
        //Retorna o valor de Z
        public double Z (double XL, double RL, double Z0, double d, double beta)
        {
            NumeroComplexo ZL;
            ZL.parteReal = RL;
            ZL.parteImaginaria = XL;
            NumeroComplexo c1;
            NumeroComplexo c2;
            c1.parteReal = ZL.parteReal;
            c1.parteImaginaria = ZL.parteImaginaria + Z0 * tg(beta * d);
            c2.parteReal = Z0 - ZL.parteImaginaria * tg(beta * d);
            c2.parteImaginaria = ZL.parteReal * tg(beta * d);
            return Z0 * (c1 / c2);
        }

    }

}

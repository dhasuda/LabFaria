using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



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
                return (XL + Math.Sqrt((RL / Z0) * (((Z0 - RL)* (Z0 - RL)) +( XL*XL)))) / (RL - Z0);
            else
                return XL / (2 * Z0);
        }
        //Retorna a raiz negativa na conta de t
        public double t_minus(double XL, double RL, double Z0)
        {
            if (RL != Z0)
                return (XL - Math.Sqrt((RL / Z0) * (((Z0 - RL)* (Z0 - RL)) + (XL*XL)))) / (RL - Z0);
            else
                return XL / (2 * Z0);
        }
        //Retorna a razao d / lambda
        public double d_lambda(double t)
        {
            if (t >= 0)
                return (1 / (2 * 3.1415)) * Math.Atan(t);
            else
                return (1 / (2 * 3.1415)) * (3.141500 + Math.Atan(t));
        }

        public double distance (double t, double freq, double epsilonRel)
        {
            double c = 299792000;
            return d_lambda(t) *( c / freq);
        }
        //Retorna o valor de Z
        public NumeroComplexo Z(double XL, double RL, double Z0, double d, double beta)
        {
            NumeroComplexo ZL = new NumeroComplexo(0,0);
            ZL.parteReal = RL;
            ZL.parteImaginaria = XL;
            NumeroComplexo c1 = new NumeroComplexo(0, 0); ;
            NumeroComplexo c2 = new NumeroComplexo(0, 0); ;
            c1.parteReal = ZL.parteReal;
            c1.parteImaginaria = ZL.parteImaginaria + Z0 * Math.Tan(beta * d);
            c2.parteReal = Z0 - ZL.parteImaginaria * Math.Tan(beta * d);
            c2.parteImaginaria = ZL.parteReal * Math.Tan(beta * d);
            return (c1/c2) * Z0;
        }

    }

}

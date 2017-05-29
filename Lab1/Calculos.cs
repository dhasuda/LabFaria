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
                return (XL + Math.Sqrt((RL / Z0) * (((Z0 - RL) * (Z0 - RL)) + (XL * XL)))) / (RL - Z0);
            else
                return XL / (2 * Z0);
        }
        //Retorna a raiz negativa na conta de t
        public double t_minus(double XL, double RL, double Z0)
        {
            if (RL != Z0)
                return (XL - Math.Sqrt((RL / Z0) * (((Z0 - RL) * (Z0 - RL)) + (XL * XL)))) / (RL - Z0);
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

        public double distance(double t, double freq, double epsilonRel)
        {
            double c = 299792458;
            return d_lambda(t) * (c / freq);
        }

        //Retorna o valor de Z
        public NumeroComplexo Z(double XL, double RL, double Z0, double d, double beta)
        {
            NumeroComplexo ZL = new NumeroComplexo(0, 0);
            ZL.parteReal = RL;
            ZL.parteImaginaria = XL;
            NumeroComplexo c1 = new NumeroComplexo(0, 0); ;
            NumeroComplexo c2 = new NumeroComplexo(0, 0); ;
            c1.parteReal = ZL.parteReal;
            c1.parteImaginaria = ZL.parteImaginaria + Z0 * Math.Tan(beta * d);
            c2.parteReal = Z0 - ZL.parteImaginaria * Math.Tan(beta * d);
            c2.parteImaginaria = ZL.parteReal * Math.Tan(beta * d);
            return (c1 / c2) * Z0;
        }

        //Retorna a razao length / lambda
        public double length_lambda(NumeroComplexo Z, double Z0)
        {
            double Y0 = (1 / Z0);
            NumeroComplexo Y = new NumeroComplexo(0, 0);
            NumeroComplexo One = new NumeroComplexo(1, 0);
            Y = One / Z;
            return (1 / (2 * 3.1415)) * Math.Atan(Y0 / Y.parteImaginaria);
        }

        public double length(NumeroComplexo ZLoad, double Z0, double freq, double epsilonRel)
        {
            double c = 299792458;
            return length_lambda(ZLoad, Z0) * (c / freq);
        }

        public NumeroComplexo reflectionCoef(NumeroComplexo zl, double z0)
        {
            return ((zl - z0) / (zl + z0));
        }

        public double swr(NumeroComplexo zl, double z0)
        {
            NumeroComplexo reflection = reflectionCoef(zl, z0);
            double gama = reflection.Modulo();
            return (1 + gama) / (1 - gama);
        }

    }

}
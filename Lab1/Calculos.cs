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
        private double t_plus(double XL, double RL, double Z0)
        {
            if (RL != Z0)
                return (XL + Math.Sqrt((RL / Z0) * (((Z0 - RL) * (Z0 - RL)) + (XL * XL)))) / (RL - Z0);
            else
                return XL / (2 * Z0);
        }
        //Retorna a raiz negativa na conta de t
        private double t_minus(double XL, double RL, double Z0)
        {
            if (RL != Z0)
                return (XL - Math.Sqrt((RL / Z0) * (((Z0 - RL) * (Z0 - RL)) + (XL * XL)))) / (RL - Z0);
            else
                return XL / (2 * Z0);
        }


        //Retorna a razao d / lambda, para t_plus
        private double d_lambda_plus(double XL, double RL, double Z0)
        {
            double tpl = t_plus(XL, RL, Z0);
            if (tpl >= 0)
                return (1 / (2 * 3.1415)) * Math.Atan(tpl);
            else
                return (1 / (2 * 3.1415)) * (3.141500 + Math.Atan(tpl));
        }
        //Retorna a razao d / lambda, para t_minus
        private double d_lambda_minus(double XL, double RL, double Z0)
        {
            double tmin = t_minus(XL, RL, Z0);
            if (tmin >= 0)
                return (1 / (2 * 3.1415)) * Math.Atan(tmin);
            else
                return (1 / (2 * 3.1415)) * (3.141500 + Math.Atan(tmin));
        }


        //Retorna a distancia, para t_plus
        public double distance_plus(double XL, double RL, double Z0, double freq, double epsilonRel)
        {
            double c = 299792458;
            return d_lambda_plus(XL, RL, Z0) * (c / (freq * Math.Sqrt(epsilonRel)));
        }
        //Retorna a distancia, para t_minus
        public double distance_minus(double XL, double RL, double Z0, double freq, double epsilonRel)
        {
            double c = 299792458;
            return d_lambda_minus(XL, RL, Z0) * (c / (freq * Math.Sqrt(epsilonRel)));
        }



        //Retorna o valor de Z, para t_plus
        public NumeroComplexo Z_plus(double XL, double RL, double Z0, double freq, double epsilonRel)
        {
            double c = 299792458;
            double beta = (2 * 3.1415) / (c / (freq * Math.Sqrt(epsilonRel)));
            double dpl = distance_plus(XL, RL, Z0, freq, epsilonRel);
            NumeroComplexo ZL = new NumeroComplexo(RL, XL);
            NumeroComplexo c1 = new NumeroComplexo(ZL.parteReal, ZL.parteImaginaria + Z0 * Math.Tan(beta * dpl)); ;
            NumeroComplexo c2 = new NumeroComplexo(Z0 - ZL.parteImaginaria * Math.Tan(beta * dpl), ZL.parteReal * Math.Tan(beta * dpl)); ;
            return (c1 / c2) * Z0;
        }
        //Retorna o valor de Z, para t_minus
        public NumeroComplexo Z_minus(double XL, double RL, double Z0, double freq, double epsilonRel)
        {
            double c = 299792458;
            double beta = (2 * 3.1415) / (c / (freq * Math.Sqrt(epsilonRel)));
            double dmin = distance_minus(XL, RL, Z0, freq, epsilonRel);
            NumeroComplexo ZL = new NumeroComplexo(RL, XL);
            NumeroComplexo c1 = new NumeroComplexo(ZL.parteReal, ZL.parteImaginaria + Z0 * Math.Tan(beta * dmin)); ;
            NumeroComplexo c2 = new NumeroComplexo(Z0 - ZL.parteImaginaria * Math.Tan(beta * dmin), ZL.parteReal * Math.Tan(beta * dmin)); ;
            return (c1 / c2) * Z0;
        }

        
        
        //Retorna a razao length / lambda
        private double length_lambda(NumeroComplexo Z, double Z0)
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
            return length_lambda(ZLoad, Z0) * (c / (freq * Math.Sqrt(epsilonRel)));
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
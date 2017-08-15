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
        private double length_lambda_plus(NumeroComplexo ZL, double XL, double RL, double Z0, double freq, double epsilonRel)
        {
            double Y0 = (1 / Z0);
            NumeroComplexo Y = new NumeroComplexo(0, 0);
            NumeroComplexo One = new NumeroComplexo(1, 0);
            NumeroComplexo Z = new Lab1.NumeroComplexo(0, 0);
            Z = Z_plus(XL, RL, Z0, freq, epsilonRel);
            Y = One / Z;
            return (1 / (2 * 3.1415)) * Math.Atan(Y0 / Y.parteImaginaria);
        }
        private double length_lambda_minus(NumeroComplexo ZL, double XL, double RL, double Z0, double freq, double epsilonRel)
        {
            double Y0 = (1 / Z0);
            NumeroComplexo Y = new NumeroComplexo(0, 0);
            NumeroComplexo One = new NumeroComplexo(1, 0);
            NumeroComplexo Z = new NumeroComplexo(0, 0);
            Z = Z_minus(XL, RL, Z0, freq, epsilonRel);
            Y = One / Z;
            return (1 / (2 * 3.1415)) * Math.Atan(Y0 / Y.parteImaginaria);
        }

        private NumeroComplexo Z(NumeroComplexo zl, double z0, double t)
        {
            NumeroComplexo j = new NumeroComplexo(0, 1);
            NumeroComplexo numerador = (zl + j * z0 * t);
            NumeroComplexo denominador = (j * zl * t + z0);
            return (numerador / denominador) * z0;
        }

        private NumeroComplexo Z(NumeroComplexo zl, double z0, double d, double beta)
        {
            NumeroComplexo j = new NumeroComplexo(0, 1);
            NumeroComplexo numerador = (zl + j * z0 * Math.Tan(beta*d));
            NumeroComplexo denominador = (j * zl * Math.Tan(beta * d) + z0);
            return (numerador / denominador) * z0;
        }

        public double length_plus(NumeroComplexo ZLoad, double XL, double RL, double Z0, double freq, double epsilonRel)
        {
            double c = 299792458;
            double leng_pl = length_lambda_plus(ZLoad, XL, RL, Z0, freq, epsilonRel) * (c / (freq * Math.Sqrt(epsilonRel)));
            if (leng_pl >= 0)
                return leng_pl;
            else
                return leng_pl + (0.5 * (c / (freq * Math.Sqrt(epsilonRel))));
        }
        public double length_minus(NumeroComplexo ZLoad, double XL, double RL, double Z0, double freq, double epsilonRel)
        {
            double c = 299792458;
            double leng_min = length_lambda_minus(ZLoad, XL, RL, Z0, freq, epsilonRel) * (c / (freq * Math.Sqrt(epsilonRel)));
            if (leng_min >= 0)
                return leng_min;
            else
                return leng_min + (0.5 * (c / (freq * Math.Sqrt(epsilonRel))));
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

        public double swr_max(NumeroComplexo Zl, double Z0, double d, double l, double f, double bw, double epsilon)
        {
            f += bw / 2.0;
            double beta = 2 * 3.14159 * f * Math.Sqrt(epsilon) / 299792458;
            double t = this.t_plus(Zl.parteImaginaria, Zl.parteReal, Z0);
            NumeroComplexo z1 = this.Z(Zl, Z0, t);
            NumeroComplexo zero = new NumeroComplexo(0, 0);
            NumeroComplexo z2 = this.Z(zero, Z0, l, beta);
            NumeroComplexo one = new NumeroComplexo(1, 0);
            z1 = one / z1;
            z2 = one / z2;
            Zl = one / (z1 + z2);
            return swr(Zl, Z0);
        }

        public double swr_min(NumeroComplexo Zl, double Z0, double d, double l, double f, double bw, double epsilon)
        {
            f -= bw / 2.0;
            double beta = 2 * 3.14159 * f * Math.Sqrt(epsilon) / 299792458;
            double t = this.t_plus(Zl.parteImaginaria, Zl.parteReal, Z0);
            NumeroComplexo z1 = this.Z(Zl, Z0, d, beta);
            NumeroComplexo zero = new NumeroComplexo(0, 0);
            NumeroComplexo z2 = this.Z(zero, Z0, l, beta);
            NumeroComplexo one = new NumeroComplexo(1, 0);
            z1 = one / z1;
            z2 = one / z2;
            Zl = one / (z1 + z2);
            return swr(Zl, Z0);
        }
    }
}
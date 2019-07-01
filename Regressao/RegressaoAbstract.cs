using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Regressao
{
    public abstract class RegressaoAbstract
    {
        
        protected readonly List<long> _eixoX;
        protected readonly List<long> _eixoY;
        protected RegressaoAbstract(List<long> eixoX, List<long> eixoY)
        {
            _eixoY = eixoY;
            _eixoX = eixoX;

        }
        public double Previsao { get; protected set; }
        protected double SomarXy(List<double> eixoX, List<double> eixoY)
        {

            double valor = 0;
            for (int i = 0; i < eixoX.Count; i++)
            {
                valor += eixoX[i] * eixoY[i];
            }
            return valor;
        }

        protected double SomarXy(List<long> eixoX, List<long> eixoY)
        {

            double valor = 0;
            for (int i = 0; i < eixoX.Count; i++)
            {
                valor += eixoX[i] * eixoY[i];
            }
            return valor;
        }

        protected double SomarXy(List<double> eixoX, List<long> eixoY)
        {

            double valor = 0;
            for (int i = 0; i < eixoX.Count; i++)
            {
                valor += eixoX[i] * eixoY[i];
            }
            return valor;
        }

        protected  double CoeficienteAngular(double numeroDeNodos, double somaX, double somaY, double somaXY, double somaXquadrado)
        {
            //m
            var calculoSuperior = numeroDeNodos * somaXY - somaX * somaY;
            var calculoInferior = numeroDeNodos * somaXquadrado - (somaX * somaX);
            return Convert.ToDouble(calculoSuperior) / Convert.ToDouble(calculoInferior);
        }

        protected  double CoeficienteLinear(double numeroDeNodos, double somaX, double somaY, double somaXY, double somaXquadrado)
        {
            //b
            var calculoSuperior = somaXquadrado * somaY - somaX * somaXY;
            var calculoInferior = numeroDeNodos * somaXquadrado - (somaX * somaX);
            return Convert.ToDouble(calculoSuperior) / Convert.ToDouble(calculoInferior);
        }

        protected abstract void PreverPonto(double coeficienteAngular, double coeficienteLinear, double pontoX);
    }
}

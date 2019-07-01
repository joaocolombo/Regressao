using System;
using System.Collections.Generic;
using System.Linq;

namespace Regressao.Tipos
{
    public class Potencia : RegressaoAbstract, IRegressao
    {
        public Potencia(List<long> eixoX, List<long> eixoY, int proximoPonto) : base(eixoX, eixoY)
        {
            var eixoXLog = _eixoX.Select(x => Math.Log(x)).ToList();
            var eixoYLog = _eixoY.Select(x => Math.Log(x)).ToList();
            var somaX = eixoXLog.Sum(y => y);
            var somaY = eixoYLog.Sum(y => y);

            var somaXquadrado = eixoXLog.Sum(x => x * x);
            var somaXY = SomarXy(eixoXLog, eixoYLog);

            var numeroDeNodos = _eixoY.Count;
            var angular = CoeficienteAngular(numeroDeNodos, somaX, somaY, somaXY, somaXquadrado);
            var linear = CoeficienteLinear(numeroDeNodos, somaX, somaY, somaXY, somaXquadrado);
            PreverPonto(angular, linear, proximoPonto);

        }
               
        protected override void PreverPonto(double coeficienteAngular, double coeficienteLinear, double pontoX)
        {
            var expCoeficienteLinear = Math.Exp(coeficienteLinear); // 3.0078
            Previsao = expCoeficienteLinear * Math.Pow(pontoX,coeficienteLinear);
        }


    }
}

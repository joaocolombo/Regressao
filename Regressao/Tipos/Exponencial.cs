using System;
using System.Collections.Generic;
using System.Linq;

namespace Regressao.Tipos
{
    public class Exponencial : RegressaoAbstract, IRegressao
    {
        public Exponencial(List<long> eixoX, List<long> eixoY, int proximoPonto) : base(eixoX, eixoY)
        {
            var eixoYLog = _eixoY.Select(x => Math.Log(x)).ToList();
            var somaX = _eixoX.Sum(y => y);
            var somaY = eixoYLog.Sum(y => y);
            var somaXquadrado = _eixoX.Sum(x => x * x);
            var somaXY = SomarXy(eixoYLog, eixoX);
            var numeroDeNodos = _eixoY.Count;
            var angular = CoeficienteAngular(numeroDeNodos, somaX, somaY, somaXY, somaXquadrado);
            var linear = CoeficienteLinear(numeroDeNodos, somaX, somaY, somaXY, somaXquadrado);
            PreverPonto(angular, linear, proximoPonto);

        }



        protected override void PreverPonto(double coeficienteAngular, double coeficienteLinear, double pontoX)
        {
            var expCoeficienteLinear = Math.Exp(coeficienteLinear);
            
            Previsao = expCoeficienteLinear * Math.Exp(coeficienteAngular*pontoX);
        }
    }
}

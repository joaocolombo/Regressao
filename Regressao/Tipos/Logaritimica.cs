using System;
using System.Collections.Generic;
using System.Linq;

namespace Regressao.Tipos
{
    public class Logaritimica : RegressaoAbstract, IRegressao
    {
        public Logaritimica(List<long> eixoX, List<long> eixoY, int proximoPonto) : base(eixoX, eixoY)
        {
            var eixoXLog = _eixoX.Select(x => Math.Log(x)).ToList();
            var somaY = _eixoY.Sum(y => y);
            var somaX = eixoXLog.Sum(y => y);
            var somaXquadrado = eixoXLog.Sum(x => x * x);
            var somaXY = SomarXy(eixoXLog, eixoY);
            var numeroDeNodos = _eixoY.Count;
            var angular = CoeficienteAngular(numeroDeNodos, somaX, somaY, somaXY, somaXquadrado);
            var linear = CoeficienteLinear(numeroDeNodos, somaX, somaY, somaXY, somaXquadrado);
            PreverPonto(angular, linear, proximoPonto);

        }

        //y=m*log(x) +b
        protected override void PreverPonto(double coeficienteAngular, double coeficienteLinear, double pontoX)
        {
            Previsao = coeficienteAngular * Math.Log(pontoX) + coeficienteLinear;
        }
    }
}


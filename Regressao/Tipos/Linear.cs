using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Regressao.Tipos
{
    public class Linear : RegressaoAbstract, IRegressao
    {

        public Linear(List<long> eixoX, List<long> eixoY, int proximoPonto) :base(eixoX, eixoY)
        {
            var somaX = _eixoX.Sum(x => x);
            var somaY = _eixoY.Sum(y => y);
            var somaXquadrado = _eixoX.Sum(x => x * x);
            var somaXY = SomarXy(_eixoX, eixoY);
            var numeroDeNodos = _eixoY.Count;
            var angular = CoeficienteAngular(numeroDeNodos, somaX, somaY, somaXY, somaXquadrado);
            var linear = CoeficienteLinear(numeroDeNodos, somaX, somaY, somaXY, somaXquadrado);
            PreverPonto(angular, linear, proximoPonto);
        }

        protected override void PreverPonto(double coeficienteAngular, double coeficienteLinear, double pontoX)
        {
            Previsao =  coeficienteAngular * pontoX + coeficienteLinear;
        }
    }
}

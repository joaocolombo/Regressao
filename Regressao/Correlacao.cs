using System;
using System.Collections.Generic;
using System.Linq;

namespace Regressao
{
    public class Correlacao
    {
        protected readonly List<long> _eixoX;
        protected readonly List<long> _eixoY;

        public Correlacao(List<long> eixoX, List<long> eixoY)
        {
            _eixoY = eixoY;
            _eixoX = eixoX;
            var somaX = _eixoX.Sum(x => x);
            var somaY = _eixoY.Sum(y => y);
            var somaXquadrado = _eixoX.Sum(x => x * x);
            var somaYquadrado = _eixoY.Sum(x => x * x);
            var numeroDeNodos = _eixoY.Count;
            CalcularCorrelacao(numeroDeNodos, somaX, somaY, somaXquadrado, somaYquadrado);
        }
        protected long SomarXy()
        {

            long valor = 0;
            for (int i = 0; i < _eixoX.Count; i++)
            {
                valor += _eixoX[i] * _eixoY[i];
            }
            return valor;
        }

        public double Confiabilidade { get; private set; }
        public string Classificacao => Classificar(Confiabilidade);

        private void CalcularCorrelacao(long numeroDeNodos, long somaX, long somaY, long somaXquadrado, long somaYquadrado)
        {

            long calculoSuperior = numeroDeNodos * SomarXy() - (somaX * somaY);
            long calculoInferiorParte1 = numeroDeNodos * somaXquadrado - (somaX * somaX);
            long calculoInferiorParte2 = numeroDeNodos * somaYquadrado - (somaY * somaY);
            long calculoInferiorMultiplicacao = calculoInferiorParte1 * calculoInferiorParte2;
            var calculoInferior = Math.Sqrt(calculoInferiorMultiplicacao);

            Confiabilidade = calculoSuperior / calculoInferior;
        }

        private string Classificar(double confiabilidade)
        {
            if (confiabilidade>0.9||confiabilidade<-0.9)return "Otima";
            if (confiabilidade>0.8||confiabilidade<-0.8)return "Boa";
            if (confiabilidade>0.7||confiabilidade<-0.7)return "Regular";
            if (confiabilidade>0.6||confiabilidade<-0.6)return "Ruim";
            return "Impraticavel";
        }

    }
}

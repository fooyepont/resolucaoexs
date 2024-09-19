/* Entendo o problema:

    Analisar conjunto de dados representando o faturamento diário da distribuidora
    e calcular:

        Menor valor de faturamento: dia com menor valor de venda.
        Maior valor de faturamento: dia com maior valor de venda.
        Número de dias com faturamento acima da média: quantidade de dias que as vendas passaram da media anual.

    a) Considerar o vetor já carregado com as informações de valor de faturamento.

    b) Podem existir dias sem faturamento, como nos finais de semana e feriados. Estes dias devem ser ignorados no cálculo da média.

    c) Utilize o algoritmo mais veloz que puder definir.
 */

using System;

namespace AnaliseFaturamento
{
    class Program
    {
        static void Main()
        {
            // Dados de exemplo (substitua pelos seus dados reais)
             double[] faturamentoDiario = { 100.0, 200.0, 0.0, 300.0, 150.0, 0.0, 250.0, 0.0, 400.0 }; // Exemplo com 9 dias
             
            // Array indicando se o dia correspondente é um dia útil (1 = útil, 0 = não útil)
            int[] diasUteis = { 1, 1, 0, 1, 1, 0, 1, 0, 1 }; // Exemplo com também 9 dias

            double menorFaturamento = double.MaxValue;
            double maiorFaturamento = double.MinValue;
            double somaFaturamento = 0.0;
            int diasComFaturamento = 0;

            // Percorre o vetor para calcular os valores necessários
            for (int i = 0; i < faturamentoDiario.Length; i++)
            {
                if (faturamentoDiario[i] > 0 && diasUteis[i] == 1) // Verifica se o dia é útil e tem faturamento
                {
                    // Atualiza o menor e o maior faturamento
                    if (faturamentoDiario[i] < menorFaturamento) menorFaturamento = faturamentoDiario[i];
                    if (faturamentoDiario[i] > maiorFaturamento) maiorFaturamento = faturamentoDiario[i];
    
                    // Soma para calcular a média
                    somaFaturamento += faturamentoDiario[i];
                    diasComFaturamento++;
                }
            }

            // Calcula a média, evitando divisão por zero
            double mediaFaturamento = diasComFaturamento > 0 ? somaFaturamento / diasComFaturamento : 0.0;
    
            // Contabiliza os dias com faturamento superior à média
            int diasAcimaDaMedia = 0;
            for (int i = 0; i < faturamentoDiario.Length; i++)
            {
                if (faturamentoDiario[i] > mediaFaturamento && diasUteis[i] == 1)
                {
                    diasAcimaDaMedia++;
                }
            }

            // Exibe os resultados
            Console.WriteLine($"Menor faturamento: {menorFaturamento}");
            Console.WriteLine($"Maior faturamento: {maiorFaturamento}");
            Console.WriteLine($"Número de dias com faturamento acima da média: {diasAcimaDaMedia}");
        }
    }
}
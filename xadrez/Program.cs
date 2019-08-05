using System;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args) {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.terminada)
                {
                    Console.Clear();
                    Tela.imprimirTabuleiro(partida.tabuleiro);

                    Console.WriteLine();
                    Console.Write("Origem: ");
                    Posicao origem = Tela.lerPosicaoXadrez().ToPosicao();
                    Console.Write("Destino: ");
                    Posicao destino = Tela.lerPosicaoXadrez().ToPosicao();

                    partida.executaMovimento(origem, destino);
                }
            }
            catch (TabuleiroException erro)
            {
                Console.WriteLine(erro.Message);
            }
        }
    }
}

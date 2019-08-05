using System;
using tabuleiro;

namespace xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tabuleiro { get; private set; }
        private int turno;
        private Cor jogadorAtual;
        public bool terminada { get; private set; }

        public PartidaDeXadrez() {
            tabuleiro = new Tabuleiro(8, 8);
            turno = 1;
            jogadorAtual = Cor.Branca;
            terminada = false;
            colocarPecas();
        }

        public void executaMovimento(Posicao origem, Posicao destino) {
            Peca p = tabuleiro.retirarPeca(origem);
            p.incrementarQteMovimentos();
            Peca pecaCapturada = tabuleiro.retirarPeca(destino);
            tabuleiro.colocarPeca(p, destino);
        }

        private void colocarPecas() {
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 1).ToPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('c', 2).ToPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('d', 2).ToPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('e', 2).ToPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Branca), new PosicaoXadrez('e', 1).ToPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Branca), new PosicaoXadrez('d', 1).ToPosicao());

            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('c', 7).ToPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('c', 8).ToPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('d', 7).ToPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('e', 7).ToPosicao());
            tabuleiro.colocarPeca(new Torre(tabuleiro, Cor.Preta), new PosicaoXadrez('e', 8).ToPosicao());
            tabuleiro.colocarPeca(new Rei(tabuleiro, Cor.Preta), new PosicaoXadrez('d', 8).ToPosicao());
        }
    }
}

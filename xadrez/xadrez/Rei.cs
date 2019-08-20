using tabuleiro;
namespace xadrez
{
    class Rei : Peca
    {
        private PartidaDeXadrez partida;
        public Rei(Tabuleiro tabuleiro, Cor cor, PartidaDeXadrez partida) : base(tabuleiro, cor) {
            this.partida = partida;
        }

        public override string ToString() {
            return "R";
        }

        private bool podeMover(Posicao pos) {
            Peca p = tabuleiro.peca(pos);
            return p == null || p.cor != cor;
        }

        private bool testeTorreParaRoque(Posicao pos) {
            Peca p = tabuleiro.peca(pos);
            return p != null && p is Torre && p.cor == cor && p.quantidadeDeMovimentos == 0;
        }

        public override bool[,] movimentosPossiveis() {
            bool[,] matriz = new bool[tabuleiro.linhas, tabuleiro.colunas];
            Posicao pos = new Posicao(0, 0);
            //acima
            pos.definirValores(posicao.linha - 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //nordeste
            pos.definirValores(posicao.linha - 1, posicao.coluna + 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //direita
            pos.definirValores(posicao.linha, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //sudeste
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //abaixo
            pos.definirValores(posicao.linha + 1, posicao.coluna);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //sudoeste
            pos.definirValores(posicao.linha + 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //esquerda
            pos.definirValores(posicao.linha, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }
            //noroeste
            pos.definirValores(posicao.linha - 1, posicao.coluna - 1);
            if (tabuleiro.posicaoValida(pos) && podeMover(pos))
            {
                matriz[pos.linha, pos.coluna] = true;
            }

            //#jogadaespecial: roque
            if (quantidadeDeMovimentos == 0 && !partida.xeque)
            {
                //#jogada especial roque pequeno
                Posicao posicaoT1 = new Posicao(posicao.linha, posicao.coluna + 3);
                if (testeTorreParaRoque(posicaoT1))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna + 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna + 2);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null)
                    {
                        matriz[posicao.linha, posicao.coluna + 2] = true;
                    }
                }
                //#jogada especial roque grande
                Posicao posicaoT2 = new Posicao(posicao.linha, posicao.coluna - 4);
                if (testeTorreParaRoque(posicaoT2))
                {
                    Posicao p1 = new Posicao(posicao.linha, posicao.coluna - 1);
                    Posicao p2 = new Posicao(posicao.linha, posicao.coluna - 2);
                    Posicao p3 = new Posicao(posicao.linha, posicao.coluna - 3);
                    if (tabuleiro.peca(p1) == null && tabuleiro.peca(p2) == null && tabuleiro.peca(p3) == null)
                    {
                        matriz[posicao.linha, posicao.coluna - 2] = true;
                    }
                }
            }
            return matriz;
        }
    }
}

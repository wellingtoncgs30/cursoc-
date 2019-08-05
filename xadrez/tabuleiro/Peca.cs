﻿namespace tabuleiro
{
    class Peca
    {
        public Posicao posicao { get; set; }
        public Cor cor { get; protected set; }
        public int quantidadeDeMovimentos { get; protected set; }
        public Tabuleiro tabuleiro { get; protected set; }
        public Peca(Tabuleiro tabuleiro, Cor cor) {
            this.posicao = null;
            this.tabuleiro = tabuleiro;
            this.cor = cor;
            this.quantidadeDeMovimentos = 0;
        }
        public void incrementarQteMovimentos() {
            quantidadeDeMovimentos++;
        }
    }
}

﻿using System;
using tabuleiro;
using xadrez;

namespace xadrez
{
    class Program
    {
        static void Main(string[] args) {
            PosicaoXadrez pos = new PosicaoXadrez('c', 7);
            Console.WriteLine(pos.ToPosicao());
            Console.WriteLine(pos);
        }
    }
}

using System;

class JogoDaVelha
{
    static char[,] tabuleiro = {
        { '1', '2', '3' },
        { '4', '5', '6' },
        { '7', '8', '9' }
    };

    static int turno = 1; // 1 = Jogador X, 2 = Jogador O
    static bool jogoAtivo = true;

    static void Main()
    {
        while (jogoAtivo)
        {
            Console.Clear();
            MostrarTabuleiro();
            Jogar();
            VerificarVencedor();
        }
        Console.WriteLine("Fim do jogo!");
    }

    static void MostrarTabuleiro()
    {
        Console.WriteLine("Jogo da Velha");
        Console.WriteLine();

        for (int i = 0; i < 3; i++)
        {
            Console.WriteLine($" {tabuleiro[i, 0]} | {tabuleiro[i, 1]} | {tabuleiro[i, 2]} ");
            if (i < 2)
                Console.WriteLine("---|---|---");
        }
        Console.WriteLine();
    }

    static void Jogar()
    {
        char jogador = turno == 1 ? 'X' : 'O';
        Console.Write($"Jogador {jogador}, escolha uma posição (1-9): ");
        string entrada = Console.ReadLine();

        if (int.TryParse(entrada, out int posicao) && posicao >= 1 && posicao <= 9)
        {
            int linha = (posicao - 1) / 3;
            int coluna = (posicao - 1) % 3;

            if (tabuleiro[linha, coluna] != 'X' && tabuleiro[linha, coluna] != 'O')
            {
                tabuleiro[linha, coluna] = jogador;
                turno = turno == 1 ? 2 : 1;
            }
            else
            {
                Console.WriteLine("Posição já ocupada. Pressione qualquer tecla para tentar novamente.");
                Console.ReadKey();
            }
        }
        else
        {
            Console.WriteLine("Entrada inválida. Pressione qualquer tecla para tentar novamente.");
            Console.ReadKey();
        }
    }

    static void VerificarVencedor()
    {
        char vencedor = ' ';

        // Verificar linhas, colunas e diagonais
        for (int i = 0; i < 3; i++)
        {
            // Linhas
            if (tabuleiro[i, 0] == tabuleiro[i, 1] && tabuleiro[i, 1] == tabuleiro[i, 2])
                vencedor = tabuleiro[i, 0];

            // Colunas
            if (tabuleiro[0, i] == tabuleiro[1, i] && tabuleiro[1, i] == tabuleiro[2, i])
                vencedor = tabuleiro[0, i];
        }

        // Diagonais
        if (tabuleiro[0, 0] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 2])
            vencedor = tabuleiro[0, 0];

        if (tabuleiro[0, 2] == tabuleiro[1, 1] && tabuleiro[1, 1] == tabuleiro[2, 0])
            vencedor = tabuleiro[0, 2];

        if (vencedor == 'X' || vencedor == 'O')
        {
            Console.Clear();
            MostrarTabuleiro();
            Console.WriteLine($"Jogador {vencedor} venceu!");
            jogoAtivo = false;
        }
        else if (TabuleiroCompleto())
        {
            Console.Clear();
            MostrarTabuleiro();
            Console.WriteLine("Empate!");
            jogoAtivo = false;
        }
    }

    static bool TabuleiroCompleto()
    {
        foreach (char c in tabuleiro)
        {
            if (c != 'X' && c != 'O')
                return false;
        }
        return true;
    }
}

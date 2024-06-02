using MemoryGameLogic;
using System;
using Ex02.ConsoleUtils;

namespace UserInterface
{
    public class MemoryGamePlay
    {
        MemoryGameInformation m_Game;
        public bool m_isNonPlayerCharacter = false;
        public void StartGame()
        {
            bool userEndGame = false;
            bool startGame = true;
            

            while (!InputHandler.EndGame(m_Game) || !userEndGame)
            {
                if (startGame)
                {
                    PrintStartOfGameAndInitializeIt();
                }
                printBoard();
            }
        }

        public void printBoard()
        {
            for (int i = 0; i < m_Game.BoardGameWidth; i++)
            {
                for (int j = 0; i < m_Game.BoardGameHeight * 2; i++) // CHANGE THE "*2" !!!!!!!!!!
                {
                    if (i % 2 == 0)
                    {
                        MemoryGameCard currentCard = m_Game.GetCard(i, j);
                        //if (currentCard.CardWasFound)
                        {
                            if (i == 0)
                            {
                                Console.Write("    ");
                                char column = (char)('A' + i);
                            }
                            else
                            {
                                Console.Write(j + " | ");
                                Console.Write("  " + currentCard.CardLetter + " |");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine(" =");
                    }
                }
            }
        }
        public void PrintStartOfGameAndInitializeIt()
        {
            Console.WriteLine("Welcome to Memory Game !");
            InitializeGame();
        }
        public void InitializeGame()
        {
            string firstPlayerName, secondPlayerName = null;
            bool isNonPlayerCharacter = false;
            int gameBoardHight, gameBoardWidth;
            getCharectersNamesFromUser(out firstPlayerName, secondPlayerName, ref isNonPlayerCharacter);
            getGameBoardSizeFromUser(out gameBoardHight, out gameBoardWidth);
            m_Game = new MemoryGameInformation(gameBoardWidth, gameBoardHight, firstPlayerName, secondPlayerName, isNonPlayerCharacter);
        }

        static void getCharectersNamesFromUser(out string firstPlayerName, string secondPlayerName, ref bool isNonPlayerCharacter)
        {
            Console.WriteLine("Please write the first player name: ");
            firstPlayerName = Console.ReadLine();
            Console.WriteLine(@"
Please choose you opponent:
1. Against another user.
2. Against the PC.");
            int playerChooses = int.Parse(Console.ReadLine());
            while (!InputHandler.NumberOfPlayersIsGood(playerChooses))
            {
                Console.WriteLine("The numbers of players that you enter isn't good please try again. ");
                playerChooses = int.Parse(Console.ReadLine());
            }
            if (playerChooses == 1)
            {
                Console.WriteLine("Please write the second player name: ");
                secondPlayerName = Console.ReadLine();
            }
            else
            {
                isNonPlayerCharacter = true;
            }
            Console.WriteLine("Please write the second player name: ");
        }

        static void getGameBoardSizeFromUser(out int gameBoardHight, out int gameBoardWidth)
        {
            Console.WriteLine("Please enter the hight and width of the board game: ");
            gameBoardHight = int.Parse(Console.ReadLine());
            gameBoardWidth = int.Parse(Console.ReadLine());
            while (!InputHandler.HightAndWidthIsGood(gameBoardHight, gameBoardWidth))
            {
                Console.WriteLine("The numbers that you enter isn't good please try again. ");
                gameBoardHight = int.Parse(Console.ReadLine());
                gameBoardWidth = int.Parse(Console.ReadLine());
            }
        }

    }
}

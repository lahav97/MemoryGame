using MemoryGameLogic;
using System;
using Ex02.ConsoleUtils;

namespace UserInterface
{
    public class MemoryGamePlay
    {
        private MemoryGameInformation m_Game;
        private bool m_isNonPlayerCharacter = false;
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
            int numberOfEachLetterAtTheBeginning = 2;
            for (int i = 0; i < m_Game.BoardGameWidth; i++)
            {
                for (int j = 0; i < m_Game.BoardGameHeight * numberOfEachLetterAtTheBeginning; i++)
                {
                    if (i % 2 == 0)
                    {
                        MemoryGameCard currentCard = m_Game.GetCard(i, j);
                        if (currentCard.CardWasFound)
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
            string firstPlayerName, secondPlayerName = null, nonPlayerCharacterName = null;
            bool isNonPlayerCharacter = false;
            int gameBoardHight, gameBoardWidth;
            getCharectersNamesFromUser(out firstPlayerName, ref secondPlayerName, ref nonPlayerCharacterName, ref isNonPlayerCharacter);
            getGameBoardSizeFromUser(out gameBoardHight, out gameBoardWidth);
            m_Game = new MemoryGameInformation(gameBoardWidth, gameBoardHight, firstPlayerName, secondPlayerName, nonPlayerCharacterName, isNonPlayerCharacter); //Check with Smadar
        }

        static void getCharectersNamesFromUser(out string io_firstPlayerName, ref string io_secondPlayerName, ref string io_nonPlayerCharacter, ref bool i_isNonPlayerCharacter) //Check input parameters
        {
            Console.WriteLine("Please write the first player name: ");
            io_firstPlayerName = Console.ReadLine();
            Console.WriteLine(@"
Please choose you opponent:
1. Against another user.
2. Against the PC.");
            int playerChooses = int.Parse(Console.ReadLine());
            InputHandler.CheckIfChosenOptionValid(ref playerChooses);
            if (playerChooses == 1)
            {
                Console.WriteLine("Please write the second player name: ");
                io_secondPlayerName = Console.ReadLine();
            }
            else
            {
                Console.WriteLine("Please write the non-player charecter name: ");
                io_nonPlayerCharacter = Console.ReadLine();
                i_isNonPlayerCharacter = true;
            }
        }

        static void getGameBoardSizeFromUser(out int gameBoardHight, out int gameBoardWidth)
        {
            Console.WriteLine("Please enter the hight and width of the board game (minimum of 4x4 and maximum of 6x6): ");
            gameBoardHight = int.Parse(Console.ReadLine());
            gameBoardWidth = int.Parse(Console.ReadLine());
            InputHandler.CheckIfHightAndWidthIsValid(ref gameBoardHight, ref gameBoardWidth);
        }
    }
}

using MemoryGameLogic;
using System;

namespace UserInterface
{
    internal class InputHandler
    {
        public static bool EndGame(MemoryGameInformation i_Game)
        {
            return i_Game.CurrentNumberOfCardsNotFound == 0;
        }

        public static void CheckIfChosenOptionValid(ref int io_numberOfPlayers)
        {
            while (!NumberOfPlayersIsGood(io_numberOfPlayers))
            {
                Console.WriteLine("The numbers of players that you enter isn't good please try again. ");
                io_numberOfPlayers = int.Parse(Console.ReadLine());
            }
        }

        public static void CheckIfHightAndWidthIsValid(ref int io_gameBoardHight, ref int io_gameBoardWidth)
        {
            while (!HightAndWidthIsGood(io_gameBoardHight, io_gameBoardWidth))
            {
                Console.WriteLine("The numbers that you enter aren't good please try again.");
                io_gameBoardHight = int.Parse(Console.ReadLine());
                io_gameBoardWidth = int.Parse(Console.ReadLine());
            }
        }


        public static bool NumberOfPlayersIsGood(int i_playerChooses)
        {
            return i_playerChooses == 1 || i_playerChooses == 2;
        }

        public static bool HightAndWidthIsGood(int i_gameBoardHight, int i_gameBoardWidth)
        {
            return (i_gameBoardHight * i_gameBoardWidth > 16) &&
                (i_gameBoardHight * i_gameBoardWidth < 36) &&
                (i_gameBoardHight * i_gameBoardWidth) % 2 == 0;
        }
    }
}

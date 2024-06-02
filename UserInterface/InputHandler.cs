using MemoryGameLogic;

namespace UserInterface
{
    internal class InputHandler
    {
        public static bool EndGame(MemoryGameInformation i_Game)
        {
            return i_Game.CurrentNumberOfCardsNotFound == 0;
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

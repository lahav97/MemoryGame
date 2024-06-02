namespace MemoryGameLogic
{
    public class PlayerInformation
    {
        string m_Name;
        bool m_IsNonPlayerCharecter;
        int m_GamesWinCounter = 0;
        int m_countNumberOfCardsFuondByPlayer = 0;

        public PlayerInformation(string name, bool isNonPlayerCharecter)
        {
            m_Name = name;
            m_IsNonPlayerCharecter = isNonPlayerCharecter;
        }
        
        public int NumberOfCardsFoundByPlayer
        {
            get { return m_countNumberOfCardsFuondByPlayer; }
            set { m_countNumberOfCardsFuondByPlayer = value; }
        }
        public int NumberOfGamesWonByPlayer
        {
            get { return m_GamesWinCounter; }
            set { m_GamesWinCounter = value; }
        }
        public string PlayerName
        {
            get { return m_Name; }
        }
        public bool IsNonPlayerCharecter
        {
            get { return m_IsNonPlayerCharecter; }
        }
    }
}

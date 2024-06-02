namespace MemoryGameLogic
{
    public class MemoryGameCard
    {
        private char m_CardLetter;
        private bool m_CardWasFound = false;

        public MemoryGameCard(char cardLetter)
        {
            m_CardLetter = cardLetter;
        }

        public bool CardWasFound
        {
            get { return m_CardWasFound; }
            set { m_CardWasFound = value; }
        }
        public char CardLetter
        {
            get { return m_CardLetter; }
            set { m_CardLetter = value; }
        }

    }
}

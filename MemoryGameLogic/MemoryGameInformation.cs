using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGameLogic
{
    public class MemoryGameInformation
    {
        private static int s_NumberOfSameCardInGame = 2;
        PlayerInformation m_PlayerOne;
        PlayerInformation m_PlayerTwo;

        int m_BoardGameWidth;
        int m_BoardGameHeight;
        int m_CurrentNumberOfCardsNotFound;


        public MemoryGameCard[,] m_MemoryGameBoard;

        public MemoryGameInformation(int boardGameWidth, int boardGameHeight,string playerOneName, string playerTwoName, bool playerTwoIsNonPlayerCharecter)
        {
            m_BoardGameWidth = boardGameWidth;
            m_BoardGameHeight = boardGameHeight;
            m_CurrentNumberOfCardsNotFound = (boardGameHeight * boardGameWidth) / s_NumberOfSameCardInGame;
            m_PlayerOne = new PlayerInformation(playerOneName, false);
            m_PlayerTwo = new PlayerInformation(playerTwoName, playerTwoIsNonPlayerCharecter);
            m_MemoryGameBoard = new MemoryGameCard[boardGameHeight, boardGameWidth];
            ShuffleDeckOfCards();
        }

        public int CurrentNumberOfCardsNotFound
        {
            get { return m_CurrentNumberOfCardsNotFound; }
        }
        public int BoardGameWidth
        {
            get { return m_BoardGameWidth; }
        }
        public int BoardGameHeight
        { 
            get { return m_BoardGameHeight; } 
        }

        public void ShuffleDeckOfCards()
        {
            List<char> cardsLetters = new List<char>();
            int numberOfCardsInDeck = m_BoardGameWidth * m_BoardGameHeight;

            for (int i = 0; i < numberOfCardsInDeck / s_NumberOfSameCardInGame; i++ )
            {
                AddALetterToListTwice(cardsLetters, (char)('A' + i));
            }
            ShuffleList(cardsLetters);

            int currentRow = 0;
            int currentColumn = 0;

            foreach (char letter in cardsLetters)
            {
                m_MemoryGameBoard[currentRow, currentColumn] = new MemoryGameCard(letter);
                currentColumn++;

                if (currentColumn == m_BoardGameWidth)
                {
                    currentColumn = 0;
                    currentRow++;
                }
            }
        }

        static void AddALetterToListTwice(List<char> io_listOfLetters, char i_letter)
        {
            io_listOfLetters.Add(i_letter);
            io_listOfLetters.Add(i_letter);
        }

        static void ShuffleList(List<char> io_list)
        {
            Random random = new Random();
            io_list = io_list.OrderBy(x => random.Next()).ToList();
        }

        public MemoryGameCard GetCard(int i_rowOfCard, int i_columnOfCard)
        {
            return m_MemoryGameBoard[i_rowOfCard, i_columnOfCard];
        }

        public bool CheckIfCardIsOpen(int i_rowOfCard, int  i_columnOfCard)
        {
            return m_MemoryGameBoard[i_rowOfCard, i_columnOfCard].CardWasFound;
        }

        public bool CompareCards(PlayerInformation io_player, int i_rowOfCardOne, int i_columnOfCardOne, int i_rowOfCardTwo, int i_columnOfCardTwo)
        {
            MemoryGameCard cardOne = m_MemoryGameBoard[i_rowOfCardOne, i_columnOfCardOne];
            MemoryGameCard cardTwo = m_MemoryGameBoard[i_rowOfCardTwo, i_columnOfCardTwo];

            if (CardsAreEquel(cardOne, cardTwo))
            {
                cardOne.CardWasFound = true;
                cardTwo.CardWasFound = true;
                io_player.NumberOfCardsFoundByPlayer++;
                m_CurrentNumberOfCardsNotFound--;
            }

            return CardsAreEquel(cardOne, cardTwo);
        }

        private bool CardsAreEquel(MemoryGameCard i_cardOne, MemoryGameCard i_cardTwo)
        {
            return i_cardOne.CardLetter == i_cardTwo.CardLetter;
        }
    }
}

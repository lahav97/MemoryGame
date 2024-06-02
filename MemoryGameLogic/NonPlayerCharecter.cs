using System;
using System.Collections.Generic;
using System.Linq;

namespace MemoryGameLogic
{
    public class NonPlayerCharecter
    {
        
        char[,] m_CardsSeen;
        double m_likelihoodOfRemmemberingCard;

        public NonPlayerCharecter()
        {

        }
        static void PickACard(int o_RowOfCard, int o_ColumnOfCard)
        {

        }

        static void RemmemberCardThatWasShown(int i_RowOfCard, int i_ColumnOfCard, char LetterOfCard)
        {
            
        }

        /*static bool GetRandomBoolean()
        {
            Random random = new Random();
            double randomNumber = random.NextDouble();

            return randomNumber < m_likelihoodOfRemmemberingCard;
        }*/
    }
}

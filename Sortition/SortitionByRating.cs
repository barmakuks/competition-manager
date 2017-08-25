using System;
using System.Collections.Generic;
using System.Text;

namespace Sortition
{
    public class SortitionByRating
    {
        /// <summary>
        /// ¬озвращает пор€док рассеивани€ игроков по ќлимпийской системе
        /// </summary>
        /// <param name="numberOfPlayers"> оличество игроков, дл€ которого формировать сетку</param>
        /// <returns>возвращает масив, где 
        /// mas[i] - номер игрока, который должен зан€ть в сетке i-е место</returns>
        public static int[] GetOlympicSortitionOrder(int numberOfPlayers)
        {
            int level = 1;
            while (level < numberOfPlayers) level *= 2;
            Node node = new Node(1, 1, level);
            int[] mas = new int[level];
            int current = 0;
            FillArray(node, mas, level, ref current);
            return mas;
        }

        private static void FillArray(Node node, int[] mas, int level, ref int current)
        {
            if (node.Level == level)
            {
                mas[current] = node.PlayerId;
                current++;
            }
            else
            {
                if (node.First != null)
                    FillArray(node.First, mas, level, ref current);
                if (node.Second != null)
                    FillArray(node.Second, mas, level, ref current);
            }
        }

        /// <summary>
        /// ¬озвращает пор€док рассеивани€ игроков по Ўвейцарской системе
        /// </summary>
        /// <param name="numberOfPlayers"> оличество игроков, дл€ которого формировать сетку</param>
        /// <returns>возвращает масив, где 
        /// mas[i] - номер игрока, который должен зан€ть в сетке i-е место</returns>
        public static int[] GetSwissSortitionOrder(int numberOfPlayers)
        {
            if (numberOfPlayers % 2 != 0)
                numberOfPlayers++;
            int[] mas = new int[numberOfPlayers];
            for (int i = 0; i < numberOfPlayers / 2; i++) 
            {
                mas[i ] = i * 2 + 1;
                mas[i + numberOfPlayers / 2] = i * 2 + 2;
            }
            return mas;
        }
    }
    internal class Node
    {
        internal int Level;
        internal int PlayerId;
        internal Node First;
        internal Node Second;
        public override string ToString()
        {
            return PlayerId.ToString();
        }
        internal Node(int aLevel, int playerId, int TopLevel)
        {
            Level = aLevel;
            PlayerId = playerId;
            if (aLevel < TopLevel)
            {
                First = new Node(aLevel * 2, playerId, TopLevel);
                Second = new Node(aLevel * 2, (Level * 2 + 1) - playerId, TopLevel);
            }
        }
    }
}

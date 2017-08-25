using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TA.CompetitionControllers
{
    public class SeedPair
    {
        public int playerIdA = -1;
        public int playerIdB = -1;
        public string playerNameA = "";
        public string playerNameB = "";
        public bool Contains(int id)
        {
            return playerIdA == id || playerIdB == id;
        }
        public SeedPair(int A, int B)
        {
            playerIdA = A;
            playerIdB = B;
        }
        public override int GetHashCode()
        {
            return (playerIdA * 10000 + playerIdB).GetHashCode();
        }
        public override bool Equals(object obj)
        {
            if (obj is SeedPair)
            {
                SeedPair other = obj as SeedPair;
                return (other.playerIdA == playerIdA && other.playerIdB == playerIdB) || (other.playerIdB == playerIdA && other.playerIdA == playerIdB);
            }
            return base.Equals(obj);
        }
        public override string ToString()
        {
            if (playerIdA < playerIdB)
                return String.Format("{0:d2} vs {1:d2}", playerIdA, playerIdB);
            else
                return String.Format("{0:d2} vs {1:d2}", playerIdB, playerIdA);
        }
    }
    public class SwissSeeder
    {
        /// <summary>
        /// True, если матч с участием playerId присутствует в списке матчей
        /// </summary>
        /// <param name="playerId">Id игрока</param>
        /// <param name="matches">Список матчей</param>
        /// <returns></returns>
        private static bool PlayerIn(int playerId, SeedPair[] matches, int max_index)
        {
            for (int i = 0; i < max_index; i++)
            {
                if (matches[i].Contains(playerId))
                    return true;
            }
            return false;
        }
        private static bool MatchIn(SeedPair match, SeedPair[] matches)
        {
            foreach (SeedPair m in matches)
            {
                if (m.Equals(match))
                    return true;
            }
            return false;
        }
        /// <summary>
        /// Подыскивает очередную пару для матча в швейцарской системе
        /// </summary>
        /// <param name="players">Полный список игроков</param>
        /// <param name="matches">Полный список уже сыгранных матчей</param>
        /// <param name="new_matches">Список формируемых матчей</param>
        /// <param name="next_match_index">Индекс матча, для которого подыскиваются игроки</param>
        /// <returns>True, если пара игроков найдена и матч добавлен в список или если все игроки уже заняты</returns>
        public static bool Seed(int[] players, SeedPair[] matches, SeedPair[] new_matches, int next_match_index)
        {
            int match_count = players.Length / 2;

            if (next_match_index >= match_count) //Если необходимое количестсво матчей уже набрано
                return true;                     //то завершаем рассеивание   
            for (int i = 0; i < players.Length - 1; i++)
            {
                if (!PlayerIn(players[i], new_matches, next_match_index))
                {
                    for (int j = i + 1; j < players.Length; j++)
                    {
                        if (!PlayerIn(players[j], new_matches, next_match_index))
                        {
                            SeedPair match = new SeedPair(players[i], players[j]);
                            if (!MatchIn(match, matches))
                            {
                                new_matches[next_match_index] = match;
                                if (Seed(players, matches, new_matches, next_match_index + 1))
                                    return true;
                                else new_matches[next_match_index] = null;
                            }
                        }
                    }
                }
            }
            return false;
        }
    }
    public class RobinSeeder 
    {
        public static bool Seed(int[] players, SeedPair[] new_matches) 
        {
            List<int> players_A = new List<int>();
            List<int> players_B = new List<int>();
            // Делим список на две равные части
            for (int i = 0; i < players.Length; i+=2) 
            {
                players_A.Add(players[i]);
                players_B.Add(players[i + 1]);
            }
            int index = 0;
            for (int i = 0; i < players.Length - 1; i++) // количество  туров равно Кол-во игроков - 1
            {
                // Формируем пары 
                for (int j = 0; j < players_A.Count; j++)
                    new_matches[index++] = new SeedPair(players_A[j], players_B[j]);
                // Прокручиваем списки для следуюущего круга
                players_B.Insert(0, players_A[1]);
                players_A.RemoveAt(1);
                players_A.Add(players_B[players_B.Count - 1]);
                players_B.RemoveAt(players_B.Count - 1);
            }
            return true;    
        }
    }
}

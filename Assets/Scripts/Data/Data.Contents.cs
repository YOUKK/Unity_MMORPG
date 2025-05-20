using System.Collections.Generic;
using System;


namespace Data
{
    #region Stat

    [Serializable] // 아래 메모리를 파일로 변환할 수 있음
    public class Stat
    {
        public int level;
        public int hp;
        public int attack;
    }

    [Serializable]
    public class StatData : ILoader<int, Stat>
    {
        public List<Stat> stats = new List<Stat>();

        public Dictionary<int, Stat> MakeDict()
        {
            Dictionary<int, Stat> dict = new Dictionary<int, Stat>();
            foreach (Stat stat in stats)
                dict.Add(stat.level, stat);

            return dict;
        }
    }

    #endregion
}
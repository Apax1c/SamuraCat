using SamuraCat.Constants;
using UnityEngine;

namespace CodeBase.Game.Cat
{
    public class CatData : MonoBehaviour
    {
        public CatType Type { get; private set; }
        
        private int _id;
        
        public void Construct(int id)
        {
            _id = id;
            SetType();
        }

        private void SetType()
        {
            const int bigCatId = (int)CatType.Big;
            const int katanaCatId = (int)CatType.Katana;
            const int parkourCatId = (int)CatType.Parkour;
            const int killerCatId = (int)CatType.Killer;

            if (_id % bigCatId == 0)                 // 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120
                Type = CatType.Big;
            else if ((_id - 1) % katanaCatId == 0)   // 9, 19, 29, 39, 49...
                Type = CatType.Katana;
            else if ((_id - 2) % parkourCatId == 0)  // 10, 22, 34, 46, 58, 70, 82, 94, 106, 118
                Type = CatType.Parkour;
            else if ((_id - 4) % killerCatId == 0)   // 20, 44, 68, 92, 116
                Type = CatType.Killer;
            else
                Type = CatType.Default;
        }

        public object GetId() => 
            _id;
    }
}
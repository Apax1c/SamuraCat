using CodeBase.Game.Cats;
using CodeBase.Game.Placements;
using UnityEngine;

namespace CodeBase.Game
{
    public class ConfirmedRow : MonoBehaviour
    {
        [SerializeField]
        private ConfirmedPlacement[] Placements = new ConfirmedPlacement[5];

        public void AddCat(Cat cat)
        {
            foreach (ConfirmedPlacement placement in Placements)
            {
                if (!placement.IsCatSet)
                {
                    placement.SetCat(cat);
                    return;
                }
            }
        }
    }
}
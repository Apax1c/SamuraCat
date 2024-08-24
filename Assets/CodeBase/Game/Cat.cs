using SamuraCat.Constants;
using SamuraCat.Game;
using UnityEngine;
using UnityEngine.EventSystems;

namespace CodeBase.Game
{
    public class Cat : MonoBehaviour, IPointerClickHandler
    {
        private int _id;
        private CatsContainer _catsContainer;

        public int Id
        {
            get { return _id; }
            private set
            {
                if (value > 0 && value <= 120)
                {
                    _id = value;
                }
            }
        }

        public CatType Type { get; private set; }

        public Cat Construct(int id, CatsContainer catsContainer)
        {
            _catsContainer = catsContainer;
            
            Cat newCat = Instantiate(this);
            newCat.Id = id;
            newCat.SetType();

            return newCat;
        }

        private void SetType()
        {
            int bigCatId = (int)CatType.Big;
            int katanaCatId = (int)CatType.Katana;
            int parkourCatId = (int)CatType.Parkour;
            int killerCatId = (int)CatType.Killer;

            if (Id % bigCatId == 0)                 // 8, 16, 24, 32, 40, 48, 56, 64, 72, 80, 88, 96, 104, 112, 120
            {
                Type = CatType.Big;
            }
            else if (Id - 1 % katanaCatId == 0)     // 9, 19, 29, 39, 49...
            {
                Type = CatType.Katana;
            }
            else if (Id - 2 % parkourCatId == 0)    // 10, 22, 34, 46, 58, 70, 82, 94, 106, 118
            {
                Type = CatType.Parkour;
            }
            else if (Id - 4 % killerCatId == 0)     // 20, 44, 68, 92, 116
            {
                Type = CatType.Killer;
            }
            else
            {
                Type = CatType.Default;
            }
        }

        public void OnPointerClick(PointerEventData eventData)
        {
            GameObject clickedObject = eventData.pointerCurrentRaycast.gameObject;
            Cat cat = clickedObject.GetComponent<Cat>();

            _catsContainer.SetCat(cat);
        }
    }
}
using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Cat;
using UnityEngine;

namespace CodeBase.Game
{
	public class CatsContainer : MonoBehaviour
	{
        private List<CatData> _catsList;
        private List<GameObject> _platformsList;
        
        private const float DistanceBetweenCats = 0.74f;

        public void Construct(List<GameObject> platforms)
        {
            _platformsList = platforms;
        }
        
        private void SortCats()
        {
            _catsList = _catsList.OrderBy(b => b.GetId()).ToList();

            for (int i = 0; i < _platformsList.Count; i++)
            {
                Vector3 newPosition = GetPositionForNewCat(i);

                Platform platform = SetPlatformOnNewPosition(i, newPosition);

                if (i >= 0 && i < _catsList.Count)
                {
                    CatData catData = SetCatOnNewPosition(i, newPosition);

                    platform.SetNumber(catData.GetId());
                }
                else
                    platform.ClearNumber();
            }
        }

        public void RemoveCat(CatData catDataToRemove)
        {
            _catsList.Remove(catDataToRemove);
            SortCats();
        }

        public void UpdateCatsList(List<CatData> cats)
        {
            _catsList = cats;
            SortCats();
        }

        private static Vector3 GetPositionForNewCat(int i)
        {
            float xPosition = -3.33f + DistanceBetweenCats * i;
            return new Vector3(xPosition, 0, 0);
        }

        private Platform SetPlatformOnNewPosition(int i, Vector3 newPosition)
        {
            GameObject platformGameObject = _platformsList[i];
            platformGameObject.transform.localPosition = newPosition;
            
            return platformGameObject.GetComponent<Platform>();
        }

        private CatData SetCatOnNewPosition(int i, Vector3 newPosition)
        {
            CatData catData = _catsList[i];
            catData.transform.localPosition = newPosition;
            return catData;
        }
    }
}
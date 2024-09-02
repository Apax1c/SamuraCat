using System.Collections.Generic;
using System.Linq;
using CodeBase.Game.Cats;
using UnityEngine;

namespace CodeBase.Game
{
	public class CatsContainer : MonoBehaviour
	{
        private List<Cat> _catsList;
        private List<GameObject> _platformsList;
        
        private const float DistanceBetweenCats = 0.74f;

        public void Construct(List<GameObject> platforms)
        {
            _platformsList = platforms;
        }

        public void RemoveCat(Cat catToRemove)
        {
            _catsList.Remove(catToRemove);
            SortCats();
        }

        public void UpdateCatsList(List<Cat> cats)
        {
            _catsList = cats;
            SortCats();
        }

        private void SortCats()
        {
            ReorderCatsList();

            for (int i = 0; i < _platformsList.Count; i++)
            {
                Vector3 newPosition = GetPositionForCatAndPlatform(i);
                
                Placement.Placement placement = SetPlatformOnNewPosition(i, newPosition);

                if (i >= 0 && i < _catsList.Count)
                {
                    Cat cat = SetCatOnNewPosition(i, newPosition);

                    placement.SetNumber(cat.ID);
                }
                else
                {
                    placement.ClearNumber();
                }
            }
        }

        private void ReorderCatsList() => 
            _catsList = _catsList.OrderBy(b => b.ID).ToList();

        private static Vector3 GetPositionForCatAndPlatform(int i)
        {
            float xPosition = -3.33f + DistanceBetweenCats * i;
            return new Vector3(xPosition, 0, 0);
        }

        private Placement.Placement SetPlatformOnNewPosition(int i, Vector3 newPosition)
        {
            GameObject platformGameObject = _platformsList[i];
            platformGameObject.transform.localPosition = newPosition;
            
            return platformGameObject.GetComponent<Placement.Placement>();
        }

        private Cat SetCatOnNewPosition(int i, Vector3 newPosition)
        {
            Cat cat = _catsList[i];
            cat.transform.localPosition = newPosition;
            return cat;
        }
    }
}
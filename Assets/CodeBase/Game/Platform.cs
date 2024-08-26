using TMPro;
using UnityEngine;

namespace CodeBase.Game
{
    public class Platform : MonoBehaviour
    {
        [SerializeField] private TextMeshPro CatNumberText;

        public void SetNumber(int catNumber)
        {
            CatNumberText.text = catNumber.ToString();
        }

        public void ClearNumber()
        {
            CatNumberText.text = "";
        }
    }
}
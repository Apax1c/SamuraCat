using UnityEngine;
using UnityEngine.UI;

namespace CodeBase.UI.MainScene
{
    public class NetworkStart : MonoBehaviour
    {
        [SerializeField] private Button _startHostButton;
        [SerializeField] private Button _startClientButton;

        private void Awake()
        {
            _startHostButton.onClick.AddListener(() =>
            {
                Debug.Log("HOST");
            });

            _startClientButton.onClick.AddListener(() =>
            {
                Debug.Log("Client");
            });
        }
    }
}
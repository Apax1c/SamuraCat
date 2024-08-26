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
                // TODO - Host connection
            });

            _startClientButton.onClick.AddListener(() =>
            {
                // TODO - Client connection
            });
        }
    }
}
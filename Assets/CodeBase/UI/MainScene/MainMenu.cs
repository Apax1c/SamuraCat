using CodeBase.Infrastructure.StateMachine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.MainScene
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button StartGameButton;
        private IGameStateMachine _stateMachine;
        
        [Inject]
        private void Construct(IGameStateMachine stateMachine)
        {
            _stateMachine = stateMachine;
        }
        
        private void Awake()
        {
            StartGameButton?.onClick.AddListener(StartSinglePlayer);
        }

        private void StartSinglePlayer()
        {
            SceneManager.LoadSceneAsync((int)Scenes.Game);
            
            _stateMachine.Enter<GameLoopState>();
            Debug.Log("Done");
        }

        private void OnDisable()
        {
            StartGameButton?.onClick.RemoveAllListeners();
        }
    }
}
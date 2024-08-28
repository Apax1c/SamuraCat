using CodeBase.Infrastructure.GlobalStateMachine;
using CodeBase.Infrastructure.GlobalStateMachine.States;
using CodeBase.Services.SceneLoader;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

namespace CodeBase.UI.MainScene
{
    public class MainMenu : MonoBehaviour
    {
        [SerializeField] private Button StartGameButton;
        private IStateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        [Inject]
        private void Construct(IStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }
        
        private void Awake()
        {
            StartGameButton?.onClick.AddListener(StartSinglePlayer);
        }

        private void StartSinglePlayer()
        {
            _sceneLoader.LoadScene(Scenes.Game, _stateMachine.Enter<GameLoopState>);
        }

        private void OnDisable()
        {
            StartGameButton?.onClick.RemoveAllListeners();
        }
    }
}
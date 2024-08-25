using CodeBase.Infrastructure.StateMachine;
using CodeBase.Services.SceneLoader;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private IGameStateMachine _gameStateMachine;
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(IGameStateMachine gameStateMachine) => 
            _gameStateMachine = gameStateMachine;

        private void Start()
        {
            _sceneLoader = new SceneLoader(this);
            
            if (SceneManager.GetActiveScene().buildIndex != (int)Scenes.Initial) 
                _sceneLoader.LoadScene(Scenes.MainMenu, () => _gameStateMachine.Initialize());
        }
    }
}
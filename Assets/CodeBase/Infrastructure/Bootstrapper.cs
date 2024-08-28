using CodeBase.Infrastructure.GlobalStateMachine;
using CodeBase.Services.SceneLoader;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private IStateMachine _stateMachine;
        private SceneLoader _sceneLoader;

        [Inject]
        public void Construct(IStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Start()
        {
            _sceneLoader = new SceneLoader(this);
            
            if (SceneManager.GetActiveScene().buildIndex != (int)Scenes.Initial) 
                _sceneLoader.LoadScene(Scenes.Initial, () => _stateMachine.Initialize());
            else
                _stateMachine.Initialize();
        }
    }
}
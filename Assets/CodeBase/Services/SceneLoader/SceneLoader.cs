using System;
using System.Collections;
using CodeBase.Infrastructure;
using CodeBase.Infrastructure.StateMachine;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Services.SceneLoader
{
    public class SceneLoader
    {
        private readonly ICoroutineRunner _coroutineRunner;
        
        public SceneLoader(ICoroutineRunner coroutineRunner) => 
            _coroutineRunner = coroutineRunner;

        public void LoadScene(Scenes scene, Action onComplete = null)
        {
            _coroutineRunner.StartCoroutine(LoadSceneAsync(scene, onComplete));
            SceneManager.LoadScene((int)scene);
        }
        
        private IEnumerator LoadSceneAsync(Scenes scene, Action onComplete = null)
        {
            if (SceneManager.GetActiveScene().buildIndex == (int)scene)
            {
                onComplete?.Invoke();
                yield break;
            }
            
            AsyncOperation waitNextScene = SceneManager.LoadSceneAsync((int)scene);

            while (!waitNextScene.isDone)
                yield return null;
            
            onComplete?.Invoke();
        }
    }
}
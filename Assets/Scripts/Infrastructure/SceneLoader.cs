using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Infrastructure
{
    public class SceneLoader
    {
        public void Load(string sceneName, Action onLoaded = null)
        {
            AsyncOperation sceneLoading =  SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);

            sceneLoading.completed += _ => onLoaded?.Invoke();
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Scripts.Infrastructure
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

using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class SceneLoader : MonoBehaviour
{
    private string targetSceneName;

    public void LoadSceneByName(string sceneName)
    {
        targetSceneName = sceneName;
        Invoke(nameof(LoadScene), 0.2f);
        
    }
    private void LoadScene()
    {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);
        asyncLoad.allowSceneActivation = false;

        while (!asyncLoad.isDone)
        {

            if (asyncLoad.progress >= 0.9f)
            {
                asyncLoad.allowSceneActivation = true;
                return;
            }

        }
    }
}

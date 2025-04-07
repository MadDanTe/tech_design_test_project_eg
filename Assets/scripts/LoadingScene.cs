using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] private Slider progressBar;
    [SerializeField] private string targetSceneName = "main_menu_scene";
    [SerializeField] private GameObject character;

    private bool ready = false;
    private Camera mainCamera;
    private bool isInView = true;
    private AsyncOperation asyncLoad;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(LoadSceneAsync());
        mainCamera = Camera.main;
    }

    private void Update()
    {
        Vector2 viewportPos= mainCamera.WorldToViewportPoint(character.transform.position);

        isInView = viewportPos.x >= 0 && viewportPos.x <= 1;

        asyncLoad.allowSceneActivation = !isInView && ready ? true : false;


    }

    private IEnumerator LoadSceneAsync()
    {
        asyncLoad = SceneManager.LoadSceneAsync(targetSceneName);
        asyncLoad.allowSceneActivation = false;


        while (!asyncLoad.isDone)
        {
            float progress = Mathf.Clamp01(asyncLoad.progress / 0.9f); 
            progressBar.value = progress;

            if (asyncLoad.progress >= 0.9f)
            {
                ready = true;
                MoveCharacter();
                yield return null;
            }

        }

    }

    private void MoveCharacter()
    {
        PlayerVisual playerVisual = character.GetComponent<PlayerVisual>();
        playerVisual.setStatus(true, 0);
        character.transform.position += new Vector3(1f, 0, 0) * 2 * Time.deltaTime;
    }
}

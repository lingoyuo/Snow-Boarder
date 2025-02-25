using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour
{
    public void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
        Time.timeScale = 1;
        //SceneManager.SetActiveScene(SceneManager.GetSceneByName(sceneName));
    }
}

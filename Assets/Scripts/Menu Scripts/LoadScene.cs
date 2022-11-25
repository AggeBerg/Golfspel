using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadScene : MonoBehaviour
{
    public void LoadScenes(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
}

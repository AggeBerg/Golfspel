using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class LoadLevel : MonoBehaviour
{
    public LevelPreview Level;

    public void onClick(){
        SceneManager.LoadScene(Level.levelList[Level.levelIndex]);
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class CloseEscMenu : MonoBehaviour
{
    private GameObject player;
    void Start(){

    }
    public void SelfDestruct(){

        player = GameObject.Find("/Player");
        player.GetComponent<PauseSinglePlayer>().CloseMenu();
    }
}

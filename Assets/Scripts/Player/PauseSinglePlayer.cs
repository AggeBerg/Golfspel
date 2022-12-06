using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseSinglePlayer : MonoBehaviour
{
    public GameObject escapeMenu;
    public GameObject UIParent;
    [NonSerialized] public bool menuIsOpen = false;
    private GameObject clone;
    void Start()
    {
        Time.timeScale=1;
    }

    public void OpenMenu(){
        clone = (GameObject )Instantiate(escapeMenu, new Vector3(0, 0, 0), Quaternion.identity);
        clone.transform.SetParent(UIParent.transform);
        Time.timeScale=0;
        menuIsOpen = true;
    }

    public void CloseMenu(){
        Destroy(clone);
        Time.timeScale=1;
        menuIsOpen = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            {

                if (menuIsOpen == false)
                {
                    OpenMenu();
                }
                else if(menuIsOpen == true)
                {
                    CloseMenu();
                }
            }
        

    }
}

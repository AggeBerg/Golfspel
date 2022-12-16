using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class LevelPreview : MonoBehaviour
{
    public int levelIndex = 0;
    public TMP_Text UIElem;
    public TMP_Text ParText;
    public string SelectedElement;
    public List<string> levelList = new List<string>();

    // Start is called before the first frame update
    void Start()
    {   
        UIElem = GetComponent<TextMeshProUGUI>();

        var info = new DirectoryInfo("./Assets/Scenes/Levels");
        var fileInfo = info.GetFiles();
        
        foreach (var file in fileInfo)
        {
            List<string> splitFile = new List<string>();
            if (Path.GetExtension(file.ToString()) == ".unity")
            {
                levelList.Add(Path.GetFileNameWithoutExtension(file.ToString()));
            }
        }
    }

    public void SayHi (){

    }


    // Update is called once per frame
    void Update()
    {
        
        UIElem.text = levelList[levelIndex];    
        SelectedElement = levelList[levelIndex];

        if(levelIndex == 0)
        {
            ParText.text = "4";
        }

        if (levelIndex == 1)
        {
            ParText.text = "5";
        }

        if (levelIndex == 2)
        {
            ParText.text = "6";
        }

        if (levelIndex == 3)
        {
            ParText.text = "4";
        }

    }
}

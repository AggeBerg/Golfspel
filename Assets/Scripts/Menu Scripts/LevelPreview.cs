using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using TMPro;


public class LevelPreview : MonoBehaviour
{
    public int levelIndex = 0;
    public TMP_Text UIElem;
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

    }
}

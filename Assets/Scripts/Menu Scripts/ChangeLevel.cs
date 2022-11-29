using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeLevel : MonoBehaviour
{
    public LevelPreview Level;
    // Start is called before the first frame update

    public void onClick(int change){

        if (Level.levelList.Count -1 > Level.levelIndex & change > 0){
            Level.levelIndex += 1;
        }
        
        
        else{
            if(Level.levelIndex > 0 & change < 0) {
                Level.levelIndex -= 1;
        }};
        
    }

}

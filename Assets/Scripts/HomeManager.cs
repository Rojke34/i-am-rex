using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HomeManager : MonoBehaviour {
 
    public void NextScene() {
        //Send to gameplay scene
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
}

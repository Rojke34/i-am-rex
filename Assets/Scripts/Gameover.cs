using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gameover : MonoBehaviour {
    // Start is called before the first frame update
    void Start() {
        Invoke("PlaySound", 0.5f);
    }

    void PlaySound() {
        FindObjectOfType<AudioManager>().Play("Gameover");
        Invoke("NextScene", 4);
    }

    void NextScene() {
        FindObjectOfType<LevelLoader>().LoadNextScene();
    }
   
}

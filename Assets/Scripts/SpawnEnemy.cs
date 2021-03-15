using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour {

    public GameObject[] enemies;
    public float minTime = 1f;
    public float maxTime = 2f;

    // Start is called before the first frame update
    void Start() {
        Spawn();
    }

    void Spawn() {
        GameObject random = enemies[Random.Range(0, enemies.Length)];

        Instantiate(random, transform.position, Quaternion.identity);

        Invoke("Spawn", Random.Range(minTime, maxTime));
    }
}

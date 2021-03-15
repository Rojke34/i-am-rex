using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Death : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("DestroyIt", 2f);
    }

    // Update is called once per frame
    void DestroyIt()
    {
        Destroy(gameObject);
    }
}

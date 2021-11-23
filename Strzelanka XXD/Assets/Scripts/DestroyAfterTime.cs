using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyAfterTime : MonoBehaviour
{
    //Variables
    private float annihilate = 0.0f;
    public float annihTime = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Destroys object after annihTime
        annihilate += 1 * Time.deltaTime;
        if (annihilate > annihTime) {
            Destroy(gameObject);
        }
    }
}

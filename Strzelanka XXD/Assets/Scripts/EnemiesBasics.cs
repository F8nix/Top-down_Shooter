using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemiesBasics : MonoBehaviour
{
    //Variables
    public float healthPoints = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //When it gets hit by HeroBullet
        //No hp left
        if (healthPoints <= 0) {
            Destroy(gameObject);
        }
    }
    //When it gets hit/collides with anything  --HeroBullet
    private void OnTriggerEnter(Collider other) {
        if (gameObject != other.gameObject.CompareTag("EnemyBullet"))
        {
            healthPoints--;
            Destroy(other.gameObject);
        }
    }
}

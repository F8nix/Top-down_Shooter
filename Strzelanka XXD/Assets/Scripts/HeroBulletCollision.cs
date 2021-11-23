using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroBulletCollision : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject != other.gameObject.CompareTag("Hero") && gameObject != other.gameObject.CompareTag("EnemyBullet")) {
            Destroy(gameObject);
        }
    }
    
}

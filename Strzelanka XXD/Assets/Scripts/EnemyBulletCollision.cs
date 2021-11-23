using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletCollision : MonoBehaviour
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
        if (gameObject != other.gameObject.CompareTag("Enemy") && gameObject != other.gameObject.CompareTag("HeroBullet"))
        {
            Destroy(gameObject);
        }
    }
}

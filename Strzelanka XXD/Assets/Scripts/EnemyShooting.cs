using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    //variables
    public float shootCounter = 0.0f;
    public float shootCounterFix = 0.0f;
    public float shootCounterRefresh = 60.0f;
    //Change to array later
    public float shootNow1 = 9.0f;
    public float shootNow2 = 41.0f;
    //Direction I want bullet to take
    public float bulletDirection = 180.0f;
    //
    private int alreadyShoot = 0;
    // nextShot must be alreadyShot + 1, nextShot2 by 2 etc... poorly
    private int nextShoot = 1;
    private int nextShoot2 = 2;
    // we want to take from game bullet prefab
    public GameObject enemyBulletPrefab;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Shooting counter
        shootCounterFix += 1 * Time.deltaTime;
        if (shootCounterFix >= 0.1f) {
            shootCounter += 1.0f;
            shootCounterFix -= 0.1f;
        }
        //creates insance of enemyBulletPrefab
        if (shootCounter == shootNow1 && alreadyShoot < nextShoot)
        {
            Instantiate(enemyBulletPrefab, transform.position, enemyBulletPrefab.transform.rotation * Quaternion.Euler(0.0f, bulletDirection, 0.0f));
            alreadyShoot += 1;
        }
        //Poorly made second shot prob there is better way
        if (shootCounter == shootNow2 && alreadyShoot < nextShoot2)
        {
            Instantiate(enemyBulletPrefab, transform.position, enemyBulletPrefab.transform.rotation * Quaternion.Euler(0.0f, bulletDirection, 0.0f));
            alreadyShoot += 1;
        }
        //loops Counter
        if (shootCounter >= shootCounterRefresh) {
            shootCounter = 0.0f;
            alreadyShoot = 0;
        }
    }
}

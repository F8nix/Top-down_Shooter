
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControls : MonoBehaviour
{
    //variables
    private float horizontalInput;
    private float verticalInput;
    public float xRange = 127.0f;
    private float worldCentreCorrection = 487.0f;
    // we want to take from game bullet prefab
    public GameObject heroBulletPrefab;
    //public float zRange = 50.0f;
    public float speed = 75.0f;
    //tilt variables
    public float smooth = 10.0f;
    public float tiltAngle = 30.0f;
    public float tiltAngleFrontBack = 15.0f;
    //shooting variables
    public float shootCounter = 0.0f;
    public float counterFix = 0.0f;
    public float cantShootNow = 2.0f;
    //diretion I want to shoot in
    public float bulletDirection = 0.0f;
    //overclock system
    private int alreadyOverclocked = 0;
    public float overclockCounter = 0.0f;
    public float maxOverclock = 16.0f;
    //sloppy slowing
    public float passiveSpeed = 25;
    public float slower = 0.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //If hero goes outside of playable area - spoiler he can't
        if (transform.position.x < -xRange + worldCentreCorrection) {
            transform.position = new Vector3(-xRange + worldCentreCorrection, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange + worldCentreCorrection)
        {
            transform.position = new Vector3(xRange + worldCentreCorrection, transform.position.y, transform.position.z);
        }
        //Getting from Unity input
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");
        //Moving forward
        transform.position = transform.position + (Vector3.forward * Time.deltaTime * speed * verticalInput);
        transform.position = transform.position + (Vector3.right * Time.deltaTime * speed * horizontalInput);
        //Shooting counter
        counterFix += 1 * Time.deltaTime;
        if (counterFix >= 0.1f)
        {
            if (shootCounter > 0) {
                shootCounter -= 1.0f;
            }
            //Overclock cooling system
            if (overclockCounter > 0.0f)
            {
                overclockCounter -= 0.05f;
            }
            //Overcooling with only one negative -> slower cooling
            if (overclockCounter > -1.5f)
            {
                overclockCounter -= 0.05f;
            }
            counterFix -= 0.1f;
        }
        //creates insance of enemyBulletPrefab

        //Shooting and overclock mechanic
        //if system is not overheated, you can shoot with spacebar
        if (overclockCounter < maxOverclock)
        {
            //In moment between shootNowRange1 and shootNowRange2; no spamming
            if (Input.GetKeyDown(KeyCode.Space) && shootCounter <= cantShootNow)
            {
                Instantiate(heroBulletPrefab, transform.position, heroBulletPrefab.transform.rotation);
                overclockCounter += 1.0f;
                shootCounter += 3.0f;
            }
            //You overheated system
        } else if (overclockCounter >= maxOverclock && alreadyOverclocked == 0) {
            overclockCounter += maxOverclock - 10.0f;
            alreadyOverclocked = 1;
            Debug.Log("You overheated shooting system");
        }
        //Sytem cooled down
        if (overclockCounter < 12.0f && alreadyOverclocked == 1) {
            overclockCounter = 0;
            alreadyOverclocked = 0;
            Debug.Log("Shooting system cooled down");
        }
        //Tilt
        float tiltAroundZ = Input.GetAxis("Horizontal") * tiltAngle;
        float tiltAroundX = Input.GetAxis("Vertical") * tiltAngleFrontBack;
        Quaternion goal = Quaternion.Euler(tiltAroundX, 0, tiltAroundZ);
        transform.rotation = Quaternion.Slerp(transform.rotation, goal, Time.deltaTime * smooth);
        //Colides with
        //Stopper
        
        if (slower > 0 && passiveSpeed > 0) {
            passiveSpeed -= 1 * Time.deltaTime;
        }
        if (passiveSpeed < 0)
        {
            passiveSpeed = 0;
            Debug.Log("There is no boss, sorry");
        }
        //Moving forward passively
        //Moving forward
        transform.position = transform.position + (Vector3.forward * Time.deltaTime * passiveSpeed);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (gameObject == other.gameObject.CompareTag("Stopper"))
        {
            slower++;
        }
    }
}
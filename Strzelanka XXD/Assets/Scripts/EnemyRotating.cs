using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRotating : MonoBehaviour
{
    // Start is called before the first frame update
    //variables
    public float speed = 15.0f;
    public float turnSpeed = 72.0f;
    public float goal = 135.0f;
    private float turningCounter = 0.0f;
    public float turnTimeStart = 2.0f;
    public float turnTimeEnd = 3.0f;
    void Start()
    {
        //transform at beggining to specific rotation
        transform.Rotate(0,goal,0);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = transform.position + (Vector3.forward * Time.deltaTime * speed);
        //turningCounter will stop after object turns for turnTimeEnd - turnTimeStart
        if (turningCounter < turnTimeEnd) {
            turningCounter += 1 * Time.deltaTime;
        }
        //object turns
        if (turningCounter > turnTimeStart && turningCounter < turnTimeEnd) {
                transform.Rotate(Vector3.down * Time.deltaTime * turnSpeed);
        }
    }
}

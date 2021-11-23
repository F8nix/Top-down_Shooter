using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    //variables
    public float speed = 25.0f;
    public float cameraStop = 2000;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //camera moves on its own using global z of the world
        if (transform.position.z < cameraStop) {
            transform.position = transform.position + (Vector3.forward * Time.deltaTime * speed);
        }
        //And it slows down before boss area
        if (transform.position.z > cameraStop && speed > 0) {
            speed -= 1 * Time.deltaTime;
            transform.position = transform.position + (Vector3.forward * Time.deltaTime * speed);
        }
        if (speed < 0) {
            speed = 0;
        }
    }
}

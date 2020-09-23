using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShipScript : MonoBehaviour
{
    public float xMin, xMax, zMin, zMax;
    public float speed;
    public float tilt;
    public float shotDelay;

    float nextShotTime;

    public GameObject LazerShot;
    public GameObject LazerGun;

    Rigidbody ship;

    // Start is called before the first frame update
    void Start()
    {
        ship = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        ship.velocity = new Vector3(moveHorizontal, 0, moveVertical) * speed;

        float clampedX = Mathf.Clamp(transform.position.x, xMin, xMax);
        float clampedZ = Mathf.Clamp(transform.position.z, zMin, zMax);

        ship.position = new Vector3(clampedX, 0, clampedZ);

        ship.rotation = Quaternion.Euler(ship.velocity.z * tilt, 0, -ship.velocity.x * tilt);

        if(Time.time > nextShotTime)
        {
            Instantiate(LazerShot, LazerGun.transform.position, Quaternion.identity);
            nextShotTime = Time.time + shotDelay;
        }
    }
}

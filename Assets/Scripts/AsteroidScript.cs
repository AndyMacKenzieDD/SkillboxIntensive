﻿ using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AsteroidScript : MonoBehaviour
{
    public float rotationSpeed;
    public float minSpeed;
    public float maxSpeed;

    public GameObject asteroidExplosion;
    public GameObject playerExplosion;

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody asteroid = GetComponent<Rigidbody>();
        asteroid.velocity = new Vector3(0, 0, -Random.Range (minSpeed, maxSpeed));
        asteroid.angularVelocity = Random.insideUnitSphere * rotationSpeed;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "GameBaundary")
        {
            return;
        }

        if (other.tag == "Lazer")
        {
            GameControllerScript.instatnce.score += 10;
        }

        Instantiate(asteroidExplosion, transform.position, Quaternion.identity);

        if(other.tag == "Player")
        {
            Instantiate(playerExplosion, other.transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
        Destroy(other.gameObject);
    }
}

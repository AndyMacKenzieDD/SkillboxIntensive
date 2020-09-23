using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmitterScript : MonoBehaviour
{
    public GameObject asteroid;
    public float nextLaunchTime;
    public float minDelay;
    public float maxDelay;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > nextLaunchTime)
        {
            float emitterSize = transform.localScale.x;
            float positionX = Random.Range(-emitterSize / 2, emitterSize / 2);
            float positionY = 0;
            float positionZ = transform.position.z;

            GameObject newAsteroid = Instantiate(asteroid, new Vector3(positionX, positionY, positionZ), Quaternion.identity);
            newAsteroid.transform.localScale *= Random.Range(0.5f, 2);
            nextLaunchTime = Time.time + Random.Range(minDelay, maxDelay);
        }
    }
}

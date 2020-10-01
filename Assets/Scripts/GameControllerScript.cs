using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameControllerScript : MonoBehaviour
{
    public static GameControllerScript instatnce;
    public UnityEngine.UI.Text scoreLabel;
    public int score = 0;

    // Start is called before the first frame update
    void Start()
    {
        instatnce = this;
    }

    // Update is called once per frame
    void Update()
    {
        scoreLabel.text = "Score: " + score;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private SpawnManager spawnManagerScript;

    public int score = 0;

    public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
        score = PlayerPrefs.GetInt("Score", 0); 
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        //Moving the knife on Space bar press.
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            if (spawnManagerScript.currentKnife != null)
            {
                spawnManagerScript.currentKnife.GetComponent<MoveKnifeForward>().moveForward = true;
            }
        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float sphereRotateSpeed = 10f;

    private SpawnManager spawnManagerScript;
    private PlayerController playerControllerScript;

    //Bonus Feature. Not Complete
    //float startDisappearTime = 1f;
    //float disappearTime = 2f;
    //int disappearChance = 0;
    //float timer = 0;

    // Start is called before the first frame update
    void Start()
    {
        spawnManagerScript = GameObject.Find("SpawnManager").GetComponent<SpawnManager>();
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Rotating the sphere.
        if (!playerControllerScript.gameOver)
        {
            transform.Rotate(Vector3.forward * Time.deltaTime * sphereRotateSpeed);
        }

        //Bonus Feature. Not Complete
        //timer += Time.deltaTime;

        //if(timer > startDisappearTime)
        //{
        //    disappearChance = Random.Range(0, 1);
        //    if(disappearChance > 50)
        //    {
        //        gameObject.SetActive(false);
        //        Invoke("ReappearBoard", disappearTime);
        //        timer = 0;
        //    }
        //}
        
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When Knife collides with sphere it stops the knife and increases the score.
        if(collision.gameObject.CompareTag("Knife"))
        {
            collision.gameObject.transform.SetParent(transform);
            collision.gameObject.GetComponent<Rigidbody>().isKinematic = true;
            spawnManagerScript.spawnKnife = true;
            playerControllerScript.score++;
            PlayerPrefs.SetInt("Score", playerControllerScript.score);
            Debug.Log("Score: " + playerControllerScript.score);
        }
    }

    //Bonus Feature. Not Complete
    //private void ReappearBoard()
    //{
    //    gameObject.SetActive(true);
    //}
}

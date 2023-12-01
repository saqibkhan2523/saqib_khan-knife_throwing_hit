using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    public float sphereRotateSpeed = 10f;

    private SpawnManager spawnManagerScript;
    private PlayerController playerControllerScript;

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
}

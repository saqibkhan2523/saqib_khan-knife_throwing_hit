using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MoveKnifeForward : MonoBehaviour
{
    public float knifeMovingSpeed;
    public bool moveForward = false;

    private Rigidbody knifeRb;

    private AudioSource knifeAudioSource;
    public AudioClip boardHit;
    public AudioClip knifeHit;

    private PlayerController playerControllerScript;

    // Start is called before the first frame update
    void Start()
    {
        playerControllerScript = GameObject.Find("Player").GetComponent<PlayerController>();
        knifeRb = GetComponent<Rigidbody>();
        knifeAudioSource = GetComponent<AudioSource>();
        moveForward = false;
    }

    // Update is called once per frame
    void Update()
    {
        //moving the Knife forward.
        if (moveForward)
        {
            transform.Translate(Vector3.up * Time.deltaTime * knifeMovingSpeed);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //When knife collides with sphere it stops moveing forward.
        if(collision.gameObject.CompareTag("Sphere"))
        {
            knifeRb.isKinematic = true;
            moveForward = false;
            knifeAudioSource.PlayOneShot(boardHit);
        }

        if (collision.gameObject.CompareTag("Knife"))
        {
            knifeAudioSource.PlayOneShot(knifeHit);
            moveForward = false;

            playerControllerScript.gameOver = true;
            Debug.Log("Game Over");
            Invoke("RestartGame", 3f);

            
        }

    }

    private void RestartGame()
    {
        SceneManager.LoadScene(0);
    }
}

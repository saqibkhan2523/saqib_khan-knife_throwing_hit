using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MoveForward : MonoBehaviour
{
    public float knifeMovingSpeed;
    public bool moveForward = false;

    private Rigidbody knifeRb;

    // Start is called before the first frame update
    void Start()
    {
        knifeRb = GetComponent<Rigidbody>();
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
        }
    }
}

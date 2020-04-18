using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    public float speed;
    public FixedJoystick FixedJoystick;
    public Rigidbody rb;
    public GameObject Camera;

    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * FixedJoystick.Vertical + Vector3.right * FixedJoystick.Horizontal;
        rb.transform.Translate(direction * speed * Time.fixedDeltaTime);        
    }

    void Update()
    {
        //Rotação Camera e Personagem
        transform.rotation = Camera.transform.rotation;
    }
 
}
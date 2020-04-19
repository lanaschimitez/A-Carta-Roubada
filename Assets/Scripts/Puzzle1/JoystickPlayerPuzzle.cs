using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayerPuzzle : MonoBehaviour
{
    public float speed;
    public DynamicJoystick DynamicJoystick;
    public Rigidbody rb;

    public void FixedUpdate()
    {
        //Vector3 direction = Vector3.forward * FixedJoystick.Vertical + Vector3.right * FixedJoystick.Horizontal;
        Vector3 direction = new Vector3(DynamicJoystick.Direction.x, DynamicJoystick.Direction.y, 0);
        rb.transform.Translate(direction.x * speed * Time.fixedDeltaTime, direction.y * speed * Time.fixedDeltaTime, 0);        
    }

    void Update()
    {

    }
 
}
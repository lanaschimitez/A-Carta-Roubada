using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickDynamicSala : MonoBehaviour
{
    public float speed=70;
    public DynamicJoystick DynamicJoystick;
    public float horizontal;
    public float vertical;

    public void Start()
    {

    }

    public void FixedUpdate()
    {
        //Vector3 direction = Vector3.forward * FixedJoystick.Vertical + Vector3.right * FixedJoystick.Horizontal;
        //Vector3 direction = new Vector3(DynamicJoystick.Direction.x, DynamicJoystick.Direction.y, 0);
        //transform.rotation = Quaternion.Euler(direction.x * speed * Time.fixedDeltaTime, direction.y * speed * Time.fixedDeltaTime, 0);      

    }

    void Update()
    {
        horizontal = DynamicJoystick.Horizontal;
        vertical = DynamicJoystick.Vertical;

        if (vertical > 0)
        {
            transform.Rotate(-1 * speed * Time.deltaTime, 0, 0, Space.Self);
        }
        else if (vertical < 0)
        {
            transform.Rotate(1 * speed * Time.deltaTime, 0, 0, Space.Self);
        }

        if (horizontal > 0)
        {
            transform.Rotate(0, 1 * speed * Time.deltaTime, 0, Space.World);
        }
        else if (horizontal < 0)
        {
            transform.Rotate(0, -1 * speed * Time.deltaTime, 0, Space.World);
        }
    }
 
}
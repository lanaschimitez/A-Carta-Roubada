using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JoystickPlayer : MonoBehaviour
{
    public float speed;
    public FixedJoystick FixedJoystick;
    public Rigidbody rb;
    public GameObject Camera;

    public float f1;
    public float f2;

    void Start()
    {
        transform.rotation = Quaternion.Euler(0, Camera.transform.rotation.y, 0);
    }
    public void FixedUpdate()
    {
        Vector3 direction = Vector3.forward * FixedJoystick.Vertical + Vector3.right * FixedJoystick.Horizontal;
        rb.transform.Translate(direction * speed * Time.fixedDeltaTime);     

    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.x, Camera.transform.rotation.y, transform.rotation.z);
        transform.rotation = Quaternion.Euler(0, Camera.transform.rotation.y, 0);
        transform.eulerAngles = new Vector3(0, Camera.transform.eulerAngles.y, 0);

        f1 = FixedJoystick.Horizontal;
        f2 = FixedJoystick.Vertical;

        rb.transform.Translate(new Vector3(f1*speed*Time.deltaTime, 0, f2*speed * Time.deltaTime), Space.Self);
    }
 
}
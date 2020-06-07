using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraBehaviour : MonoBehaviour
{
    public Transform ObjASeguir;
    public GameObject fade;
    public GameObject cameraInicial;
    // Start is called before the first frame update
    void Start()
    {
        fade.SetActive(true);
        //this.transform.Rotate(new Vector3(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
            transform.position = new Vector3(ObjASeguir.position.x, ObjASeguir.position.y + 11, ObjASeguir.position.z);
    }
}

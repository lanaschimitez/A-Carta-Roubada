using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacao : MonoBehaviour
{
    public float velocidadeRotacao = 50;
    public float velocidadeAndar = 25;
    public Rigidbody rb;
    public GameObject personagem;

    public float f1 = 1;

    void Update()
    {
        personagem.transform.eulerAngles = new Vector3(0, transform.eulerAngles.y, 0);
        //Controle movimentação camera desktop
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 1 * velocidadeRotacao * Time.deltaTime, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -1 * velocidadeRotacao * Time.deltaTime, 0, Space.World);
        }

        if (Input.GetKey(KeyCode.W))
        {
            transform.Rotate(-1 * velocidadeRotacao * Time.deltaTime, 0, 0, Space.Self);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Rotate(1 * velocidadeRotacao * Time.deltaTime, 0, 0, Space.Self);
        }


        if (Input.GetKey(KeyCode.UpArrow))
        {
            f1 = 1;
            rb.transform.Translate(new Vector3(0, 0, f1 * velocidadeAndar * Time.deltaTime), Space.Self);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            f1 = -1;
            rb.transform.Translate(new Vector3(0, 0, f1 * velocidadeAndar * Time.deltaTime), Space.Self);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            f1 = 1;
            rb.transform.Translate(new Vector3(f1 * velocidadeAndar * Time.deltaTime, 0, 0), Space.Self);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            f1 = -1;
            rb.transform.Translate(new Vector3(f1 * velocidadeAndar * Time.deltaTime, 0, 0), Space.Self);
        }
    }
}

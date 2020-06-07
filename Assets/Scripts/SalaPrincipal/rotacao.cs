using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacao : MonoBehaviour
{
    float velocidadeRotacao = 5;
    float x1=10;
    float y1 = 10;

    void Update()
    {
        if(Input.touchCount >= 1 && Input.GetTouch(0).phase == TouchPhase.Moved && Screen.width/2 < Input.GetTouch(0).position.x)
        {
            Vector2 posicaoToque = Input.GetTouch(0).deltaPosition;
            float x = posicaoToque.x * Mathf.Deg2Rad * velocidadeRotacao;
            transform.RotateAround(Vector3.zero, Vector3.up, x);
        }

        //Controle movimentação camera desktop
        if (Input.GetKey(KeyCode.X))
        {
            float x = x1 * Mathf.Deg2Rad * velocidadeRotacao;
            transform.RotateAround(Vector3.zero, Vector3.up, x);
        }

        if (Input.GetKey(KeyCode.Z))
        {
            float x = x1 * Mathf.Deg2Rad * velocidadeRotacao;
            transform.RotateAround(Vector3.zero, Vector3.up, -x);
        }
    }
}

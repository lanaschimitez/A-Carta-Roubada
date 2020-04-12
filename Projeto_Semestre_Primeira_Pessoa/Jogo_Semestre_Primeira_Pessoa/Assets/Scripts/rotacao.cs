using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotacao : MonoBehaviour
{
    float velocidadeRotacao = 10;
    void Update()
    {
        if(Input.touchCount == 1 && Input.GetTouch(0).phase == TouchPhase.Moved)
        {
            Vector2 posicaoToque = Input.GetTouch(0).deltaPosition;
            float x = posicaoToque.x * Mathf.Deg2Rad * velocidadeRotacao;
            //float y = posicaoToque.y * Mathf.Deg2Rad * velocidadeRotacao;
            transform.RotateAround(Vector3.zero, Vector3.up, x);
            //transform.RotateAround(Vector3.zero, Vector3.left, -y);
        }
    }
}

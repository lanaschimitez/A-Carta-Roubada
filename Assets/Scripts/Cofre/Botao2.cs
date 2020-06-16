using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Botao2 : MonoBehaviour
{
    [Range(0.01f, 90.0f)] public float anguloInclinacao = 90.0f;
    private RaycastHit hit;
    public bool onMouseDown = false;
    void Update()
    {
        if (onMouseDown)
        {
            var objectPos = Camera.main.WorldToScreenPoint(transform.position);
            var dir = Input.mousePosition - objectPos;
            float rotacZ = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (rotacZ > -90.0f && rotacZ < 90.0f)
            {
                if (rotacZ > anguloInclinacao)
                {
                    rotacZ = anguloInclinacao;
                }
                else if (rotacZ < -anguloInclinacao)
                {
                    rotacZ = -anguloInclinacao;
                }
            }
            else
            {
                if (rotacZ < (180.0f - anguloInclinacao) && rotacZ > 0.0f)
                {
                    rotacZ = (180.0f - anguloInclinacao);
                }
                else if (rotacZ > -(180.0f - anguloInclinacao) && rotacZ < 0.0f)
                {
                    rotacZ = -(180.0f - anguloInclinacao);
                }
            }
            transform.rotation = Quaternion.Euler(new Vector3(0.0f, 0.0f, rotacZ));
        }
    }
    private void OnMouseUp()
    {
        onMouseDown = false;
    }

    private void OnMouseDrag()
    {
        onMouseDown = true;
    }

    private void OnMouseExit()
    {
        onMouseDown = false;
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrdemPedaco : MonoBehaviour
{
    public int orderPedaco;
    public Vector3 posicaoLugar;
    private Vector3 posicaoPedaco;
    public Vector3 posicaoLugar2;
    private bool lugarCorreto = false;
    public float _distancia = 0;

    private void Start()
    {
        posicaoLugar2 = posicaoLugar;
    }
    private void Update()
    {
        posicaoPedaco = transform.position;

        _distancia = Vector3.Distance(posicaoPedaco, posicaoLugar);

        if (_distancia < 0.2f)
        {
            transform.position = posicaoLugar;
            lugarCorreto = true;
        }
        else
        {
            lugarCorreto = false;
        }
        GameObject.Find("Bandeja").GetComponent<MovimentacaoPeca>().lugarCorreto[orderPedaco - 1] = lugarCorreto;
    }
}

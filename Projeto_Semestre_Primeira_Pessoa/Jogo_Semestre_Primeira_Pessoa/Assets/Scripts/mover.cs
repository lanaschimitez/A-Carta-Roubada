using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mover : MonoBehaviour
{
    private int AuxDirecaoVertical;
    private int AuxDirecaoHorizontal;
    public float velocidade=20;

    public Vector3 posicaoFixa;
    public GameObject desafio;
    public GameObject Camera;

    void Start()
    {

    }

    void Update()
    {
        //Rotação Camera e Personagem
        transform.rotation = Camera.transform.rotation;

        //Movimento personagem
        if (AuxDirecaoVertical != 0)
        {
            transform.Translate(0, 0, velocidade * Time.deltaTime * AuxDirecaoVertical);
        }
        if (AuxDirecaoHorizontal != 0)
        {
            transform.Translate(velocidade * Time.deltaTime * AuxDirecaoHorizontal, 0, 0);
        }

        //Limitando personagem na tela
        //if (transform.position.x < -27)
        //{
        //    posicaoFixa.y = transform.position.y;
        //    posicaoFixa.z = transform.position.z;
        //    transform.position = new Vector3 (-27, posicaoFixa.y, posicaoFixa.z);
        //}
        //else if (transform.position.x > 27)
        //{
        //   posicaoFixa.y = transform.position.y;
        //    posicaoFixa.z = transform.position.z;
        //    transform.position = new Vector3(27, posicaoFixa.y, posicaoFixa.z);
        //}
        //else if (transform.position.y < -35)
        //{
        //    posicaoFixa.x = transform.position.x;
        //    posicaoFixa.z = transform.position.z;
        //    transform.position = new Vector3(posicaoFixa.x, -35, posicaoFixa.z);
        //}
        //else if (transform.position.y > 60)
        //{
        //    posicaoFixa.x = transform.position.x;
        //    posicaoFixa.z = transform.position.z;
        //    transform.position = new Vector3(posicaoFixa.x,60, posicaoFixa.z);
        //}

    }

    public void movimentoVertical (int direcao)
    {
       AuxDirecaoVertical = direcao;
    }

    public void movimentoHorizontal(int direcao)
    {
        AuxDirecaoHorizontal = direcao;
    }

    //public void OnTriggerEnter(Collider other)
    //{
    //   if (other.gameObject.tag == "desafio1")
    //    {
    //        transform.position = new Vector3(-18, 6.9f, 51.6f);
    //    }
    //    
    //    if (other.gameObject.tag == "desafio2")
    //    {
    //        transform.position = new Vector3(14.2f, 5.8f, 52);
    //    }
    //}
}

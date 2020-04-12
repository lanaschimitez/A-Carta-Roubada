using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parede1 : MonoBehaviour
{

    public GameObject Jogador;
    public Vector3 posicao;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "player")
        {
            posicao = Jogador.transform.position;
            Jogador.transform.position = new Vector3(posicao.x, posicao.y, posicao.z-2);
        }
    }
}

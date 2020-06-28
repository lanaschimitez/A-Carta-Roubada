using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class desafio_final : MonoBehaviour
{
    public GameObject personagem;
    public Vector3 posiPerson;
    public GameObject tela_cofre;
    public GameObject joystickMovimentacao;
    public GameObject joystickCamera;
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        posiPerson = personagem.transform.position;

        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit) && posiPerson.x < -35 && posiPerson.z < 14 && posiPerson.z > 2 && PlayerPrefs.GetInt("fire_on") == 1)
            {
                if (hit.transform.name == "cofre")
                {
                    tela_cofre.SetActive(true);
                    joystickMovimentacao.SetActive(false);
                    joystickCamera.SetActive(false);
                }
            }
        }
    }
    public void fechaCofre()
    {
        animator.SetBool("abrir_fechar", true);
        Invoke("fechamento", 1.1f);        
    }
    public void fechamento()
    {
        joystickMovimentacao.SetActive(true);
        joystickCamera.SetActive(true);
        tela_cofre.SetActive(false);
    }
}

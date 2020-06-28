using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextoEnigma : MonoBehaviour
{
    [SerializeField]
    private Text textEnigma;
    private CaixaDeEscrita caixaDeEscrita;
    void Start()
    {
        caixaDeEscrita = GameObject.Find("InputField").GetComponent<CaixaDeEscrita>();
    }
    void Update()
    {
        textEnigma.text = "*Enigma* " + caixaDeEscrita.resultado;
    }
}

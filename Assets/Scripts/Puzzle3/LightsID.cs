using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LightsID : MonoBehaviour
{
    private int[] ordem1;
    private int[] ordem2;
    private int[] ordem3;
    private int[] ordemTeclasCorretas = new int[7];
    public int[] ordemTeclasClicadas = new int[7];
    private bool[] teclasClicadasCorretamentes = new bool[7];
    public int auxOrdem;
    private bool resultado;
    private GameObject teclaColorida;
    private int k = 0; //controle de posicao
    private bool finalCores = false; //controle de rotinas feitas
    private IEnumerator coroutine;
    public bool liberado;

    private void Start()
    {
        liberado = false;
        auxOrdem = 0;
        ordem1 = new int[7] { 3, 5, 12, 13, 1, 15, 6 };
        ordem2 = new int[7] { 20, 21, 8, 11, 4, 17, 19 };
        ordem3 = new int[7] { 9, 10, 14, 16, 18, 7, 2 };

        for (int i = 0; i < 7; i++)
        {
            ordemTeclasClicadas[i] = 0;
        }
        int a = UnityEngine.Random.Range(1, 3);
        if (a == 1)
        {
            ordemTeclasCorretas = ordem1;
        }
        else if (a == 2)
        {
            ordemTeclasCorretas = ordem2;
        }
        else if (a == 3)
        {
            ordemTeclasCorretas = ordem3;
        }
        coroutine = Luzes(1.0f);
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        if (finalCores)
        {
            StopCoroutine(coroutine);
            liberado = true;
        }
        if (liberado)
        {
            if (auxOrdem < 7 && ordemTeclasClicadas[auxOrdem] != 0)
            {
                auxOrdem++;
            }
            if (ordemTeclasClicadas[6] != 0) //verificar se todos os botoes foram apertados
            {
                liberado = false;
                for (int i = 0; i < 7; i++)
                {
                    teclasClicadasCorretamentes[i] = (ordemTeclasCorretas[i] == ordemTeclasClicadas[i]);
                }
                for (int i = 0; i < 7; i++)
                {
                    if (teclasClicadasCorretamentes[i])
                    {
                        resultado = true;
                    }
                    else
                    {
                        resultado = false;
                        break;
                    }
                }
                if (resultado)
                {

                    SceneManager.LoadScene("Sala Principal");
                }
                else
                {
                    Invoke("Reiniciar", 2.0f);
                }
            }
        }
    }

    public void Reiniciar()
    {
        SceneManager.LoadScene("Puzzle 3 - Luzes");
    }
    private IEnumerator Luzes(float waitTime)
    {
        while (true)
        {
            if (k < 7)
            {
                liberado = false;
                int aux;
                string auxString;
                aux = ordemTeclasCorretas[k];
                auxString = aux.ToString();
                String nomeTecla = "Tecla";
                nomeTecla = String.Concat(nomeTecla, auxString);
                teclaColorida = GameObject.Find(nomeTecla);
                teclaColorida.GetComponent<AudioSource>().Play();
                teclaColorida.GetComponent<SpriteRenderer>().color = Color.cyan;
                teclaColorida.GetComponent<LightsControl>().mudançaCor = true;
            }
            else
            {
                finalCores = true;
            }
            k++;
            yield return new WaitForSeconds(waitTime);
        }
    }
}

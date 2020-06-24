using JetBrains.Annotations;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsID : MonoBehaviour
{
    private int[] ordem1;
    private int[] ordem2;
    private int[] ordem3;
    public int[] ordemTeclasCorretas = new int[9];
    public int[] ordemTeclasClicadas = new int[9];
    public bool[] teclasClicadasCorretamentes = new bool[9]; 
    public int auxOrdem;
    public bool resultado;
    public Color newColor;
    public GameObject teclaColorida;
    private int k = 0;
    private IEnumerator coroutine;
    public bool liberado;

    private void Start()
    {
        liberado = false;
        auxOrdem = 0;
        ordem1 = new int[9] { 3, 5, 12, 13, 7, 1, 15, 20, 6 };
        ordem2 = new int[9] { 2, 20, 21, 8, 11, 4, 17, 5, 19 };
        ordem3 = new int[9] { 9, 10, 14, 16, 18, 7, 2, 21, 16 };
        
        for(int i = 0; i < 9; i++)
        {
            ordemTeclasClicadas[i] = 0;
        }

        int a = UnityEngine.Random.Range(1, 3);
        if (a == 1)
        {
            ordemTeclasCorretas = ordem1;
        }
        else if(a == 2)
        {
            ordemTeclasCorretas = ordem2;
        }
        else if(a == 3)
        {
            ordemTeclasCorretas = ordem3;
        }

        coroutine = Luzes(3.0f);
        StartCoroutine(coroutine);
    }

    private void Update()
    {
        if (k > 8)
        {
            StopCoroutine(coroutine);
            liberado = true;
        }
        if (liberado)
        {
            if (auxOrdem < 9 && ordemTeclasClicadas[auxOrdem] != 0)
            {
                auxOrdem++;
            }
            if (ordemTeclasClicadas[8] != 0) //verificar se todos os botoes foram apertados
            {
                liberado = false;
                for (int i = 0; i < 9; i++)
                {
                    teclasClicadasCorretamentes[i] = (ordemTeclasCorretas[i] == ordemTeclasClicadas[i]);
                }
                for (int i = 0; i < 9; i++)
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
                    Debug.Log((resultado) ? "Ganhou" : "Perder");
            }
        }
    }

    private IEnumerator Luzes(float waitTime)
    {
        while (true)
        {
            int aux;
            string auxString;
            aux = ordemTeclasCorretas[k];
            auxString = aux.ToString();
            String nomeTecla = "Tecla";
            nomeTecla = String.Concat(nomeTecla, auxString);
            Debug.Log(nomeTecla);
            teclaColorida = GameObject.Find(nomeTecla);
            teclaColorida.GetComponent<SpriteRenderer>().color = Color.cyan;
            k++;
            yield return new WaitForSeconds(waitTime);
        }
            
    }
}

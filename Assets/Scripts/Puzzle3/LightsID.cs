using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsID : MonoBehaviour
{
    public int[] ordem1;
    public int[] ordem2;
    public int[] ordem3;
    public int[] ordemTeclasCorretas = new int[9];
    public int[] ordemTeclasClicadas = new int[9];
    public bool[] teclasClicadasCorretamentes = new bool[9];
    public int auxOrdem;
    public bool resultado;

    private void Start()
    {
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
    }

    private void Update()
    {
        teclasClicadasCorretamentes[auxOrdem] = (ordemTeclasCorretas[auxOrdem] == ordemTeclasClicadas[auxOrdem]);
        if (auxOrdem < 9 && ordemTeclasClicadas[auxOrdem] != 0)
        {
            auxOrdem++;
        }
        if (ordemTeclasClicadas[20] != 0) //verificar se todos os botoes foram apertados
        {
            for (int i = 0; i < 21; i++)
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

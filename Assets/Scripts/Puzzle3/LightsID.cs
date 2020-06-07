using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightsID : MonoBehaviour
{
    private readonly int[] idLightsB = new int[9];
    public int[] idLightsU = new int[9];
    public int order;
    public bool[] correcao = new bool[9];
    public bool resultado = false;

    void Start()
    {
        order = 0;
        //mudar e pegar pelo banco de dados
        for (int i = 0; i < 9; i++)
        {
            idLightsB[i] = i + 1;
            idLightsU[i] = 0;
        }
    }
    void Update()
    {
        correcao[order] = (idLightsB[order] == idLightsU[order]) ? true : false;
        if (order < 8 && idLightsU[order] != 0)
        {
            order++;
        }
        if (idLightsU[8] != 0)
        {
            for (int i = 0; i < 9; i++)
            {
                if (correcao[i])
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

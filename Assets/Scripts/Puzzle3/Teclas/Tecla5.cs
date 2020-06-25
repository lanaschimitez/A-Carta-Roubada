using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla5 : MonoBehaviour
{
    private IEnumerator coresCoroutine;
    public bool tecla;
    private void Update()
    {
       tecla = gameObject.GetComponent<LightsControl>().mudarCor;
        if (tecla)
        {
            coresCoroutine = CorTecla1(1.0f);
            StartCoroutine(coresCoroutine);
        }
    }
    IEnumerator CorTecla1(float waitTime )
    {
        while (true)
        {
            waitTime -= Time.deltaTime;
            if (waitTime < 0.1 || gameObject.GetComponent<LightsControl>().mudançaCor)
            {
                StopCor();
            }
            yield return null;
        }
    }

    public void StopCor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<LightsControl>().corOriginal;
        StopCoroutine(coresCoroutine);
    }
}

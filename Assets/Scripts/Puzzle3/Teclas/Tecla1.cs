using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tecla1 : MonoBehaviour
{
    private IEnumerator coresCoroutine;
    public bool tecla;
    private void Update()
    {
       tecla = gameObject.GetComponent<LightsControl>().mudarCor;
        if (tecla)
        {
            coresCoroutine = CorTecla1(0.5f);
            StartCoroutine(coresCoroutine);
        }
    }
    IEnumerator CorTecla1(float waitTime )
    {
        while (true)
        {
            waitTime -= Time.deltaTime;
            if (waitTime < 0.1)
            {
                StopCor();
            }
            yield return null;
        }
    }

    public void StopCor()
    {
        gameObject.GetComponent<SpriteRenderer>().color = gameObject.GetComponent<LightsControl>().corOriginal;
        Debug.Log("Mudou cor");
        StopCoroutine(coresCoroutine);
    }
}

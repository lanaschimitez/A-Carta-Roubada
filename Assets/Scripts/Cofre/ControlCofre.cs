using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class ControlCofre : MonoBehaviour
{
    public GameObject botao1;
    public GameObject botao2;
    public GameObject botao3;
    public GameObject botao4;
    public GameObject botao5;

    public GameObject botaod1;
    public GameObject botaod2;
    public GameObject botaod3;
    public GameObject botaod4;
    public GameObject botaod5;

    public float botao1Float;
    public float botao2Float;
    public float botao3Float;
    public float botao4Float;
    public float botao5Float;

    public void Update()
    {
        botao1Float = botao1.GetComponent<RectTransform>().eulerAngles.z;
        botao2Float = botao2.GetComponent<RectTransform>().eulerAngles.z;
        botao3Float = botao3.GetComponent<RectTransform>().eulerAngles.z;
        botao4Float = botao4.GetComponent<RectTransform>().eulerAngles.z;
        botao5Float = botao5.GetComponent<RectTransform>().eulerAngles.z;

        float timePlacar = PlayerPrefs.GetFloat("time");
        string nomePlacar = PlayerPrefs.GetString("nomeJogador");
        if (Mathf.Ceil(360 - botao1Float) == 159 && Mathf.Ceil(360 - botao2Float) == 274 && Mathf.Ceil(360 - botao3Float) == 346 && Mathf.Ceil(360 - botao4Float) == 87 && Mathf.Ceil(360 - botao5Float) == 15)
        {
            botaod1.GetComponent<Button>().enabled = false;
            botaod2.GetComponent<Button>().enabled = false;
            botaod3.GetComponent<Button>().enabled = false;
            botaod4.GetComponent<Button>().enabled = false;
            botaod5.GetComponent<Button>().enabled = false;
            StartCoroutine(Pontuar(timePlacar,nomePlacar));
            PlayerPrefs.SetInt("inicio_on", 0);
            PlayerPrefs.SetInt("zerado", 0);
            Invoke("fimDeJogo", 1);
        }
    }

    IEnumerator Pontuar(float timePlacar,string nomePlacar)
    {
        WWWForm wwwf = new WWWForm();
        wwwf.AddField("jogo", "testeteste", System.Text.Encoding.UTF8);
        wwwf.AddField("acao", "pontuar", System.Text.Encoding.UTF8);
        wwwf.AddField("jogador", nomePlacar, System.Text.Encoding.UTF8);
        wwwf.AddField("pontos", timePlacar.ToString(), System.Text.Encoding.UTF8);

        using (var w = UnityWebRequest.Post("https://spigo.net/jogos/highscore.php", wwwf))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                Debug.Log(w.error);
            }
            else
            {
                Debug.Log("Cadastrado");
            }
        }
    }


    public void mexeBotao1()
    {
        botao1.transform.Rotate(new Vector3(0, 0, -14.4f));
    }
    public void mexeBotao2()
    {
        botao2.transform.Rotate(new Vector3(0, 0, -14.4f));
    }
    public void mexeBotao3()
    {
        botao3.transform.Rotate(new Vector3(0, 0, -14.4f));
    }
    public void mexeBotao4()
    {
        botao4.transform.Rotate(new Vector3(0, 0, -14.4f));
    }
    public void mexeBotao5()
    {
        botao5.transform.Rotate(new Vector3(0, 0, -14.4f));
    }
    
    public void fimDeJogo()
    {
        SceneManager.LoadScene("CenaDeEscolha");
    }
}

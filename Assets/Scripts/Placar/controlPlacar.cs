using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Networking;

public class controlPlacar : MonoBehaviour
{
    public Text listaJogadores;
    public Text listaTempo;
    public Text listaPosicao;
    public Text txtContinuar;
    public Text txtPlacar;
    public Text txtPosicao;
    public Text txtJogadores;
    public Text txtTime;
    public struct Players
    {
        [System.Serializable]
        public struct Player
        {
            public int idJogo;
            public string name;
            public int pontos;
            public System.DateTime quando;
        }

        public Player[] objetos;
    }

    private void Start()
    {
        if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            txtContinuar.text = "Continue";
            txtPlacar.text = "HighScore";
            txtPosicao.text = "Placing";
            txtJogadores.text = "Players";
            txtTime.text = "Time"; 
        }
        listaJogadores.text = "Carregando...";
        listaTempo.text = "Carregando...";
        listaPosicao.text = "Carregando...";
        listando();
    }

    IEnumerator listarPontos()
    {
        WWWForm wwwf = new WWWForm();
        wwwf.AddField("jogo", "acartaroubada", System.Text.Encoding.UTF8);
        wwwf.AddField("acao", "listar", System.Text.Encoding.UTF8);
        wwwf.AddField("ordem", "ASC", System.Text.Encoding.UTF8);
        wwwf.AddField("limite", "10", System.Text.Encoding.UTF8);

        using (var w = UnityWebRequest.Post("https://spigo.net/jogos/highscore.php?desc=listar", wwwf))
        {
            yield return w.SendWebRequest();
            if (w.isNetworkError || w.isHttpError)
            {
                listaJogadores.text = "Erro ...";
                listaTempo.text = "Erro ...";
                listaPosicao.text = "Erro ...";
                Debug.Log(w.error);
            }
            else
            {
                listaJogadores.text = "";
                listaTempo.text = "";
                listaPosicao.text = "";
                int somaPosicao = 1;
                Players playerContainer = JsonUtility.FromJson<Players>(w.downloadHandler.text);
                if (playerContainer.objetos.Length > 0)

                    foreach (Players.Player item in playerContainer.objetos)
                    {
                        listaJogadores.text += item.name + "\n";
                        int seconds = (int)(item.pontos % 60);
                        int minutes = (int)(item.pontos / 60) % 60;
                        listaTempo.text += string.Format("{0:00}:{1:00}", minutes, seconds) + "\n";                        
                        listaPosicao.text += somaPosicao + "\n";
                        somaPosicao++;
                    }
            }
        }
    }
    public void listando()
    {
        StartCoroutine(listarPontos());
    }
    public void creditos()
    {
        SceneManager.LoadScene("Credits");
    }
}

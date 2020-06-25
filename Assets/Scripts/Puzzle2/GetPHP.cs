using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking;
public class GetPHP : MonoBehaviour
{
    public Text texto;
    public InputField txtQtdePokemon;
    public InputField txtNomePokemon;
    public void ListarPokemon()
    {
        IEnumerator listarPontos()
        {
            WWWForm wwwf = new WWWForm();
            wwwf.AddField("jogo", "acartaroubada", System.Text.Encoding.UTF8);
            wwwf.AddField("acao", "listar", System.Text.Encoding.UTF8);
            wwwf.AddField("limite", "5", System.Text.Encoding.UTF8);

            using (var w = UnityWebRequest.Post("https://spigo.net/jogos/highscore.php", wwwf))
            {
                yield return w.SendWebRequest();
                if (w.isNetworkError || w.isHttpError)
                {
                    Debug.Log(w.error);
                }
                else
                {
                    Players playerContainer = JsonUtility.FromJson<Players>(w.downloadHandler.text);
                    if (playerContainer.objetos.Length > 0)

                        foreach (Players.Player item in playerContainer.objetos)
                        {
                            Debug.Log(item.pontos);
                        }
                }
            }
        }
        IEnumerator Pontuar()
        {
            WWWForm wwwf = new WWWForm();
            wwwf.AddField("jogo", "acartaroubada", System.Text.Encoding.UTF8);
            wwwf.AddField("acao", "pontuar", System.Text.Encoding.UTF8);
            wwwf.AddField("jogador", "gustavo", System.Text.Encoding.UTF8);
            wwwf.AddField("pontos", "50", System.Text.Encoding.UTF8);

            using (var w = UnityWebRequest.Post("https://spigo.net/jogos/highscore.php", wwwf))
            {
                yield return w.SendWebRequest();
                if (w.isNetworkError || w.isHttpError)
                {
                    Debug.Log(w.error);
                }
                else
                {
                    //Code here
                }
            }
        }
    }
}
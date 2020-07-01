using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Credits : MonoBehaviour
{
    public TextAsset m_TextFile;
    public Text m_TextUI;
    public GameObject movimentacaoTexto;
    public int m_RoleSize = 36;
    public int m_PersonSize = 22;
    public int m_Space = 40;
    public float m_Speed = 2.0f;
    public GameObject buttoExit;
    public Text exitTexto;

    public Canvas m_Canvas;
    private void Start()
    {
        string[] lines = m_TextFile.text.Replace("\r", "").Split('\n');
        StringBuilder builder = new StringBuilder();


        for (int i = 0; i < lines.Length; i++)
        {
            string line = lines[i];
            if (line.Contains("t:"))
            {
                line = line.Replace("t:", "").ToUpperInvariant();
                line = $"<b><size={m_RoleSize}>{line}</size></b>";
            }
            else
            {
                line = $"<b><size={m_PersonSize}>{line}</size></b>";
            }
            builder.Append(line).Append($"<size={m_Space}>\n</size>");
        }
        m_TextUI.text = builder.ToString();
        Canvas.ForceUpdateCanvases();

        if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            exitTexto.text = "Exit";
        }
    }

    private void Update()
    {
        transform.Translate(Vector3.up * m_Speed * Time.deltaTime);

        if (movimentacaoTexto.gameObject.transform.position.y > 1065)
        {
            m_Speed = 0;
            buttoExit.SetActive(true);
        }
        if (PlayerPrefs.GetInt("credito_menu") == 1)
        {
            buttoExit.SetActive(true);
            PlayerPrefs.SetInt("credito_menu", 0);
        }
    }

    public void exit()
    {
        SceneManager.LoadScene("Menu Principal");
    }
}

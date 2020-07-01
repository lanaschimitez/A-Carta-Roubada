using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Animacao1 : MonoBehaviour
{
    public Text fala;
    int fraseNumero;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetInt("jogo_portugues") == 1)
        {
            fraseNumero = 1;
            fala.text = "Finalmente você chegou! Estava a sua espera.";
        }
        else if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            fraseNumero = 1;
            fala.text = "Finally you are here! I was waiting for you.";
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            trocaFala();
        }
    }

    void mudaFrasePortugues(int i)
    {
        switch (i)
        {
            case 1:
                fala.text = "Finalmente você chegou! Estava a sua espera.";
                break;
            case 2:
                fala.text = "Consegui encontrar o paradeiro da carta roubada. Ela se encontra em poder do Ministro D, em seus aposentos.";
                break;
            case 3:
                fala.text = "Alguns dias atrás eu tentei reavê-la, mas não consegui. Desde então o Ministro mantém forte vigilância em seus aposentos. No entanto, consegui movê-la e escondê-la do Ministro.";
                break;
            case 4:
                fala.text = "Sua tarefa é adentrar a sala do Ministro e reaver a carta.";
                break;
            case 5:
                fala.text = "Para isso, eu vou te ajudar a entrar na sala e conseguir tempo para você.";
                break;
            case 6:
                fala.text = "Para achar a carta, você precisa resolver os enigmas que deixei escondido dentro da sala do Ministro.";
                break;
            case 7:
                fala.text = "As dicas para achar os enigmas são:";
                break;
            case 8:
                fala.text = "1 - EM SUA AUSÊNCIA, O SILÊNCIO SE TORNA REI, NA SUA PRESENÇA, O SILÊNCIO TORNA SE PARTE DO SEU PROCESSO.";
                break;
            case 9:
                fala.text = "2 - QUANDO ESTIVER PERDIDO, PARE E OLHE. CERTAS JANELAS, PODE MOSTRAR O CAMINHO.";
                break;
            case 10:
                fala.text = "3 - AQUI VOCÊ ENCONTRARÁ A RESPOSTA SE AQUECENDO NA COMPANHIA DE MAQUIAVEL E CAMPANELLA.";
                break;
            case 11:
                fala.text = "4 - NA SUA PRESENÇA, VOCÊ IRÁ CONSEGUIR ENXERGAR AQUILO QUE PROCURA.";
                break;
            case 12:
                fala.text = "Com essas informações, você irá conseguir achar a carta. Seja rápido, eu não vou conseguir distrair o ministro por muito tempo.";
                break;
            case 13:
                fala.text = "E lembre-se, o conteúdo dessa carta é de extrema importância e sigilo. O destino da França, estará na mão de quem possuir essa carta.";
                break;
            default:
                SceneManager.LoadScene("Sala Principal");
                break;
        }
        gameObject.GetComponent<AudioSource>().Play();
    }

    void mudaFraseIngles(int i)
    {
        switch (i)
        {
            case 1:
                fala.text = "Finally you are here! I was waiting for you.";
                break;
            case 2:
                fala.text = "I managed to find the where abouts of the stolen letter. She is in the possession of Minister D, in his chamber.";
                break;
            case 3:
                fala.text = "A few days ago I tried to get it back, but I couldn't. Since then, the Minister has kept a close watch on his rooms. However, I managed to move it and hide it from the Minister.";
                break;
            case 4:
                fala.text = "Your task is to enter the Minister's chamber and retrieve the letter.";
                break;
            case 5:
                fala.text = "For that, I will help you enter the room and make time for you.";
                break;
            case 6:
                fala.text = "To find a letter, you need to solve the puzzles that are hidden in the Minister's room.";
                break;
            case 7:
                fala.text = "How tips for finding the puzzles are:";
                break;
            case 8:
                fala.text = "1 – INY YOUR ABSENCE, SILENCE BECOMES KING, IN YOUR PRESENCE, SILENCIE BECOMES PART OF YOUR PROCESS.";
                break;
            case 9:
                fala.text = "2 - WHEN YOU'RE LOST, STOP AND LOOK. SOME WINDOWS, YOU CAN SHOW THE PATH.";
                break;
            case 10:
                fala.text = "3 - HERE YOU WILL FIND THE ANSWER WARMING UP IN THE COMPANY OF MAQUIAVEL AND CAMPANELLA.";
                break;
            case 11:
                fala.text = "4 - IN YOUR PRESENCE, YOU WILL BE ABLE TO SEE WHAT YOU ARE LOOKING FOR.";
                break;
            case 12:
                fala.text = "With this information, you will be able to find the letter. Be quick, I won't be able to distract the minister for long.";
                break;
            case 13:
                fala.text = "And remember, the content of this letter is extremely important and confidential.France's fate will be in the hands of whoever has this letter.";
                break;
            default:
                SceneManager.LoadScene("Sala Principal");
                break;

        }
        gameObject.GetComponent<AudioSource>().Play();
    }


    public void trocaFala()
    {
        if (PlayerPrefs.GetInt("jogo_portugues") == 1)
        {
            fraseNumero++;
            mudaFrasePortugues(fraseNumero);
        }
        else if (PlayerPrefs.GetInt("jogo_ingles") == 1)
        {
            fraseNumero++;
            mudaFraseIngles(fraseNumero);
        }
    }
}

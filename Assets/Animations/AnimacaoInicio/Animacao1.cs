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
        fraseNumero = 1;
        fala.text = "Finalmente você chegou! Estava a sua espera.";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            trocaFala();
        }
    }

    void mudaFrase(int i)
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
                fala.text = "3 - NA SUA PRESENÇA, VOCÊ IRÁ CONSEGUIR ENXERGAR AQUILO QUE PROCURA.";
                break;
            case 11:
                fala.text = "Com essas informações, você irá conseguir achar a carta. Seja rápido, eu não vou conseguir distrair o ministro por muito tempo.";
                break;
            case 12:
                fala.text = "E lembre-se, o conteúdo dessa carta é de extrema importância e sigilo. O destino da França, estará na mão de quem possuir essa carta.";
                break;
            default:
                SceneManager.LoadScene("Sala Principal");
                break;                
        }

        gameObject.GetComponent<AudioSource>().Play();
    }

    public void trocaFala()
    {
        fraseNumero++;
        mudaFrase(fraseNumero);
    }
}

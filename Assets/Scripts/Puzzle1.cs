using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Puzzle1 : MonoBehaviour
{
    public float speed = 5.0f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimento();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Barreira")
        transform.position = new Vector3(-7.0f, -4.0f, 0f);
        if(other.tag == "Final")
        {
            Debug.Log("Ganhou");
            SceneManager.LoadScene("Sala Principal");
        }
    }

    public void Movimento()
    {
        float horizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime; //o jogador ira mover cada vez que prescioonar 
        transform.Translate(horizontal, 0, 0);
        float vertical = Input.GetAxis("Vertical") * speed * Time.deltaTime; //o jogador ira mover cada vez que prescioonar 
        transform.Translate(0, vertical, 0);
    }
   
}
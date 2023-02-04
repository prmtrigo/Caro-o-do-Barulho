using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D corpo;
    public float velocidade=7;
    public float JumpForce=5;
    public int vida= 10;
    public UnityEngine.UI.Text texto;
 
    // Start is called before the first frame update
    void Start()
    {
      corpo = GetComponent<Rigidbody2D>(); 
      texto = GameObject.Find("Text").GetComponent<Text>();
      texto.text = vida.ToString(); 
      
    }
 
    // Update is called once per frame
    void Update()
    {
        Move();
        Jump();
    }
 
    private void Move()
    {
        Vector3 movimento = new Vector3(Input.GetAxis("Horizontal"), 0f, 0f);
        transform.position += movimento * Time.deltaTime * velocidade;
 
        if(Input.GetAxis("Horizontal") < 0)
        {
           transform.eulerAngles = new Vector2 (0f, 180f);        
        }
        else
        {
            transform.eulerAngles = new Vector2 (0f, 0f);  
        }
    }
 
    private void Jump()
    {
        if(Input.GetButtonDown("Jump"))
        {
            corpo.AddForce(new Vector2(0f, JumpForce), ForceMode2D.Impulse);
        }
    }
    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Inimigo"))
        {
            vida--;
            texto.text = vida.ToString();
            if(vida<=0)
            {
                SceneManager.LoadScene(1);
            }
        }

        if (collision.gameObject.CompareTag("Vida"))
        {
            vida++;
            texto.text = vida.ToString();
            if(vida>=11)
            {
                SceneManager.LoadScene(2);
            }
        }


    }
    // private void OnTriggerEnter2D(Collider2D collision)
    // { 
    //     //Preciso indentificar se o cara com quem eu colidi é o fim do jogo
    //     if (vida==11 && collision.CompareTag("vitoria"))
    //     {         
                
    //     Debug.Log("Parabéns!!!");
    //     //Reiniciando o jogo (Vou para a cena inicio)
    //     //Indo para a cena inicial
    //     SceneManager.LoadScene(0);
        
    //     }
    //     if (vida==0 && collision.CompareTag("derrota"))
    //     {             
    //     Debug.Log("Opa! O jogo acabou!");
    //     //Reiniciando o jogo (Vou para a cena inicio)
    //     //Indo para a cena inicial
    //     SceneManager.LoadScene(0);
        
    //     }
    // }
    

}

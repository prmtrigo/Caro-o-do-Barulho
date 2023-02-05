using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Rigidbody2D corpo;
    public float velocidade=12;
    public float JumpForce=10;
    public int vida= 5, score,moedas;
    public UnityEngine.UI.Text texto,texto1,texto2;
 
    // Start is called before the first frame update
    void Start()
    {
      corpo = GetComponent<Rigidbody2D>(); 
      texto = GameObject.Find("Text").GetComponent<Text>();
      texto.text = vida.ToString();

      texto1 = GameObject.Find("Text1").GetComponent<Text>();
      texto1.text = score.ToString();  

      texto2 = GameObject.Find("Text2").GetComponent<Text>();
      texto2.text = moedas.ToString();
      
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
            Destroy(collision.gameObject);
            if(vida<=0)
            {
                SceneManager.LoadScene(3);
            }
            score=score-10;
            texto1.text = score.ToString();
            Destroy(collision.gameObject);
            
        }
        
        if(collision.gameObject.CompareTag("Vidas"))
        {
            vida++;
            texto.text = vida.ToString();
            Destroy(collision.gameObject);          
            
            
        }
        if(collision.gameObject.CompareTag("moedas"))
        {
            moedas++;
            texto2.text = moedas.ToString();
            Destroy(collision.gameObject);
            
            score=score+50;
            texto1.text = score.ToString();
            
            
        }

        if (collision.gameObject.CompareTag("vitoria"))
        {           
            SceneManager.LoadScene(2);           
            
        }
    }
    
    

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
   
    //==============esse codigo ele carrega a cena que eu quero no caso o jogo fase1===============
    public void LoadScenes(string cena)
    {
        SceneManager.LoadScene("Fase1");
        Debug.Log("Starte!");
       
    }   
    
    //==== nesse codigo eu fecho meu jogo=============
    public void Quit()
    {
        Debug.Log("Apertei o quit");
        Application.Quit();
    }
    public void LoadSceneMenu(string MenuIniciar)
    {
        SceneManager.LoadScene("MenuIniciar");
        Debug.Log("Menu Iniciar");
    }   
    

}

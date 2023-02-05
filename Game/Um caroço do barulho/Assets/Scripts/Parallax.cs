using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
     private float largura, posicaoInicial;
     private Transform camera;
     public float ParallaxEfect;

    // Start is called before the first frame update
    void Start()
    {
        posicaoInicial=transform.position.x;
        largura=GetComponent<SpriteRenderer>().bounds.size.x;
        camera=Camera.main.transform;
    } 

    // Update is called once per frame
    void Update()
    {
        float RePosic = camera.transform.position.x*(1-ParallaxEfect);
        float Distance=camera.transform.position.x*ParallaxEfect;
        transform.position = new Vector3(posicaoInicial + Distance, transform.position.y, transform.position.z);
        if( RePosic > posicaoInicial + largura)
        {
            posicaoInicial += largura;
        }
        else if (RePosic < posicaoInicial - largura)
        {
            posicaoInicial -= largura;
        }
    }
}

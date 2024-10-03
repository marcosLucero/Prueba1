using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minPantalla, maxPantalla;
    [SerializeField] private GameObject prefabProjectil;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //poniedno limites de la pantalla
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //mas limites

        float midaMeitatImatgeX = GetComponent<SpriteRenderer>().sprite.bounds.size.x  * transform.localScale.x / 2; //version larga
        float midaMeitatImatgeY = GetComponent<SpriteRenderer>().bounds.size.y / 2; //version corta


        // minPantalla.x = minPantalla.x + 0.60f;  //parametros de la nave para que no quede media ala de el eje X
        // maxPantalla.x = maxPantalla.x - 0.60f;
        // minPantalla.x += 0.75f;     //+= para cuando es la misma, queda mejor

        // Ajusta los limites de la pantalla considerando el tamaño del sprite de la nave de todos los parametros
        /*
        minPantalla.x += GetComponent<SpriteRenderer>().bounds.size.x / 2;  //Parametros de las esquinas y de todos los ejes positivos y negativos
        maxPantalla.x -= GetComponent<SpriteRenderer>().bounds.size.x / 2;
        minPantalla.y += GetComponent<SpriteRenderer>().bounds.size.y / 2;
        maxPantalla.y -= GetComponent<SpriteRenderer>().bounds.size.y / 2; */

       // minPantalla = new Vector2(minPantalla.x + naveAncho, minPantalla.y + naveAlto);
       // maxPantalla = new Vector2(maxPantalla.x - naveAncho, maxPantalla.y - naveAlto);


         minPantalla.x += midaMeitatImatgeX;
         maxPantalla.x -= midaMeitatImatgeX;
         minPantalla.y += midaMeitatImatgeY;
         maxPantalla.y -= midaMeitatImatgeY;

           //parametros de la nave para que no quede media ala de el eje Y
        // maxPantalla.y = maxPantalla.y - 0.70f;
    }

    // Update is called once per frame
    void Update()
    {
        MovimientNau();
        DisparaProjectil();




        
    }
    private void MovimientNau()
    {
        float direcioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direcioIndicadaY = Input.GetAxisRaw("Vertical"); 



        Vector2 direcioIndicada = new Vector2(direcioIndicadaX, direcioIndicadaY).normalized;
        
        Vector2 novaPos = transform.position;
        novaPos = novaPos + direcioIndicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        if (objecteTocat.tag == "Numero")
        {
            Destroy(gameObject);
        }
    }
    private void DisparaProjectil()
    {
        if (Input.GetKeyDown("space")) //con GetKeyDown solo sale uno pero con GetKey salen infinito
        {
            GameObject proyectil = Instantiate(prefabProjectil);
            proyectil.transform.position = transform.position;
        }
    }
}

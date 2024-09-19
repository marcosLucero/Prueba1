using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;

    private Vector2 minPantalla, maxPantalla;


    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;
        minPantalla = Camera.main.ViewportToWorldPoint(new Vector2(0, 0)); //poniedno limites
        maxPantalla = Camera.main.ViewportToWorldPoint(new Vector2(1, 1)); //mas limites
       
        
        minPantalla.x = minPantalla.x + 0.75f;  //parametros de la nave para que no quede media ala
        maxPantalla.x = maxPantalla.x + -0.75f;
        
        minPantalla.y = minPantalla.y + 0.75f;
        maxPantalla.y = maxPantalla.y + -0.75f;
    }

    // Update is called once per frame
    void Update()
    {
        float direcioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direcioIndicadaY = Input.GetAxisRaw("Vertical"); //* _vel * Time.deltaTime;



        Vector2 direcioIndicada = new Vector2(direcioIndicadaX, direcioIndicadaY).normalized;
        
        Vector2 novaPos = transform.position;
        novaPos = novaPos + direcioIndicada * _vel * Time.deltaTime;

        novaPos.x = Mathf.Clamp(novaPos.x, minPantalla.x, maxPantalla.x);
        novaPos.y = Mathf.Clamp(novaPos.y, minPantalla.y, maxPantalla.y);

        transform.position = novaPos;



        //transform.Translate(Vector3.up * direcioIndicadaY);
        //transform.Translate(Vector3.forward * -direcioIndicadaX);

        //Debug.Log("x:" + direcioIndicadaX + " - Y:" + direcioIndicadaY);
    }
}

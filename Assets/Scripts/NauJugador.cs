using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    private float _vel;
    // Start is called before the first frame update
    void Start()
    {
        _vel = 8;
    }

    // Update is called once per frame
    void Update()
    {
        float direcioIndicadaX = Input.GetAxisRaw("Horizontal");
        float direcioIndicadaY = Input.GetAxisRaw("Vertical"); //* _vel * Time.deltaTime;


        Vector2 direcioIndicada = new Vector2(direcioIndicadaX, direcioIndicadaY).normalized;
        
        Vector2 novaPos = transform.position;
        novaPos = novaPos + direcioIndicada * _vel * Time.deltaTime;
        transform.position = novaPos;



        //transform.Translate(Vector3.up * direcioIndicadaY);
        //transform.Translate(Vector3.forward * -direcioIndicadaX);

        //Debug.Log("x:" + direcioIndicadaX + " - Y:" + direcioIndicadaY);
    }
}

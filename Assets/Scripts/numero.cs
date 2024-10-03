using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class numero : MonoBehaviour
{
   private float _vel;

    public Sprite[] spritesNumerosPossibles = new Sprite[10];

    private int valorNumero;

   private Vector2 minPantall;

    // Start is called before the first frame update
    void Start()
    {
        _vel = 5f;

        System.Random aleatori = new System.Random();
        valorNumero = aleatori.Next(0, 10);
        GetComponent<SpriteRenderer>().sprite = spritesNumerosPossibles[valorNumero];


        minPantall = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos = novaPos + new Vector2(0, -1) * _vel * Time.deltaTime;
        transform.position = novaPos;

        if (transform.position.y < minPantall.y)

            Destroy(gameObject);


    }
    private void OnTriggerEnter2D(Collider2D objectTocat)
    {
        if (objectTocat.tag == "ProjectilJugador" || objectTocat.tag == "NauJugado")
        {
            Destroy(gameObject);
        }
    }
}

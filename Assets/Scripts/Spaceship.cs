using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spaceship : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] GameObject bala;
    [SerializeField] GameObject balaRafaga;
    [SerializeField] GameObject disparador;
    [SerializeField] GameObject balaUI;
    [SerializeField] GameObject balarafagaUI;

    [SerializeField] float fireRate;



    float minX, maxX, minY, maxY;
    float nextFire = 0;
    float nextRafaga = 0;
    bool cambiarBala = true;
   // int veceshabilidad = 3;




    // Start is called before the first frame update
    void Start()
    {

        Vector2 esquinaSupDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 1));
        Vector2 puntoMinParaY = Camera.main.ViewportToWorldPoint(new Vector2(0, 0.7f));

        maxX = esquinaSupDer.x - 0.7f;
        maxY = esquinaSupDer.y - 0.7f;
        minX = puntoMinParaY.x + 0.7f;
        minY = puntoMinParaY.y;

    }

    // Update is called once per frame
    void Update()
    {
        MoverNave();
        if (cambiarBala)
        {
            Disparar();
            balaUI.SetActive(true);
            balarafagaUI.SetActive(false);
        }
        else
        {
            DispararRafaga();
            balaUI.SetActive(false);
            balarafagaUI.SetActive(true);
        }



        if (Input.GetKeyDown(KeyCode.Z))
            cambiarBala = cambiarBala ? false : true;

       // HabilidadEspecial();

    }

    void DispararRafaga()
    {

        if (Input.GetKey(KeyCode.Space) && Time.time >= nextRafaga)
        {
            Instantiate(balaRafaga, disparador.transform.position, transform.rotation);
            nextRafaga = Time.time + (fireRate / 2);
        }

    }

    void Disparar()
    {
        if(Input.GetKeyDown(KeyCode.Space) && Time.time >= nextFire)
        {
            Instantiate(bala, disparador.transform.position, transform.rotation);
            nextFire = Time.time + fireRate;
        }
    }

    void MoverNave()
    {
        float movH = Input.GetAxis("Horizontal");
        float movV = Input.GetAxis("Vertical");

        Vector2 movimiento = new Vector2(movH * Time.deltaTime * speed, movV * Time.deltaTime * speed);

        //Aca se mueve
        transform.Translate(movimiento);

        //aca voy a verifica la posicion
        if (transform.position.x > maxX)
        {
            //devuelvase a maxX
            transform.position = new Vector2(maxX, transform.position.y);

        }
        if (transform.position.x < minX)
        {
            //devuelvase a minX
            transform.position = new Vector2(minX, transform.position.y);
        }

        if (transform.position.y > maxY)
        {
            //devuelvase a maxY
            transform.position = new Vector2(transform.position.x, maxY);
        }
        if (transform.position.y < minY)
        {
            //devuelvase a minY
            transform.position = new Vector2(transform.position.x, minY);
        }
    }

    /*public void HabilidadEspecial()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            if (Time.timeScale == 1 && veceshabilidad > 0)
            {
                Time.timeScale = 0.5f;
                veceshabilidad--;
            }
            else
            {
                Time.timeScale = 1;

            }
        }
    }*/

}
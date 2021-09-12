using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float speed;
    [SerializeField] bool movingRight;
    [SerializeField] int puntosDeVida;

    float minX, maxX;



    // Start is called before the first frame update
    void Start()
    {
        Vector2 esquinaInfDer = Camera.main.ViewportToWorldPoint(new Vector2(1, 0));
        Vector2 esquinaInfIzq = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));

        maxX = esquinaInfDer.x;
        minX = esquinaInfIzq.x;
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(movingRight)
        {
            Vector2 movimiento = new Vector2(speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        else
        {
            Vector2 movimiento = new Vector2(-speed * Time.deltaTime, 0);
            transform.Translate(movimiento);
        }
        

        if(transform.position.x >= maxX)
        {
            movingRight = false;
        }
        else if(transform.position.x <= minX)
        {
            movingRight = true;
        }
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if(collision.gameObject.CompareTag("Disparo") )
        {

            if (Time.timeScale == 1)
            {
                puntosDeVida--;

                if (puntosDeVida <= 0)
                {
                    Mataranimal();
                }
            }
            else if (Time.timeScale == 0.5f)
            {
                Mataranimal();
            }
        }
    }

    public void Mataranimal ()
    {
        GameObject gm = GameObject.Find("GameManager");
        GameManager script = gm.GetComponent<GameManager>();
        script.CaptureAnimal();

        Destroy(this.gameObject);
    }


}
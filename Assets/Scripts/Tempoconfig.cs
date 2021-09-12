using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tempoconfig : MonoBehaviour
{
    [SerializeField] float Tiempo;
    private float time;
    private bool run;
    private int limitehabilidad;
    private bool activo;
    // Start is called before the first frame update
    void Start()
    {
        time = Tiempo;
        limitehabilidad = 3;
        activo = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (activo == false)
        {
            IniciarTemporizador();
        }

        if (run)
        {
            Temporizador();
            InicioHabilidad();
            activo = true;
        }
        else
        {
            time = Tiempo;
            FinalHabilidad();
            activo = false;
        }
    }

    public void IniciarTemporizador ()
    {
        if (Input.GetKeyDown(KeyCode.T) && limitehabilidad > 0)
        {
            run = true;
            limitehabilidad = limitehabilidad - 1;
        }
    }
    public void Temporizador()
    {
        time = time - 2 * Time.deltaTime;
        Debug.Log(time);

        if (time <= 0)
        {
            Debug.Log("Finaltiempo");
            time = 0;
            run = false;
        }
    }

    public void InicioHabilidad()
    {
        Time.timeScale = 0.5f;
    }

    public void FinalHabilidad()
    {
        Time.timeScale = 1f;
    }


}

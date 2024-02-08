using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChampiController : MonoBehaviour
{
    public float velocidad = 2;
    private bool esDerecha;
    public float tiempoParaIntercambio = 1.5f;
    public float temporizador;


    void Start()
    {
        
    }

    private void Awake()
    {
        temporizador = tiempoParaIntercambio;
        esDerecha = true;
    }

    void Update()
    {
        if(esDerecha)
        {
            this.transform.position += Vector3.right * velocidad * Time.deltaTime;
            this.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        }
        else
        {
            this.transform.position += Vector3.left * velocidad * Time.deltaTime;
            this.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }

        temporizador -= Time.deltaTime;
        if (temporizador <= 0)
        {
            temporizador = tiempoParaIntercambio;
            esDerecha = !esDerecha;
        }
    }

    public void Morir()
    {
        Destroy(gameObject);
    }
}

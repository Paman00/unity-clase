using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    private Rigidbody2D rigidBodyPersonaje;
    public float desplazamientoFuerza = 500;
    public float fuerzaSalto = 7f;
    public LayerMask sueloLayer;
    private Animator animPersonaje;

    // Start is called before the first frame update
    void Start()
    {

    }

    void Awake()
    {
        rigidBodyPersonaje = GetComponent<Rigidbody2D>();
        animPersonaje = GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        animPersonaje.SetBool("estaCorriendo", false);
        animPersonaje.SetBool("enAire", !EstaTocandoSuelo());

        if ((Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)) && EstaTocandoSuelo())
        {
            MirarDerecha();
            animPersonaje.SetBool("estaCorriendo", true);
            MoverDerecha();
        }
        if ((Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow)) && EstaTocandoSuelo())
        {
            MirarIzquierda();
            animPersonaje.SetBool("estaCorriendo", true);
            MoverIzquierda();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Saltar();
        }
    }

    void MirarDerecha()
    {
        transform.rotation = Quaternion.AngleAxis(180, Vector3.up); //Mira a la derecha
    }

    void MirarIzquierda()
    {
        transform.rotation = Quaternion.AngleAxis(0, Vector3.up);   //Mira a la izquierda
    }

    void MoverDerecha()
    {
        rigidBodyPersonaje.AddForce(Vector2.right * (desplazamientoFuerza * Time.deltaTime), ForceMode2D.Force);
    }

    void MoverIzquierda()
    {
        rigidBodyPersonaje.AddForce(Vector2.left * (desplazamientoFuerza * Time.deltaTime), ForceMode2D.Force);
    }

    void Saltar()
    {
        if (EstaTocandoSuelo())
        {
            rigidBodyPersonaje.AddForce(Vector2.up * fuerzaSalto, ForceMode2D.Impulse);
        }
    }

    public bool EstaTocandoSuelo()
    {
        return Physics2D.Raycast(transform.position, Vector2.down, 1.5f, sueloLayer);
    }
}
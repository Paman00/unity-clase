using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : MonoBehaviour
{
    public Transform transformPerseguido;
    public float velocidadPerseguidor = 0.7f;

    [SerializeField] 
    private float distanciaPersecucion = 4;

    private float distanciaParcial;

    private Animator animZombie;

    public bool hayPersecucion;

    private Vector2 posicionObjetivo = new Vector2();

    void Start()
    {
        
    }

    private void Awake()
    {
        animZombie = GetComponentInChildren<Animator>();
    }   

    void Update()
    {
        animZombie.SetBool("estaAndandoZombie", false);
        distanciaParcial = transformPerseguido.position.x - transform.position.x;
    
        hayPersecucion = System.Math.Abs(distanciaParcial) <= distanciaPersecucion;

        if (distanciaParcial > 0)
        {
            this.transform.rotation = Quaternion.AngleAxis(0, Vector3.up);
        } else
        {
            this.transform.rotation = Quaternion.AngleAxis(180, Vector3.up);
        }

        if (hayPersecucion)
        {
            MoverHaciaPerseguido();
        }
    }

    void MoverHaciaPerseguido()
    {
        animZombie.SetBool("estaAndandoZombie", true);
        posicionObjetivo.x = transformPerseguido.position.x;
        posicionObjetivo.y = transform.position.y;
        transform.position = Vector2.MoveTowards(
            transform.position, posicionObjetivo, velocidadPerseguidor * Time.deltaTime
        );
    }
}

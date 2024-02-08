using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillChampi : MonoBehaviour
{
    public ChampiController champiController;
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            if (PlayerController.sharedInstance.EstaTocandoSuelo())
            {
                GameManager.sharedInstance.GameOver();
            }
            else
            {
                champiController.Morir();
            }
        }
    }
}

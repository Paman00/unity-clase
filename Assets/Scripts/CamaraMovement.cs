using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using UnityEngine;

public class CamaraMovement : MonoBehaviour {
    public Vector3 desplazamiento;
    public Transform playerTransform;

    void Start() {
        
    }

    void Update() {
        transform.position = new Vector3(
            playerTransform.position.x, 
            transform.position.y, 
            playerTransform.position.z + desplazamiento.z 
        );        
    }

    private void Awake() {
        desplazamiento.x = 0;
        desplazamiento.y = 0;
        desplazamiento.z = -10;
    }
}

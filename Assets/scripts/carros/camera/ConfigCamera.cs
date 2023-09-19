using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConfigCamera : MonoBehaviour
{

    public float distanciaZ, distanciaY, maxRotacaoX, velocidadeMover;
    public int tipoCamera = 0; //0 - Automática // 1 - Guiada // 2- Livre
    public GameObject Player;
    void Start(){
        Player = gameObject;
    }

    void Update(){
        
    }


}

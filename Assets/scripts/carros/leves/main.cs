using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main : MonoBehaviour
{
    private ControleRodas ControleRodas;

    public float velocidade;

    public GameObject centroDeMassa;

    public bool PodeMovimentar = true;
    Rigidbody rb;
    void Start(){
        rb = GetComponent<Rigidbody>();
        ControleRodas = gameObject.GetComponent<ControleRodas>();

        rb.centerOfMass = centroDeMassa.transform.localPosition;
    }

    // Update is called once per frame
    void Update(){
        velocidade = Vector3.Dot(rb.velocity, transform.forward);//Calcula A Velocidade Do Veiculo
        if (PodeMovimentar) { ControleRodas.Movimentar(); } //Responsval Pela Movimentação Das Rodas
    }
}

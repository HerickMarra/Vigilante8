using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class CapturarControles : MonoBehaviour
{
    public float Vertical, Horizontal;
    public bool Freio;
    void Start()
    {
        
    }

    
    void Update(){
        CapturaAxis();
        CapturaFreio();
    }


    /**
     * Função Responsável Por Capturar As Axis Horizontal e Vertical
     */
    private void CapturaAxis(){
        Vertical = Input.GetAxis("Vertical");
        Horizontal = Input.GetAxis("Horizontal");

    }


    /**
     * Função Responsavel Por Capturar o input de Freiar 
     */
    private string TeclaFreio = "space";
    private void CapturaFreio(){
        Freio = Input.GetKey(TeclaFreio);
    }

    /**
     * Get e Set Freio
     */
    public void setFreio(bool Freio) { 
        this.Freio = Freio;
    }
    public bool getFreio() { 
        return Freio;
    }






}

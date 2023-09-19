using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour
{
    public ConfigCamera config;
    private main main;
    private CapturarControles controles;

    private GameObject player;
    public GameObject cam;

    public bool ativo = true;
    void Start(){
        getControles();
        getPlayer();

        if (ativo){
        }
    }

    void Update(){
        if (ativo){
            CamRotacao();
            Cursor.lockState = CursorLockMode.Locked;  // Trava o cursor no centro da tela.
            Cursor.visible = false;  // Torna o cursor invisível.
        }
    }

    private void FixedUpdate(){
        if (ativo){
            Retorno();
            CamMove();
        }
    }



    /*
     * Função Responsavel Por Controlar a movimentação da camera
     */
    public void CamMove(){
        cam.transform.localPosition = new Vector3(0, 0 + config.distanciaY, 0 + config.distanciaZ);
        Transform camT = gameObject.transform;
        Transform playerT = player.transform;
        camT.position = new Vector3(playerT.transform.position.x, playerT.transform.position.y, playerT.transform.position.z);
    }


    /*
     * Função Responsavel Por Controlar A Rotação Do Player Em Relação Ao Mouse
     */
    public void CamRotacao(){
        float mouse = Input.GetAxis("Mouse X");
        bool retorno = controles.Vertical != 0 ||  controles.Horizontal != 0;
        if (mouse == 0 && Retorno()) {
                float dir = main.velocidade > -0.0001f ? player.transform.eulerAngles.y : player.transform.eulerAngles.y +180;
                Quaternion rotacaoDesejada = Quaternion.Euler(0, dir, 0);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotacaoDesejada, 3f  * Time.deltaTime); // Exemplo com valor 0.5
        }
        else{
                if (mouse != 0) { mouseUltimaData = DateTime.Now; }
                gameObject.transform.Rotate(Vector3.up, mouse * config.velocidadeMover);
        }
    }


    private DateTime mouseUltimaData = DateTime.Now; 
    private bool Retorno(){
        DateTime dataAtual = DateTime.Now;
        TimeSpan diferenca = mouseUltimaData - dataAtual;
        return diferenca.Seconds < -3 ? true : false;
    }





    /*
     * Função Responsavel Pegar as informações do Player
     * @return GameObject
     */
    private GameObject getPlayer(){
        player = GameObject.FindWithTag("Player");
        if (player == null){
            ativo = false;
            return null;
        }
        config = player.GetComponent<ConfigCamera>();
        main = player.GetComponent<main>();
        return player;
    }

    void getControles() {
        controles = GameObject.FindWithTag("CapturaControles").GetComponent<CapturarControles>();
    }

}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;

public class ControleRodas : MonoBehaviour
{
    /**
     * Rodas
     */
    public WheelCollider[] RodasDianteiras; 
    public WheelCollider[] RodasTrazeiras;
    public GameObject[] mRodasDianteiras;
    public GameObject[] mRodasTrazeiras;
    /**
    * Rodas
    */

    public CapturarControles CapturarControles;


    public float MotorTorque,brakeTorque,multiplicadorDerrapagemF=10;
    public float AnguloRotacao;
    public bool TracaoDianteira, TracaoTrazeira;

    void Start(){
        CapturarControles =  GameObject.FindWithTag("CapturaControles").GetComponent<CapturarControles>();

        WheelFrictionCurve atritoLateral = RodasTrazeiras[0].sidewaysFriction;
        extremumSlip = atritoLateral.extremumSlip;
    }

    
    void Update(){
        /**
         * Atualiza��o Das Posi��es Das Rodas
         */
        AtualizarPosicaoRodasMesh(RodasTrazeiras, mRodasTrazeiras);
        AtualizarPosicaoRodasMesh(RodasDianteiras, mRodasDianteiras);
        VirarRodas();
        FreioDeMao();
        Freiar();
    }


    /**
     * Fun��o Responsavel Por Fazer o Veiculo 
     * Se Locomover Em Rela��o A Tra��o Definida
     */
    public void Movimentar(){
        if (TracaoTrazeira){
            foreach (var item in RodasTrazeiras){
                item.motorTorque = MotorTorque * CapturarControles.Vertical;
            }
        }

        if (TracaoDianteira){
            foreach (var item in RodasDianteiras){
                item.motorTorque = MotorTorque * CapturarControles.Vertical;
            }
        }

    }


    /**
     * Fun��o Responsavel Por Atualizar As Mesh Das Rodas
     */
    private void AtualizarPosicaoRodasMesh(WheelCollider[] wheel , GameObject[] mesh ){
        for (int i = 0; i < wheel.Length; i++){
            // Obt�m a posi��o e a rota��o do Wheel Collider
            Vector3 pos;
            Quaternion rot;
            wheel[i].GetWorldPose(out pos, out rot);

            // Atualiza a posi��o e a rota��o da mesh da roda
            mesh[i].transform.position = pos;
            mesh[i].transform.rotation = rot;
        }
        
    }


    /**
     * Fun��o Responsvel Por Rotacionar as Rodas Dianteiras
     */
    private void VirarRodas(){
        for (int i = 0; i < RodasDianteiras.Length; i++){
            RodasDianteiras[i].steerAngle = AnguloRotacao * CapturarControles.Horizontal;
        }
    }


    float extremumSlip;

    /**
     * Fun��o Responsavel Por Controlar o Freio De M�o
     */
    public void FreioDeMao()
    {

        if (CapturarControles.Freio)
        {
            foreach (var item in RodasTrazeiras)
            {
                item.brakeTorque = brakeTorque * 1;
                WheelFrictionCurve atritoLateral = item.sidewaysFriction;
                // Defina o valor extremumSlip.
                atritoLateral.extremumSlip = extremumSlip*multiplicadorDerrapagemF;
                // Atribua a configura��o atualizada de atrito lateral de volta ao WheelCollider.
                item.sidewaysFriction = atritoLateral;
            }
        }else{

            foreach (var item in RodasTrazeiras)
            {
                WheelFrictionCurve atritoLateral = item.sidewaysFriction;
                // Defina o valor extremumSlip.
                atritoLateral.extremumSlip = extremumSlip;
                // Atribua a configura��o atualizada de atrito lateral de volta ao WheelCollider.
                item.sidewaysFriction = atritoLateral;


                item.brakeTorque = brakeTorque * 0;
            }
        }

        /*
        if (TracaoDianteira)
        {
            foreach (var item in RodasDianteiras)
            {
                item.motorTorque = MotorTorque * CapturarControles.Vertical;
            }
        }
        */

    }

    public void Freiar(){

    }


}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class raycast : MonoBehaviour
{
    private agentnav agentScript;
float RaycastDistancia = 10f;
    public Rigidbody balaPrefab;
    public Transform puntoDisparo;
    public float fuerzaDisparo = 500f;

    private float tiempoEntreDisparos = 0.25f;
    private float contadorDisparo = 0f;
    void Start()
{

    agentScript = GetComponent<agentnav>();
}

void Update()
{
    bool JugadorDetectado = false;

    Debug.DrawRay(transform.position, transform.forward * RaycastDistancia, Color.red);

    if (Physics.Raycast(transform.position, transform.forward, out RaycastHit hitInfo, RaycastDistancia))
    {
        if (hitInfo.collider.gameObject.tag == "Player")
        {
                Disparar();
                agentScript.patrullando = false;
            agentScript.jugadorEnVision = true;
            agentScript.tiempoSinVision = 0;
            JugadorDetectado = true;
        }
    }

    if (!JugadorDetectado)
    {
        agentScript.jugadorEnVision = false;
    }

    if (!agentScript.jugadorEnVision && !agentScript.patrullando)
    {
        agentScript.tiempoSinVision += (int)(Time.deltaTime * 100);
        Debug.Log(agentScript.tiempoSinVision);
        if (agentScript.tiempoSinVision >= 500)
        {
            agentScript.patrullando = true;
            agentScript.tiempoSinVision = 0;
        }
    }
}
    void Disparar()
    {
        contadorDisparo += Time.deltaTime;

        if (contadorDisparo < tiempoEntreDisparos) return;

        contadorDisparo = 0f;

        Rigidbody bala = Instantiate(balaPrefab, puntoDisparo.position, puntoDisparo.rotation);

        bala.AddForce(puntoDisparo.forward * fuerzaDisparo);
    }

}
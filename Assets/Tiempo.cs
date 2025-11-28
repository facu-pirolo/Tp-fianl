using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class Tiempo : MonoBehaviour
{
    public TextMeshProUGUI textoFinal;



    // Start is called before the first frame update
    void Start()
    {
    float tiempo = cornometros.tiempoFinal;

    int minutos = Mathf.FloorToInt(tiempo / 60);
    int segundos = Mathf.FloorToInt(tiempo % 60);

    textoFinal.text = "Tu tiempo: " + minutos.ToString("00") + ":" + segundos.ToString("00");
}

    
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class cornometros : MonoBehaviour
{
    public TextMeshProUGUI tiempoTexto;
    private float tiempo = 0f;
    public bool contando = true;
    public static float tiempoFinal;

    void Update()
    {
        if (contando)
        {
            tiempo += Time.deltaTime;

            int minutos = Mathf.FloorToInt(tiempo / 60);
            int segundos = Mathf.FloorToInt(tiempo % 60);

            tiempoTexto.text = minutos.ToString("00") + ":" + segundos.ToString("00");
            tiempoFinal = tiempo;
        }
    }
}

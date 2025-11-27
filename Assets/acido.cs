using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class acido : MonoBehaviour
{
    public float daño = 1f;

    void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("Player"))
        {
            SceneManager.LoadScene("Perdiste");
        }

        Destroy(gameObject);
    }
}


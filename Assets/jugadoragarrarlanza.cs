using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jugadoragarrarlanza : MonoBehaviour
{
    public Transform weaponHolder;
    public float pickupRange = 6f;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            TryPickup();
        }
    }

    void TryPickup()
    {
        RaycastHit hit;

        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, pickupRange))
        {
            if (hit.collider.CompareTag("Weapon"))
            {
                hit.collider.GetComponent<agarrarlanza>().PullToHand(weaponHolder);
            }
        }
    }
}

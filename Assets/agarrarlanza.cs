using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class agarrarlanza : MonoBehaviour
{
    public float pickupForce = 500f;
    private bool movingToHand = false;
    private Transform hand;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (movingToHand)
        {
            if (Vector3.Distance(transform.position, hand.position) < 0.25f)
            {
                rb.isKinematic = true;
                transform.SetParent(hand);
                transform.localPosition = Vector3.zero;
                transform.localRotation = Quaternion.identity;
                movingToHand = false;
            }
        }
    }

    public void PullToHand(Transform handPos)
    {
        hand = handPos;
        movingToHand = true;

        Vector3 dir = (hand.position - transform.position).normalized;
        rb.AddForce(dir * pickupForce, ForceMode.Impulse);
    }
}

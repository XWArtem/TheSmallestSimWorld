using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vendor : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(ConstValues.PlayerTag))
        {
            Debug.Log("Let's trade");

        }
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.name == "Player")
        {
            Task2.instance.coinsCollected++;
            Destroy(this.gameObject);
        }
    }
}

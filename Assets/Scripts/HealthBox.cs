using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBox : MonoBehaviour
{
    void OnTriggerEnter(Collider col) {
        if (col.gameObject.CompareTag("Player")) {
            HealthManager.instance.ChangeHealth(2);
            Destroy(this.gameObject);
        } }
}

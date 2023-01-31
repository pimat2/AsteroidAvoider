using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Asteroid : MonoBehaviour
{
   private void OnTriggerEnter(Collider other) {
        if(other.GetComponent<PlayerHealth>()){
            other.GetComponent<PlayerHealth>().Crash();
        }
        else{
            return;
        }
   }
   void OnBecameInvisible() {
        Destroy(gameObject); 
   }
}

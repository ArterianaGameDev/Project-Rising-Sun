using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimerReduceItem : MonoBehaviour
{
    // Start is called before the first frame update


    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PickupItem")
        {
            UITimer.Timer -= 0.5f;
            Destroy(other.gameObject); 
        }
    }
}

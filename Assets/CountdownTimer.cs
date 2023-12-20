using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class CountdownTimer : MonoBehaviour
{


    public TextMeshPro timerUi;
    private float timer;
    // Start is called before the first frame update

    // Update is called once per frame

    private void Start() {
        timerUi = GetComponent<TextMeshPro>();
        timer = 0f;
        Debug.Log(timerUi.text);
    }
   /* void Update()
    {
        timer += Time.deltaTime;
        timerUi.text = "Time: " + timer;
    }
    */
}

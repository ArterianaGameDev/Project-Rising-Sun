using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class TargetScore : MonoBehaviour
{
    public TMPro.TMP_Text ScoreDisplay;
    static public int Score = 0;
    public GameObject Target;
    

    // Classname.VariableName(TargetScore.Score);
    public void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Bult") 
        {
         Score += 1;
        ScoreDisplay.text = "Score: " + Score;      
        Destroy(other.gameObject);
        Destroy(Target);        
        }


    }

}

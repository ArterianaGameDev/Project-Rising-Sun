using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPoint;
    public Transform Checkpoint1;


    void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Floor")
        {
            transform.position = startPoint.position;
        }
        
        
    }

    void OnTriggerEnter(Collider other)
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
        if(other.gameObject.tag == "Checkpoint")
        {
            Debug.Log("This works lol");
            startPoint = other.gameObject.GetComponent<Transform>();
            Debug.Log("This still works lol");
        
        }
        else if(other.gameObject.tag == "Finish")
        {
            Debug.Log(SceneIndex);
            if(SceneIndex + 1 == SceneManager.sceneCountInBuildSettings)
            {
                SceneManager.LoadScene(0);
            }
            else
            {
                SceneManager.LoadScene(SceneIndex + 1);
            }
        }
    }
}

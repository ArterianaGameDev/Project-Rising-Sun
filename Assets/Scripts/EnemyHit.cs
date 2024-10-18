using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHit : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform startPoint;
    public Transform Checkpoint1;
    public GameObject endOfLevelUI;
    public GameObject Crosshair;
    private Rigidbody rb;

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    void OnCollisionEnter(Collision other)
    {
        
        if(other.gameObject.tag == "Floor")
        {
            transform.position = startPoint.position;
        }
        
        
    }
    public void nextScene()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
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



    void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Checkpoint")
        {
            Debug.Log("This works lol");
            startPoint = other.gameObject.GetComponent<Transform>();
            Debug.Log("This still works lol");
        
        }
        else if(other.gameObject.tag == "Finish")
        {
            endOfLevelUI.SetActive(true);
            Crosshair.SetActive(false);
            rb.constraints = RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
            Cursor.lockState = CursorLockMode.None;
        }   
    }

    public void reLoadScene()
    {
        int SceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(SceneIndex);
        Debug.Log("click");
    }
}

using UnityEngine;
using UnityEngine.UI;

public class UITimer : MonoBehaviour
{	
 public Text TimerText; 
 public bool playing;
 public static float Timer;
 public Transform Spawnpoint;
 void Update () {


	
 	if(playing == true){
  
	  Timer += Time.deltaTime;
	  int minutes = Mathf.FloorToInt(Timer / 60F);
	  int seconds = Mathf.FloorToInt(Timer % 60F);
	  int milliseconds = Mathf.FloorToInt((Timer * 100F) % 100F);
	  TimerText.text = minutes.ToString ("00") + ":" + seconds.ToString ("00") + ":" + milliseconds.ToString("00");
	}

  }

  private void OnTriggerEnter(Collider other)
  {
	 if(other.tag == "Start")
	 {
	 	Timer = 0;
	 	playing = true;
		Destroy(other.gameObject);
	 }
	// if(other.tag == "Finish")
	// 	{
	// 	playing = false;
	// 	transform.position = Spawnpoint.position;
	// 	}
	
  }


}
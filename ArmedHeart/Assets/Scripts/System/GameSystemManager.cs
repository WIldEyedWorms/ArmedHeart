using UnityEngine;
using System.Collections;

public class GameSystemManager : MonoBehaviour {

	// Use this for initialization
	void Awake () {
		CheckGyroEnable ();
	}
	
	void CheckGyroEnable()
	{
		//Active Gyro.
		bool tGyroEnable = SystemInfo.supportsGyroscope;
		if( tGyroEnable )
		{
			Input.gyro.enabled = true;
		}
		else
		{
			Debug.Log("Gyro is not supported.");
		}
	}
}

using UnityEngine;
using System.Collections;

public class GameSystemManager : MonoBehaviour {

	public GameDB gameDB;
	public AssetBundleManager assetBundleManager;
	public ResourceManager resourceManager;
	public GameInfo gameInfo;

	private static GameSystemManager mInstance;
	public static GameSystemManager Instance
	{
		get
		{
			if (mInstance == null) 
			{
				GameObject tObj = GameObject.Find ("GameSystemManager").gameObject;
				mInstance = tObj.GetComponent<GameSystemManager> ();
			}
			return mInstance;
		}
	}

	// Use this for initialization
	void Awake () 
	{
		mInstance = this;
		GameObject.DontDestroyOnLoad (gameObject);
		gameDB.LoadDB ();
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

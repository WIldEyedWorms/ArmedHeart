using UnityEngine;
using System.Collections;

public class GameDB : MonoBehaviour {


	public TestDB testDB;
	// Use this for initialization
	void Start () {
		LoadDB ();
	}

	public void LoadDB()
	{
		testDB = new TestDB ();
		testDB.Load ("Test");
	}
}

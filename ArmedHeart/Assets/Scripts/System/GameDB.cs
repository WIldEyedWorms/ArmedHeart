using UnityEngine;
using System.Collections;

public class GameDB : MonoBehaviour {
	
	public BulletDB bulletDB;
	public AssetDB  assetDB;

	public void LoadDB()
	{
		bulletDB = new BulletDB ();
		bulletDB.Load ("Bullet");

		assetDB = new AssetDB ();
		assetDB.Load ("Asset");
	}
}

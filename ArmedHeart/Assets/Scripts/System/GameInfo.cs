using UnityEngine;
using System.Collections;


[System.Serializable]
public class BattleInData
{
	public GunInfo[] gunInfos;
}

[System.Serializable]
public class GunInfo
{
	public BulletInfo bulletInfo;
}

[System.Serializable]
public class BulletInfo
{
	public int bulletId;
}
public class GameInfo : MonoBehaviour {

	public BattleInData battleInData;
	void Awake()
	{
		battleInData = new BattleInData ();
		battleInData.gunInfos = new GunInfo[1];
		battleInData.gunInfos [0] = new GunInfo ();
		battleInData.gunInfos [0].bulletInfo = new BulletInfo ();
		battleInData.gunInfos [0].bulletInfo.bulletId = 1;
	}
}

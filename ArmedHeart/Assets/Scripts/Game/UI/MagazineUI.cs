using UnityEngine;
using System.Collections;

public class MagazineUI : MonoBehaviour 
{
	BulletDBData dbData = null;
	public void Initialize( int tBulletId )
	{
		dbData = GameSystemManager.Instance.gameDB.bulletDB.GetData (tBulletId);
		if( dbData == null )
		{
			return;
		}

		for( int i = 0; i < dbData.capacity; ++i )
		{
			GameObject tObj = CommonUtility.CreateInstance( (GameObject)GameSystemManager.Instance.resourceManager.GetData (dbData.assetKey), gameObject );
			tObj.transform.localPosition = new Vector3( 0.0f, 0.05f * i, 0.0f );
			tObj.transform.localEulerAngles = new Vector3( -30.0f, 30.0f, 0.0f );
			tObj.layer = gameObject.layer;
		}
	}
}

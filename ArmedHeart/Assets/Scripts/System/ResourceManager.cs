using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ResourceManager : MonoBehaviour 
{
	private Dictionary<string, Object> dic = new Dictionary<string,Object >();

	public object GetData( string tKey )
	{
		if( !dic.ContainsKey( tKey ) )
		{
			return null;
		}
		return dic [tKey];
	}

	public IEnumerator IE_Load( string tKey )
	{
		if( dic.ContainsKey( tKey ) )
		{
			yield break;
		}

		AssetDBData dbData = GameSystemManager.Instance.gameDB.assetDB.GetAsset (tKey);

		if( dbData == null )
		{
			yield break;
		}

		yield return StartCoroutine( GameSystemManager.Instance.assetBundleManager.IE_Load( tKey ) );
		dic.Add (tKey, GameSystemManager.Instance.assetBundleManager.loadObject);
	}

	public IEnumerator IE_LoadBattleResource()
	{
		foreach( GunInfo gun in GameSystemManager.Instance.gameInfo.battleInData.gunInfos )
		{
			BulletDBData tData = GameSystemManager.Instance.gameDB.bulletDB.GetData( gun.bulletInfo.bulletId );
			yield return StartCoroutine( IE_Load( tData.assetKey ));
		}
	}
}

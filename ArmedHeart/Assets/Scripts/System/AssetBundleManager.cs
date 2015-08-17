using UnityEngine;
using System.Collections;

public class AssetBundleManager : MonoBehaviour {

	string serverPath = "https://s3-ap-northeast-1.amazonaws.com/";

	public Object loadObject;
	// Use this for initialization
	public IEnumerator IE_Load ( string tKey ) {

		AssetDBData dbData = GameSystemManager.Instance.gameDB.assetDB.GetAsset (tKey);
		WWW www = WWW.LoadFromCacheOrDownload (serverPath + dbData.path, dbData.version);
		
		// Wait for download to complete
		yield return www;
		
		// Load and retrieve the AssetBundle
		AssetBundle bundle = www.assetBundle;
		
		// Load the object asynchronously

		string[] tNames = bundle.GetAllAssetNames ();

		foreach( string tName in tNames )
		{
			Debug.Log ( tName );
		}
		AssetBundleRequest request = bundle.LoadAssetAsync ("assets/ammo collection/prefabs/large caliber/12,7 x 54 mm/12,7 x 54 mm round.prefab", typeof(GameObject));
		
		// Wait for completion
		yield return request;
		
		// Get the reference to the loaded object
		loadObject = request.asset;
		
		// Unload the AssetBundles compressed contents to conserve memory
		bundle.Unload(false);
		
		// Frees the memory from the web stream
		www.Dispose();
	}
}

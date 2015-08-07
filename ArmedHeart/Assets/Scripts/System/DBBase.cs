using UnityEngine;
using System.Collections;

[System.Serializable]
public class DBBase
{
	const string DBAssetPath = "DB/";
	public void Load( string tFileName )
	{
		TextAsset tText = Resources.Load (DBAssetPath + tFileName) as TextAsset;
		Debug.Log (tText.text);

		CSVParser tParser = new CSVParser ();
		tParser.Convert (tText.text);

		Debug.Log ("HOGHOGE");
	}
}

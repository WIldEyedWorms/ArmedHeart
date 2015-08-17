using UnityEngine;
using System.Collections;

public class CommonUtility
{
	public static void PlayTween( UITweener tTween )
	{
		tTween.enabled = true;
		tTween.ResetToBeginning ();
		tTween.Play ();
	}

	public static GameObject CreateInstance( GameObject tPrefab, GameObject tRoot )
	{
		GameObject tNewObj = (GameObject)GameObject.Instantiate (tPrefab);
		Vector3 tPos = tNewObj.transform.localPosition;
		Vector3 tScale = tNewObj.transform.localScale;
		Quaternion tRotation = tNewObj.transform.localRotation;
		tNewObj.transform.parent = tRoot.transform;
		tNewObj.transform.localPosition = tPos;
		tNewObj.transform.localScale = tScale;
		tNewObj.transform.localRotation = tRotation;

		return tNewObj;
	}
}

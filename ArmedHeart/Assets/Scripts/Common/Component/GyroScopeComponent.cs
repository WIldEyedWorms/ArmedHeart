using UnityEngine;
using System.Collections;

public class GyroScopeComponent : MonoBehaviour {

	#if UNITY_EDITOR
	Vector2 mPrevMousePos;
	#endif
	// Update is called once per frame
	void Update () {
		
		#if UNITY_EDITOR
		Vector2 tCurrentMousePos = Input.mousePosition;
		Vector2 tDeltaMousePos = tCurrentMousePos - mPrevMousePos;
		
		tDeltaMousePos.Normalize();
		
		tDeltaMousePos *= 0.02f;
		Quaternion tCurrentRotation = transform.localRotation;
		transform.localRotation = new Quaternion(tCurrentRotation.x + tDeltaMousePos.y, tCurrentRotation.y - tDeltaMousePos.x, tCurrentRotation.z, tCurrentRotation.w );
		
		mPrevMousePos = tCurrentMousePos;
		#else
		Quaternion tRotRH = Input.gyro.attitude;
		Quaternion tRot = new Quaternion(-tRotRH.x, -tRotRH.z, -tRotRH.y, tRotRH.w) * Quaternion.Euler(90f, 0f, 0f);
		
		transform.localRotation = tRot;
		
		#endif
	}
}

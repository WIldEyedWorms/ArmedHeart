using UnityEngine;
using System.Collections;

public class GyroScopeComponent : MonoBehaviour {

	#if UNITY_EDITOR
	Vector2 mPrevMousePos;
	Vector3 mEulerAngles;
	#endif
	// Update is called once per frame
	void Update () {
		
		#if UNITY_EDITOR
		Vector2 tCurrentMousePos = Input.mousePosition;
		if( Input.GetMouseButton(0) )
		{
			Vector2 tDeltaMousePos = tCurrentMousePos - mPrevMousePos;
			
			tDeltaMousePos.Normalize();
			
			tDeltaMousePos *= 0.5f;
			Quaternion tCurrentRotation = transform.localRotation;
			mEulerAngles = transform.eulerAngles;
			mEulerAngles.y += tDeltaMousePos.x;
			if( mEulerAngles.y > 360.0f )
			{
				mEulerAngles.y -=360.0f;
			}
			else if( mEulerAngles.y < 0.0f )
			{
				mEulerAngles.y += 360.0f;
			}

			mEulerAngles.x -= tDeltaMousePos.y;
			if( mEulerAngles.x > 360.0f )
			{
				mEulerAngles.x -= 360.0f;
			}
			else if( mEulerAngles.x < 0.0f )
			{
				mEulerAngles.x += 360.0f;
			}

			transform.eulerAngles = mEulerAngles;
		}
		mPrevMousePos = tCurrentMousePos;
		#else
		Quaternion tRotRH = Input.gyro.attitude;
		Quaternion tRot = new Quaternion(-tRotRH.x, -tRotRH.z, -tRotRH.y, tRotRH.w) * Quaternion.Euler(90f, 0f, 0f);
		
		transform.localRotation = tRot;
		
		#endif
	}
}

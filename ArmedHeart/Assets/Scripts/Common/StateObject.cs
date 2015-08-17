using UnityEngine;
using System.Collections;

public class StateObject<T> : MonoBehaviour
{
	T mCurrentState;
	public T currentState
	{
		get{ return mCurrentState; }
	}

	public void SwitchState( T tNewSate )
	{
		OnLeaveState (tNewSate);
		mCurrentState = tNewSate;
		OnEnterState (tNewSate);
	}

	protected virtual void OnLeaveState( T tNewSate )
	{
	}

	protected virtual void OnEnterState( T tOldSate )
	{
	}
}

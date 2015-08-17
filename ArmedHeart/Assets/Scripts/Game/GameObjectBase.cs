using UnityEngine;
using System.Collections;

public class GameObjectBase<T> : StateObject<T> 
{
	void Awake()
	{
		GameManager.Instance.onEnterStateDelegate += OnGameEnterState;
	}


	void OnDestroy()
	{
		if( GameManager.Instance == null )
		{
			return;
		}
		GameManager.Instance.onEnterStateDelegate -= OnGameEnterState;
	}

	protected virtual void OnGameEnterState( eGameState tNewState )
	{
	}
}

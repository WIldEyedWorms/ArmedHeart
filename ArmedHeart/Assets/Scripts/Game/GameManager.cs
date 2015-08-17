using UnityEngine;
using System.Collections;

public enum eGameState
{
	Wait,
	LoadResource,
	Prepare,

}

public class GameManager : StateObject<eGameState> {

	public System.Action<eGameState> onEnterStateDelegate;

	private static GameManager mInstance;
	public static GameManager Instance
	{
		get{
			if (mInstance == null) 
			{
				GameObject tObj = GameObject.Find( "GameManager" );
				if( tObj == null ) 
				{
					return null;
				}

				mInstance = tObj.GetComponent<GameManager>();
			}

			return mInstance;
		}
	}

	void Awake()
	{
		mInstance = this;
	}

	IEnumerator Start()
	{
		yield return null;
		SwitchState (eGameState.LoadResource);
	}

	protected override void OnEnterState (eGameState tNewState )
	{
		if( onEnterStateDelegate != null )
		{
			onEnterStateDelegate( tNewState );
		}

		switch( tNewState )
		{
		case eGameState.LoadResource:
			StartCoroutine ( IE_LoadResource() );
			break;
		}
	}

	IEnumerator IE_LoadResource()
	{
		yield return StartCoroutine( GameSystemManager.Instance.resourceManager.IE_LoadBattleResource() );
		SwitchState (eGameState.Prepare);
	}
}

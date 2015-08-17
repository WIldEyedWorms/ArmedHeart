using UnityEngine;
using System.Collections;

public enum eBulletState
{
	Prepare,
	Close,
	Open
}

public class BulletUI : GameObjectBase<eBulletState>
{
	public GameObject magazinePrefab;
	public FadeInOutComponent fadeInOutController;
	protected override void OnGameEnterState( eGameState tNewState )
	{
		switch( tNewState )
		{
		case eGameState.Prepare:
			Prepare();
			break;
		}
	}

	void Prepare()
	{
		foreach( GunInfo gunInfo in GameSystemManager.Instance.gameInfo.battleInData.gunInfos )
		{
			//マガジン生成
			GameObject tObj = CommonUtility.CreateInstance( magazinePrefab, gameObject );
			MagazineUI tUi = tObj.GetComponent<MagazineUI>();
			tUi.Initialize( gunInfo.bulletInfo.bulletId );
		}
	}

	IEnumerator IE_Test()
	{
		yield return new WaitForSeconds( 5.0f );
		SwitchState (eBulletState.Open);
	}

	protected override void OnEnterState( eBulletState tNewState )
	{
		switch( tNewState )
		{
		case eBulletState.Open:
			fadeInOutController.FadeIn();
			break;

		case eBulletState.Close:
			break;
		}
	}

	public void Open()
	{
		SwitchState (eBulletState.Open);
	}

	public void Close()
	{
		SwitchState (eBulletState.Close);
	}
}

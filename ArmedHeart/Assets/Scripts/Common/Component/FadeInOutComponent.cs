using UnityEngine;
using System.Collections;

public class FadeInOutComponent : MonoBehaviour 
{
	public UITweener[] fadeInTweener;
	public UITweener[] fadeOutTweener;

	public void FadeIn()
	{
		foreach( UITweener tween in fadeInTweener )
		{
			CommonUtility.PlayTween( tween );
		}
	}

	public void FadeOut()
	{
	}
}

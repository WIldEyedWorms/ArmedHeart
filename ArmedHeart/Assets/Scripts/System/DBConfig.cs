using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class TestDBData : DBDataBase
{
	public int test1;
	public string test2;
	public int test3;
	public string test4;
	public bool test;
	public float a;
}

[System.Serializable]
public class TestDB : DBBase<TestDBData>{}

[System.Serializable]
public class BulletDBData : DBDataBase
{
	public string name;
	public string explanation;
	public int capacity;
	public float power;
	public float reloadSpeed;
	public string assetKey;
}

[System.Serializable]
public class BulletDB : DBBase<BulletDBData>{}

[System.Serializable]
public class AssetDBData : DBDataBase
{
	public string key;
	public string path;
	public int    version;
	public int    type;
	public int    threshold;
}

[System.Serializable]
public class AssetDB : DBBase<AssetDBData>
{
	public AssetDBData GetAsset( string tKey )
	{
		foreach( AssetDBData dbData in list )
		{
			if( dbData.key == tKey )
			{
				return dbData;
			}
		}

		return null;
	}
}
using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;

[System.Serializable]
public class DBDataBase
{
	public int id;
}

[System.Serializable]
public class DBBase<T> where T : DBDataBase ,new()
{
	public T GetData( int tId )
	{
		if( !dic.ContainsKey(tId ) )
		{
			return null;
		}
		return dic [tId]; 
	}

	public List<T> list = new List<T>();
	public Dictionary<int,T> dic = new Dictionary<int, T>();
	const string DBAssetPath = "DB/";
	public void Load( string tFileName )
	{
		TextAsset tText = Resources.Load (DBAssetPath + tFileName) as TextAsset;
		Debug.Log (tText.text);

		CSVParser tParser = new CSVParser ();
		tParser.Convert (tText.text);

		FieldInfo[] tFieldInfos = typeof(T).GetFields ();

		Dictionary<string,FieldInfo> tFieldInfoDic = new Dictionary<string, FieldInfo> ();

		foreach( FieldInfo tInfo in tFieldInfos )
		{
			tFieldInfoDic.Add( tInfo.Name,tInfo);
		}

		for( int i = 0; i < tParser.colums.Count; ++i )
		{
			T t = new T();
			string[] tDatas = tParser.colums[i];
			for( int j = 0;j < tParser.columNames.Length; ++j )
			{
				if( !tFieldInfoDic.ContainsKey( tParser.columNames[j] ))
				{
					continue;
				}
				FieldInfo tInfo = tFieldInfoDic[tParser.columNames[j]];
				Debug.Log ( tInfo.FieldType.Name );
				switch( tInfo.FieldType.Name )
				{
				case "Int32":
					int tIntData;
					if( int.TryParse( tDatas[j], out tIntData ))
					{
						tInfo.SetValue( t, tIntData );
					}
					break;

				case "String":
					tInfo.SetValue( t, tDatas[j] );
					break;

				case "Single":
					float tFloatData;
					if( float.TryParse( tDatas[j], out tFloatData ))
					{
						tInfo.SetValue( t, tFloatData );
					}
					break;

				case "Bool"://使用経験無し
					tInfo.SetValue( t, tDatas[j] == "true" );
					break;
				}
			}

			list.Add( t );
			Debug.Log ( t.id );
			dic.Add( t.id, t );
		}
	}	
}

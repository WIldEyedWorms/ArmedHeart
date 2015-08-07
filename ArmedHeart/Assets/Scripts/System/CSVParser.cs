using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CSVParser 
{

	public CSVParser()
	{
	}

	public string[] columNames;
	public List<string[]> colums = new List<string[]>();

	public void Convert( string tText )
	{
		char[] tSeparator = { '\r','\n' };
		string[] tLines = tText.Split( tSeparator, System.StringSplitOptions.RemoveEmptyEntries);

		if( tLines.Length <= 1 )
		{
			return;
		}

		char[] tColumSeparator = { ',' };
		columNames = tLines[0].Split(tColumSeparator, System.StringSplitOptions.None);


		for( int i = 1; i < tLines.Length; ++i )
		{
			colums.Add( tLines[i].Split(tColumSeparator, System.StringSplitOptions.None) );
		}


	}
}

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
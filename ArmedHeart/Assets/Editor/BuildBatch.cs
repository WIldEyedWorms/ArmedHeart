using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;

public class BuildBatch {
	private static void BuildAndroid()
	{
		EditorUserBuildSettings.SwitchActiveBuildTarget( BuildTarget.Android );
		string[] allScene = GetScenes ();
		PlayerSettings.bundleIdentifier = "jp.wildeyedworms.armedheart";
		PlayerSettings.statusBarHidden = true;
		BuildPipeline.BuildPlayer( allScene,
		                          "hoge.apk",
		                          BuildTarget.Android,
		                          BuildOptions.None
		                          );
	}
	
	private static string[] GetScenes() {
		ArrayList levels = new ArrayList();
		foreach (EditorBuildSettingsScene scene in EditorBuildSettings.scenes) {
			if (scene.enabled) {
				levels.Add(scene.path);
			}
		}
		return (string[]) levels.ToArray(typeof(string));
	}
}

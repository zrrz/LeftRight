using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[ShowOdinSerializedPropertiesInInspector]
public class StoryDatabase : SerializedScriptableObject{

	[System.NonSerialized, OdinSerialize]
	public Dictionary<int, StoryOption> storyOptions = new Dictionary<int, StoryOption>();

	#if UNITY_EDITOR
	[MenuItem("Story Editor/Open Atlas")]
	public static void GetAtlas()
	{
		string path = "Assets/Story Data/StoryDatabase.asset";
		StoryDatabase storyDatabase = AssetDatabase.LoadAssetAtPath<StoryDatabase>(path);
		if(storyDatabase == null) {
			storyDatabase = ScriptableObject.CreateInstance<StoryDatabase>();
			AssetDatabase.CreateAsset(storyDatabase, path);
			AssetDatabase.SaveAssets();
		}

		EditorUtility.FocusProjectWindow();
		Selection.activeObject = storyDatabase;
	}
	#endif
}

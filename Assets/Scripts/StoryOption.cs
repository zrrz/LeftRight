using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Sirenix.OdinInspector;
using Sirenix.Serialization;

[System.Serializable]
public class StoryOption {

	public string action = "EMPTY_ACTION";
	public string dialogue = "EMPTY_DIALOGUE";

	public Sprite sprite;

	public AudioClip audioCue;

	public AudioClip bgmAudio;

	//Variable questions based on past user input

	public StoryOption leftOption { get { return StoryManager.instance.storyDatabase.storyOptions[options[0]]; } }
	public StoryOption rightOption { get { return StoryManager.instance.storyDatabase.storyOptions[options[1]]; } }

	public int[] options;
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryManager : MonoBehaviour {

	public static StoryManager instance;

	public StoryOption currentStoryOption { get { return StoryManager.instance.storyDatabase.storyOptions[currentStoryOptionIndex]; } }
	[System.NonSerialized]
	public int currentStoryOptionIndex;

//	[SerializeField]
	public StoryDatabase storyDatabase;

	[System.NonSerialized]
	public UnityEvent storyAdvancedEvent = new UnityEvent();

	void Awake() {
		if(instance != null) {
			Debug.LogError("Instance of StoryManager already exists in scene! Disabling!", this);
			this.enabled = false;
			return;
		}
		instance = this;
	}

	void Start () {
		AdvanceStory(0);
	}
	
	void Update () {
		
	}

	public void LeftOption() {
		ChooseOption(0);
	}

	public void RightOption() {
		ChooseOption(1);
	}

	//Doing it this way for the ability to expand to more than 2 options in the future
	public void ChooseOption(int index) {
		StoryManager.instance.AdvanceStory(currentStoryOption.options[index]);
	}

	public void AdvanceStory(int storyOptionIndex) {
		currentStoryOptionIndex = storyOptionIndex;

		storyAdvancedEvent.Invoke();
	}
}

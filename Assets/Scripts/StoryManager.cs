using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StoryManager : MonoBehaviour {

	public static StoryManager instance;

	StoryOption currentStoryOption;

	UnityEvent storyAdvancedEvent;

	void Awake() {
		if(instance != null) {
			Debug.LogError("Instance of StoryManager already exists in scene! Disabling!", this);
			this.enabled = false;
			return;
		}
		instance = this;
	}

	void Start () {
		
	}
	
	void Update () {
		
	}

	public void AdvanceStory(StoryOption storyOption) {
		currentStoryOption = storyOption;


		storyAdvancedEvent.Invoke();
	}
}

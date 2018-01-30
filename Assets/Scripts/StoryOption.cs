using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoryOption : MonoBehaviour {

	public string dialogue = "EMPTY_DIALOGUE";
	public StoryOption[] options;

	void Start () {
		
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
		StoryManager.instance.AdvanceStory(options[index]);
	}
}

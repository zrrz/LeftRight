using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour {

	Text cardDialogueText;
	Image cardImage;
	Text leftOptionText;
	Text rightOptionText;

	void Start () {
		StoryManager.instance.storyAdvancedEvent.AddListener(UpdateCardUI);

		Transform canvas = GameObject.Find("Canvas").transform;
		cardDialogueText = canvas.Find("Card/DialogueText").GetComponent<Text>();
		cardImage = canvas.Find("Card/CardImage").GetComponent<Image>();
		leftOptionText = canvas.Find("Card/LeftOptionText").GetComponent<Text>();
		rightOptionText = canvas.Find("Card/RightOptionText").GetComponent<Text>();
	}

	void UpdateCardUI() {
		StoryOption storyOption = StoryManager.instance.currentStoryOption;

		cardDialogueText.text = storyOption.dialogue;
		cardImage.sprite = storyOption.sprite;
		leftOptionText.text = storyOption.leftOption.action;
		rightOptionText.text = storyOption.rightOption.action;
	}
}

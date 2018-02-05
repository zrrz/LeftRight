using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class CardDrag : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler {

	Vector3 startPosition;

	void Start () {
		startPosition = transform.localPosition;
	}
	
//	void Update () {
//		
//	}

	public void OnBeginDrag(PointerEventData data) {
		//Have to implement cuz OnEndDrag not getting called bug
	}

	public void OnDrag(PointerEventData data) {
		//TODO fuckin' card moves slightly more than pointer
		float xValue = (data.position.x - data.pressPosition.x)/Screen.width;
//		Debug.LogError(xValue);
		transform.localPosition = (Vector2)startPosition + (data.position - data.pressPosition);
		transform.localEulerAngles = new Vector3(0f, 0f, 30f * xValue);
	}

	public void OnEndDrag(PointerEventData data) {
		float xValue = data.position.x/Screen.width;
		if(xValue < 0.15f) {
			Debug.LogError("Left");
//			transform.localPosition = startPosition;
//			transform.localRotation = Quaternion.identity;
			StartCoroutine(FadeOut());
		} else if(xValue > .85f) {
			Debug.LogError("Right");
//			transform.localPosition = startPosition;
//			transform.localRotation = Quaternion.identity;
			StartCoroutine(FadeOut());
		} else {
			transform.localPosition = startPosition;
			transform.localRotation = Quaternion.identity;
		}
	}

	IEnumerator FadeOut() {
		float fadeTime = 0.2f;
		for(float t = 0f; t < 1f; t += Time.deltaTime/fadeTime) {
			foreach(Image image in GetComponentsInChildren<Image>()) {
				Color startColor = image.color;
				Color endColor = new Color(startColor.r, startColor.g, startColor.b, 0f);

				GetComponent<Image>().color = Color.Lerp(startColor, endColor, t);
				
				image.color = endColor;
				yield return null;
			}
		}
	}
}

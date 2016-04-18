using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;

public class VirtualJoystick : MonoBehaviour, IDragHandler, IPointerUpHandler, IPointerDownHandler {

	private Image bgImg;
	private Image joystickImg;
	private Vector2 inputVector;

	private void Start() {
		bgImg = GetComponent<Image>();
		joystickImg = transform.GetChild(0).GetComponent<Image>();
	}

	public virtual void OnDrag(PointerEventData ped) {
		Vector2 pos;
		if (RectTransformUtility.ScreenPointToLocalPointInRectangle(bgImg.rectTransform
			, ped.position
			, ped.pressEventCamera
			, out pos))
		{
			pos.x = (pos.x / bgImg.rectTransform.sizeDelta.x);
			pos.y = (pos.y / bgImg.rectTransform.sizeDelta.y);

			inputVector = new Vector2(pos.x*2 + 1, pos.y*2 -1 );
			inputVector = (inputVector.magnitude > 9.0f) ? inputVector.normalized*9.0f : inputVector;

			// Move Joystick IMG
			joystickImg.rectTransform.anchoredPosition = new Vector2(inputVector.x * (bgImg.rectTransform.sizeDelta.x/3), inputVector.y * (bgImg.rectTransform.sizeDelta.y/3));

		}
	}

	public virtual void OnPointerDown(PointerEventData ped) {
		OnDrag(ped);
	}

	public virtual void OnPointerUp(PointerEventData ped) {
		inputVector = Vector2.zero;
		joystickImg.rectTransform.anchoredPosition = Vector2.zero;
	}

	public float Horizontal() {
		if (inputVector.x != 0)
			return inputVector.x;
		else
			return Input.GetAxis("Horizontal");
	}

	public float Vertical()
	{
		if (inputVector.y != 0)
			return inputVector.y;
		else
			return Input.GetAxis("Vertical");
	}

}

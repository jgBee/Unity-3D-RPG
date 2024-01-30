using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class UIChatWindow : MonoBehaviour
{
	[Header("Inspector Check")]
	[SerializeField]private TextMeshProUGUI name;
	[SerializeField]private TextMeshProUGUI job;
	[SerializeField]private TextMeshProUGUI text;

	private List<string> targetText;

	[SerializeField] private int currListCount;

	[SerializeField] private RawImage image;


	private enum STATE
	{
		In,
		StartCoroutine,
		Update,
		Out,
	};
	STATE state = STATE.In;

	Coroutine charReadCoroutine;


	public void Init(ref List<string> _chatList,string _name, string _job, Texture _charImamge)
	{
		if (_chatList == null) return;
		targetText = _chatList;

		name.text = _name;
		job.text = _job;
		text.text = "";

		image.texture = _charImamge;
		state = STATE.StartCoroutine;

		currListCount = 0;
	}

	private void Update()
	{
		switch (state)
		{
			case STATE.In:
			
				break;
			case STATE.StartCoroutine:
				charReadCoroutine = StartCoroutine(ChatDelay());

				state = STATE.Update;
				break;
			case STATE.Update:

				break;
			case STATE.Out:
				UIManager.Instance.UIChatWindow(false);
				break;
		}
	}

	public void NextButton()
	{
		StopCoroutine(charReadCoroutine);
		currListCount += 1;
	
		if (currListCount >= targetText.Count)
		{
			state = STATE.Out;
			return;
		}
		text.text = "";
		state = STATE.StartCoroutine;
	}

	public void SkipButton()
	{
		StopCoroutine(charReadCoroutine);
		text.text = targetText[currListCount];
	}

	IEnumerator ChatDelay()
	{
		for (int i = 0; i < targetText[currListCount].Length; i++)
		{
			text.text += targetText[currListCount][i];
			yield return new WaitForSeconds(0.05f);
		}

		//state = STATE.In;
	}
}
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;
using System.Collections;
using System.Collections.Generic;

public class ChatWindow : MonoBehaviour
{
	[SerializeField]private TextMeshProUGUI name;
	[SerializeField]private TextMeshProUGUI job;
	[SerializeField]private TextMeshProUGUI text;

	private List<string> targetText;


	[SerializeField] private int currListCount,currTextCount, maxTextCount;

	[SerializeField] private RawImage image;

	private UnityAction EndAction;

	private bool bSkil = false;


	private enum STATE
	{
		In,
		StartCoroutine,
		Update,
		Out,
	};
	STATE state = STATE.In;

	Coroutine charReadCoroutine;

	public void Init(ref List<string> _chatList,string _name, string _job, Texture _charImamge, UnityAction _action)
	{
		if (_chatList == null) return;
		targetText = _chatList;
		//textList = _chatList;

		name.text = _name;
		job.text = _job;
		text.text = "";

		image.texture = _charImamge;
		EndAction = _action;
		state = STATE.StartCoroutine;

		currListCount = 0;
		currTextCount = 0;
		maxTextCount = _chatList[0].Length;

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
				if( EndAction != null) EndAction();
				UIManager.Instance.ChatWindow(false);
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

		bSkil = true;
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
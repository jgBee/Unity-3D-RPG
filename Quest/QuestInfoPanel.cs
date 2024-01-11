using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using TMPro;

public class QuestInfoPanel : MonoBehaviour
{
	[SerializeField] TextMeshProUGUI title;
	[SerializeField] TextMeshProUGUI detail;
	[SerializeField] TextMeshProUGUI okBtn;

	private UnityAction OKAction;
	private UnityAction CancelAction;
	private UnityAction CloseAction;

	[SerializeField] private Sprite[] buttonSpr;
	[SerializeField] private Image okBtnImage;

	[SerializeField] private Image[] rewardImage;
	[SerializeField] private TextMeshProUGUI[] rewardText;

	[SerializeField] private GameObject OKbtn;
	[SerializeField] private GameObject CancelBtn;
	[SerializeField] private GameObject CloseBtn;

	private void Awake()
	{
		title.text = "";
		detail.text = "";
	}

	public void Active(bool _active)
	{
		gameObject.SetActive(_active);
	}

	public void Init(int _questNumber, bool _complete, UnityAction _okEvent, UnityAction _cancelEvent, UnityAction _closeEvent)
	{
		OKAction = _okEvent;
		CancelAction = _cancelEvent;
		CloseAction = _closeEvent;

		Active(true);


		title.text = QuestManager.Instance.GetQuestTitle(_questNumber);

		if (_complete)
		{
			okBtn.text = "Complete";
			okBtnImage.sprite = buttonSpr[1];
			detail.text = QuestManager.Instance.GetQuestClearText(_questNumber);
		}
		else
		{
			okBtn.text = "Ok";
			okBtnImage.sprite = buttonSpr[0];
			detail.text = QuestManager.Instance.GetQuestDetail(_questNumber);
		}

		RefeshRewardIconAndText(_questNumber);

		OKbtn.gameObject.SetActive(true);
		CancelBtn.gameObject.SetActive(true);
		CloseBtn.gameObject.SetActive(true);
	}

	public void InitOkButtonOnly(int _questNumber, bool _complete, UnityAction _okEvent)
	{
		OKAction = _okEvent;
		CancelAction = null;
		CloseAction = null;

		Active(true);


		title.text = QuestManager.Instance.GetQuestTitle(_questNumber);

		if (_complete)
		{
			okBtn.text = "Complete";
			okBtnImage.sprite = buttonSpr[1];
			detail.text = QuestManager.Instance.GetQuestClearText(_questNumber);
		}
		else
		{
			okBtn.text = "Ok";
			okBtnImage.sprite = buttonSpr[0];
			detail.text = QuestManager.Instance.GetQuestDetail(_questNumber);
		}

		RefeshRewardIconAndText(_questNumber);

		OKbtn.gameObject.SetActive(true);
		CancelBtn.gameObject.SetActive(false);
		CloseBtn.gameObject.SetActive(false);
	}

	public void Close()
	{
		if (CloseAction != null) CloseAction();

		Active(false);
	}

	public void OK()
	{
		if (OKAction != null)
		{
			OKAction();
			Active(false);
		}
	}

	public void Cancel()
	{
		if (CancelAction != null) CancelAction();
		Active(false);
	}

	private void RefeshRewardIconAndText(int _questNumber)
	{
		foreach (Image item in rewardImage)
		{
			item.gameObject.SetActive(false);
		}

		//QuestManager.Instance.SetRewardImage(ref Image[] _rewardImange, ref TextMeshProUGUI _rewardText);
		QuestManager.Instance.SetRewardImage(_questNumber, ref rewardImage, ref rewardText);

	}
}
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIFieldTopButton : MonoBehaviour
{
	[SerializeField] private Image notify;
	[SerializeField] private TextMeshProUGUI text;

	int notifyCount = 0;
	private void Start()
	{
		notify.gameObject.SetActive(false);
		notifyCount = 0;
	}
	public void OnNotify()
	{
		if (notify.gameObject.activeSelf == false) notify.gameObject.SetActive(true);
		notifyCount++;
		text.text = notifyCount.ToString();
	}

	public void ResetNotify()
	{
		notifyCount = 0;
		notify.gameObject.SetActive(false);
		text.text = notifyCount.ToString();
	}

	public void OnBtnOpenQuestBoard()
	{
		ResetNotify();
		UIManager.Instance.QuestBoard(true);
	}

	public void OnBtnOpenInventory()
	{
		ResetNotify();
		UIManager.Instance.Inventory(true);
	}
}
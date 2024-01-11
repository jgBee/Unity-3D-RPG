using UnityEngine;
using TMPro;

public class QuestListItem : MonoBehaviour
{
	public int questNumber;
	[SerializeField] private TextMeshProUGUI mainText;

	QuestManager questManager;

	private TextMeshProUGUI stateText;
	private TextMeshProUGUI titleText;
	private TextMeshProUGUI detailText;
	private TextMeshProUGUI countText;
	public void Init(int _number, ref TextMeshProUGUI _state, ref TextMeshProUGUI _title, ref TextMeshProUGUI _detail, ref TextMeshProUGUI _countText)
	{
		questNumber = _number;
		stateText = _state;
		titleText = _title;
		detailText = _detail;
		countText = _countText;
		
		mainText.text = QuestManager.Instance.GetQuestTitle(questNumber);

		countText.text =detailText.text= titleText.text = stateText.text = "";
		questManager = QuestManager.Instance;
	}

	public void DetailText()
	{
		if( stateText != null&& titleText != null && detailText != null && countText != null)
		{
			stateText.text = questManager.GetQuestState(questNumber);
			titleText.text = questManager.GetQuestTitle(questNumber);
			detailText.text =questManager.GetQuestDetail(questNumber);
			countText.text = questManager.GetQuestValue(questNumber);
		}
	}

}
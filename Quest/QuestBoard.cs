using TMPro;
using UnityEngine;

public class QuestBoard : MonoBehaviour
{
	public GameObject prefabObject;
	[SerializeField] private GameObject questListPanel;

	[SerializeField] private TextMeshProUGUI questState;	
	[SerializeField] private TextMeshProUGUI titleText;
	[SerializeField] private TextMeshProUGUI detailText;
	[SerializeField] private TextMeshProUGUI countText;

	private void OnEnable()
	{
		countText.text = detailText.text = titleText.text = questState.text = "";
	}
	public void CreateQuest(int _questNumber)
	{
		GameObject obj = Instantiate(prefabObject);
		obj.transform.parent = questListPanel.transform;
		obj.transform.localScale = new Vector3(1, 1, 1);
		obj.GetComponent<QuestListItem>().Init(_questNumber, ref questState, ref titleText,ref detailText, ref countText);
	}
}
using UnityEngine;

using static ItemEnum;
using static nsItemFood.ItemFood;

[System.Serializable]
public class ItemQuest
{
	[SerializeField] private QUESTITEMINDEX index;
	private int star;

	private Sprite itemSprite;

	private float mainValue;
	private float subValue;

	private int currCount;
	private int maxCount;

	private string mainName;
	private string mainExplan;
	private string subExplan;

	// Get
	public QUESTITEMINDEX Index { get { return index; } }

	public Sprite ItemSprite { get { return itemSprite; } }
	public int Star => star;
	public float MainValue => mainValue;
	public float SubValue => subValue;

	public string MainName => mainName;
	public string MainExplan => mainExplan;
	public string SubExplan => subExplan;

	public int CurrCount { get { return currCount; } set { currCount = value; } }

	public bool Notify { get; set; }

	public bool InItem(int addCount)
	{
		return currCount + addCount <= maxCount ? true : false;
	}


	public void Init(QUESTITEMINDEX _index, int _star, string _mainName, string _mainExplan, string _subExplan, int _maxCount)
	{
		itemSprite = ItemImage.Instance.GetQuest(_index);
		index = _index;

		star = _star;

		Notify = true;

		mainName = _mainName;
		mainExplan = _mainExplan;
		subExplan = _subExplan;


		currCount = 1;
		maxCount = _maxCount;
	}
}
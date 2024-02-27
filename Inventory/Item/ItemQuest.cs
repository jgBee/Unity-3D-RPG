using UnityEngine;

using static ItemEnum;
using static nsItemFood.ItemFood;

[System.Serializable]
public class ItemQuest
{
	[SerializeField] private QUESTeItemIndex index;
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
	public QUESTeItemIndex Index { get { return index; } }

	public Sprite ItemSprite { get { return itemSprite; } }
	public int Star => star;
	public float MainValue => mainValue;
	public float SubValue => subValue;

	public string MainName => mainName;
	public string MainExplan => mainExplan;
	public string SubExplan => subExplan;


	public bool Notify { get; set; }

	public bool InItemCount(int _value)
	{
		if (currCount + _value < 0)
		{
			return false;
		}
		else if (currCount + _value > maxCount)
		{
			return false;
		}

		currCount += _value;
		return true;
	}


	public void Init(QUESTeItemIndex _index, int _star, string _mainName, string _mainExplan, string _subExplan, int _maxCount)
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
using UnityEngine;

using static ItemEnum;

[System.Serializable]
public class ItemSpecial
{
	[SerializeField] private SPECIALITEMINDEX index;
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
	public SPECIALITEMINDEX Index { get { return index; } }

	public Sprite ItemSprite { get { return itemSprite; } }
	public int Star => star;
	public float MainValue => mainValue;
	public float SubValue => subValue;

	public string MainName => mainName;
	public string MainExplan => mainExplan;
	public string SubExplan => subExplan;

	public bool Notify { get; set; }
	
	public bool InItem(int addCount)
	{
		return currCount + addCount <= maxCount ? true : false;
	}

	public void Init(SPECIALITEMINDEX _index, int _star, string _mainName, string _mainExplan, string _subExplan, int _maxCount)
	{
		itemSprite = ItemImage.Instance.GetSpecial(_index);
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
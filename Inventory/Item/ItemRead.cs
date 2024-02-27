using UnityEngine;

using static ItemEnum;

[System.Serializable]
public class ItemRead
{
	[SerializeField] private READeItemIndex index;
	private int star;

	private Sprite itemSprite;

	private float mainValue;
	private float subValue;

	private int currCount = 0;
	//private int maxCount;

	private string mainName;
	private string mainExplan;
	private string subExplan;


	// Get
	public READeItemIndex Index { get { return index; } }

	public Sprite ItemSprite { get { return itemSprite; } }
	public int Star => star;
	public float MainValue => mainValue;
	public float SubValue => subValue;

	public string MainName => mainName;
	public string MainExplan => mainExplan;
	public string SubExplan => subExplan;


	public bool Notify { get; set; }

	// 읽을 거리 아이템은 단 1개 Init에서 하는 것으로 설정
	//public bool InItemCount(int _value)
	//{
	//	if (currCount != 0) return false;

	//	currCount = 1;
	//	return true;
	//}


	public void Init(READeItemIndex _index, int _star, string _mainName, string _mainExplan, string _subExplan, int _maxCount)
	{
		itemSprite = ItemImage.Instance.GetRead(_index);
		index = _index;

		star = _star;

		Notify = true;

		mainName = _mainName;
		mainExplan = _mainExplan;
		subExplan = _subExplan;

		currCount = 1;
		//maxCount = _maxCount;
	}
}
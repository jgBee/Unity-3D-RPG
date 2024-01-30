using UnityEngine;

using static ItemEnum;

[System.Serializable]
public class ItemRead
{
	[SerializeField] private READITEMINDEX index;
	private int star;

	private Sprite itemSprite;

	private int level;
	private int maxLevel;

	private int mainValue;
	private int subValue;

	private int currBreakThrough;
	private int maxBreakThrough;

	private int exp;
	private int expMax;

	private string mainName;
	private string mainExplan;
	private string subExplan;

	private int subOptionValue;

	private bool bFavorit;
	private bool bNew;
	private bool bLock;


	// Get

	public Sprite ItemSprite { get { return itemSprite; } }
	public int Star => star;
	public int Level => level;
	public int MaxLevel => maxLevel;

	public int MainValue => mainValue;

	public int CurrBreakThrough => currBreakThrough;
	public int MaxBreakThrough => maxBreakThrough;

	public int Exp => exp;
	public int ExpMax => expMax;
	public float ExpPer => (float)exp / (float)expMax;

	public string MainName => mainName;
	public string MainExplan => mainExplan;
	public string SubExplan => subExplan;

	public bool Favorit { get; set; }
	public bool Lock { get; set; }
	public bool New { get; set; }



	public void Init(READITEMINDEX _index, int _star, string _mainName, string _mainExplan, string _subExplan, int _mainValue, string _subOptionType, int _subOptionValue, int _maxBreakThrough)
	{
		itemSprite = ItemImage.Instance.GetRead(_index);
		index = _index;

		bFavorit = false;
		bNew = false;
		bLock = false;
		level = 1;
		maxLevel = 10;

		star = _star;

		mainValue = _mainValue;

		mainName = _mainName;
		mainExplan = _mainExplan;
		subExplan = _subExplan;

		currBreakThrough = 1;
		maxBreakThrough = _maxBreakThrough;
	}
}
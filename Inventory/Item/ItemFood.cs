using UnityEngine;
using static ItemEnum;

namespace nsItemFood
{
	[System.Serializable]
	public class ItemFood
	{
		[SerializeField] private FOODITEMINDEX index;

		public enum eFoodItemType { None, Heal, AttackValue, ShieldValue, LiftRun, Respawn,};
		private eFoodItemType type;

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
		public FOODITEMINDEX Index { get { return index; } }
		public eFoodItemType Type { get { return type; } }

		public Sprite ItemSprite { get { return itemSprite; } }
		public int Star => star;
		public float MainValue => mainValue;
		public float SubValue => subValue;

		public string MainName => mainName;
		public string MainExplan => mainExplan;
		public string SubExplan => subExplan;

		public int CurrCount { get { return currCount; } set {currCount = value; } }

		public bool Favorit { get; set; }
		public bool Notifiy { get; set; }

		public bool InItem(int addCount)
		{
			return currCount + addCount <= maxCount ? true : false;
		}

		public void Init(FOODITEMINDEX _index, int _star, string _mainName, string _mainExplan, string _subExplan, int _mainValue, int _subValue, string _type, int _maxCount)
		{
			itemSprite = ItemImage.Instance.GetFood(_index);
			index = _index;
			
			star = _star;

			Favorit = false;
			Notifiy = true;


			mainName = _mainName;
			mainExplan = _mainExplan;
			subExplan = _subExplan;

			mainValue = _mainValue;
			subValue = _subValue;

			currCount = 1;
			maxCount = _maxCount;

			switch (_type)
			{
				case "Head":	type = eFoodItemType.Heal; break;
				case "Respawn":	type = eFoodItemType.Respawn; break;
				case "AttackValue":	type = eFoodItemType.AttackValue; break;
				case "ShieldValue":	type = eFoodItemType.ShieldValue; break;
				case "LiftRun": type = eFoodItemType.LiftRun; break;
				case "Base":	type = eFoodItemType.None; break;
			}
		}

		public static FOODITEMINDEX GetItemIndex(int _value)
		{
			switch (_value)
			{
				case 0: return FOODITEMINDEX.Star1_BaseMeat;
				case 1: return FOODITEMINDEX.Star1_BaseWater;
				default:
					return FOODITEMINDEX.Star1_BaseMeat;
			}
		}

		public static FOODITEMINDEX GetItemRandomIndex()
		{
			int min = 0;
			int max = 2;
			int randValue = UnityEngine.Random.Range(min, max);
			switch (randValue)
			{
				case 0: return FOODITEMINDEX.Star1_BaseMeat;
				case 1: return FOODITEMINDEX.Star1_BaseWater;
				default:
					return FOODITEMINDEX.Star1_BaseMeat;
			}
		}
	}
}

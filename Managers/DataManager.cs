using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using nsItemFood;

using static PlayerEnum;

// 1. 플레이어 데이터
#region PlayerData
[System.Serializable]
public class PlayerData
{
	public PlayerEnum.ePlayerCharIndex Index { get; private set; }

	public Vector3 Pos { get; set; }
	public Vector3 Dir { get; set; }

	public PlayerData()
	{
		Pos = Vector3.zero;
		Dir = Vector3.zero;

		Index = ePlayerCharIndex.Char_5_0_1_MainGirl;
	}
	public void Init()
	{
		Pos = Vector3.zero;
		Dir = Vector3.zero;

		Index = ePlayerCharIndex.Char_5_0_1_MainGirl;
	}
}
#endregion

#region ItemData
[System.Serializable]
public class ItemData
{
	[Header("Inspector Serialize")]
	[SerializeField] private int itemWeaponMax;
	[SerializeField] private int itemFoodMax;
	[SerializeField] private int itemEquipMax;
	[SerializeField] private int itemQuestMax;
	[SerializeField] private int itemGoodsMax;
	[SerializeField] private int itemReadMax;
	[SerializeField] private int itemSpecialMax;


	[Header("Check SerailizeField")]
	[SerializeField] private List<ItemWeapon> itemWeaponList;
	[SerializeField] private List<ItemEquipment> itemEquipList;
	[SerializeField] private List<ItemFood> itemFoodList;
	[SerializeField] private List<ItemQuest> itemQuestList;
	[SerializeField] private List<ItemGoods> itemGoodsList;
	[SerializeField] private List<ItemRead> itemReadList;
	[SerializeField] private List<ItemSpecial> itemSpecialList;
	// GetList
	public List<ItemWeapon> ItemWeaponList { get { return itemWeaponList; } }
	public List<ItemEquipment> ItemEquipList { get { return itemEquipList; } }
	public List<ItemFood> ItemFoodList { get { return itemFoodList; }  }
	public List<ItemQuest> ItemQuestList { get { return itemQuestList; }  }
	public List<ItemGoods> ItemGoodsList { get { return itemGoodsList; } }
	public List<ItemRead> ItemReadList { get { return itemReadList; } }
	public List<ItemSpecial> ItemSpecialList { get { return itemSpecialList; } }

	public ItemData()
	{
		itemWeaponMax = 20;
		itemFoodMax = 20;
		itemEquipMax = 20;
		itemQuestMax = 20;
		itemGoodsMax = 20;
		itemReadMax = 20;
		itemSpecialMax = 20;
		itemWeaponList = new List<ItemWeapon>();
		itemEquipList = new List<ItemEquipment>();
		itemFoodList = new List<ItemFood>();
		itemQuestList = new List<ItemQuest>();
		itemGoodsList = new List<ItemGoods>();
		itemReadList = new List<ItemRead>();
		itemSpecialList = new List<ItemSpecial>();
	}

	#region Weapon
	public bool AddWeapon(ItemEnum.WEAPONeItemIndex _index)
	{
		if (itemWeaponList.Count >= itemWeaponMax) return false;
		ItemWeapon item = null;
		Itemtable.Instance.GetWeaponTable(_index, out item);
		itemWeaponList.Add(item);

		return true;
	}
	#endregion

	#region Equip
	public bool AddEquipt(ItemEnum.EQUIPMENTINDEX _index)
	{
		if (itemEquipList.Count >= itemEquipMax) return false;

		ItemEquipment item = null;
		Itemtable.Instance.GetEquiptTable(_index,out item);
		itemEquipList.Add(item);


		return true;
	}

	#endregion

	#region Food
	public bool AddFood(ItemEnum.FOODeItemIndex _index, int _value)
	{
		if (itemFoodList.Count >= itemFoodMax) return false;

		bool check = false;
		foreach (ItemFood target in ItemFoodList)
		{
			if(target.Index == _index)
			{
				if (target.InItemCount(_value) == true) return true;
			}
		}
		if (check == false) return false;

		ItemFood item = null;
		Itemtable.Instance.GetFoodTable(_index, out item);
		itemFoodList.Add(item);

		return true;
	}

	#endregion

	#region Quest
	public bool AddQuest(ItemEnum.QUESTeItemIndex _index, int _value)
	{
		if (itemQuestList.Count >= itemQuestMax) return false;

		bool check = false;
		foreach (ItemQuest target in ItemQuestList)
		{
			if (target.Index == _index)
			{
				if (target.InItemCount(_value) == true) return true;
			}
		}
		if (check == false) return false;

		ItemQuest item = null;
		Itemtable.Instance.GetQuestTable(_index, out item);
		itemQuestList.Add(item);

		return true;
	}
	#endregion

	#region Goods
	public bool AddGoods(ItemEnum.GOODSeItemIndex _index, int _value)
	{
		if (itemGoodsList.Count >= itemGoodsMax) return false;

		bool check = false;
		foreach (ItemGoods target in ItemGoodsList)
		{
			if (target.Index == _index)
			{
				if (target.InItemCount(_value) == true) return true;
			}
		}
		if (check == false) return false;

		ItemGoods item = null;
		Itemtable.Instance.GetGoodsTable(_index, out item);
		itemGoodsList.Add(item);

		return true;
	}
	#endregion

	#region Read
	public bool AddRead(ItemEnum.READeItemIndex _index)
	{
		if (itemReadList.Count >= itemReadMax) return false;

		bool check = false;
		foreach (ItemRead target in ItemReadList)
		{
			if (target.Index == _index)
			{
				return false;
			}
		}
		if (check == false) return false;

		ItemRead item = null;
		Itemtable.Instance.GetReadTable(_index, out item);
		itemReadList.Add(item);

		return true;
	}
	#endregion

	#region Special
	public bool AddSpecial(ItemEnum.SPECIALeItemIndex _index, int _value)
	{
		if (itemSpecialList.Count >= itemSpecialMax) return false;

		bool check = false;
		foreach (ItemSpecial target in ItemSpecialList)
		{
			if (target.Index == _index)
			{
				if (target.InItemCount(_value) == true) return true;
			}
		}
		if (check == false) return false;

		ItemSpecial item = null;
		Itemtable.Instance.GetSpecialTable(_index, out item);
		itemSpecialList.Add(item);

		return true;
	}
	#endregion
}
#endregion


#region CharacterData
[System.Serializable]
public class CharacterData
{
	public ePlayerCharIndex Index { get; private set; }

	public bool bDead;
	public bool bGetChar;

	public int Hp;
	public int HpMax;

	// 해당 게임에선 MP가 플레이어 UI에 발생하지 않고 스킬 딜레이에 down=>Up으로 차오름

	public int Shield;
	public int ShieldMax;

	public int Stamina;
	public int StaminaMax;

	public int Level;
	public int LevelMax;

	public int Exp;
	public int ExpMax;

	public int Damage;

	public byte ESkillStack;
	public float ESkillCurr;
	public float ESkillMax;


	public byte QSkillStack;
	public float QSkillCurr;
	public float QSkillMax;


	// 착용 아이템 처리는?
	
	public CharacterData()
	{
		bDead = false;
		bGetChar = false;
	
		Hp = HpMax = 0;
		Stamina = StaminaMax = 0;

		Level = 1;
		LevelMax = 20;  // 첫 돌파 전까지
		Damage = 0;

		Shield = 0;
		ShieldMax = 999999999;

		ESkillStack = 1;
		ESkillCurr = ESkillMax = 0;

		QSkillStack = 1;
		QSkillCurr = QSkillMax = 0;


	}

	public void Init(ePlayerCharIndex _index)
	{
		// 캐릭터 테이블에서 가져와야함
		Index = _index;
		bDead = false;
		bGetChar = false;

		Hp = 0;
		HpMax = 0;


		Shield = 0;
		ShieldMax = 999999999;

		Stamina = 0;
		StaminaMax = 0;
	}

	public bool InitToLoad(bool _dead, bool _get, Vector3 _pos, Vector3 _dir, int _currHp, int _currExp)
	{
		bool result = false;

		bDead = _dead;
		bGetChar = _get;
	
		Hp = _currHp;
		Exp = _currExp;

		return result;
	}


	#region HpFunction
	public void IncreaseHp(int _addValue) { Hp += _addValue; }
	public void ReduceHp(int _reduceHp) { Hp -= _reduceHp; }
	public float GetHpPercent() { return (float)Hp / (float)HpMax; }
	public void ResetHp() { Hp = HpMax; }
	#endregion



	#region StaminaFunction
	public void IncreaseStamina(int _addValue) { Stamina += _addValue; }
	public void ReduceStamina(int _reduceValue) { Stamina -= _reduceValue; }
	public float GetStaminaPercent() { return (float)Stamina / (float)StaminaMax; }
	public void ResetStamina() { Stamina = StaminaMax; }
	#endregion	
	
	
	#region LevelFunction
	public void IncreaseLevel(int _addValue) { Level += _addValue; }
	public void ResetLevel() { Level = 1; }
	#endregion	
	
	
	#region ExpFunction
	public void IncreaseExp(int _addValue) { Exp += _addValue; }
	public void ReduceExp(int _reduceValue) { Exp -= _reduceValue; }
	public float GetExpPercent() { return (float)Exp / (float)ExpMax; }
	public void ResetExp() { Exp = ExpMax; }
	#endregion

	public void RefreshLevelUpToBaseData()
	{
		Level++;
		
		// --------------안씀--------// CharacterTable에서 (Level과 index를 통해 해당 캐릭터 정보를 대입
		// 증가값까지 설정한 후 증가값 계산

	}


}
#endregion

// 2. 유저 데이터
#region UserData
[System.Serializable]
public class UserData {
	public uint UserID { get; private set; }
	public string UserName { get; private set; }
	public int Gold { get; private set; }
	public int GoldMax { get; private set; }
	public int Jewel { get; private set; }
	public int JewelMax { get; private set; }


	public void Init()
	{
		UserID = 000000001;
		UserName = "";

		Gold = 0;
		Jewel = 0;

		GoldMax = 999999999;
		JewelMax = 999999999;

	}

	public void Load(uint _userId , string _userName, int _gold, int _jewel)
	{
		UserID = _userId;
		UserName = _userName;
		Gold = _gold;
		Jewel = _jewel;
	}

	public void SetUserID(uint _idNumber) { UserID = _idNumber; }
	public void SetUserName(string _userName) { UserName = _userName; }

	public bool SetGold(int _gold, bool _add)
	{
		if( _add)
		{
			if (Gold + _gold > GoldMax) return false;
			Gold += _gold;
		}
		else
		{
			if (Gold - _gold < 0) return false;
			Gold -= _gold;
		}
		return true;
	}

	public bool SetJewel(int _jewel, bool _add)
	{
		if (_add)
		{
			if (Jewel + _jewel > JewelMax) return false;
			Jewel += _jewel;
		}
		else
		{
			if (Gold - _jewel < 0) return false;
			Jewel -= _jewel;
		}
		return true;
	}

	// 인벤토리는 유저 데이터라고 생각하는데 일단 플레이어 데이터로 이동
}
#endregion

[System.Serializable]
public class DataManager : SlngleTonMonobehaviour<DataManager>
{
	public PlayerData Player { get; set; }
	public List<CharacterData> CharacterDataList { get; private set; }
	public UserData UserData { get; private set; }
	public ItemData ItemList { get; set; }

	#region Awake Start Update
	private void Awake()
	{
		Player = new PlayerData();
		CharacterDataList = new List<CharacterData>();
		UserData = new UserData();
		ItemList = new ItemData();
	}
	#endregion

	public void Init()
	{
		UserData.Init();
		
	}

	#region PlayerFunctions


	public bool AddCharacter(ePlayerCharIndex index)
	{
		if( CharacterDataList != null)
		{
			foreach (CharacterData item in CharacterDataList)
			{
				if (item.Index == index) return false;
			}
		}

		CharacterData newCharacter = new CharacterData();
		newCharacter.Init(index);
		CharacterDataList.Add(newCharacter);

		return true;
	}

	

	public int PlayerHP { get { Debug.Log(Player.Index); return GetModelNumber(Player.Index).Hp; } set { GetModelNumber(Player.Index).Hp = value; } }
	public float PlayerHpPercent() { return GetModelNumber(Player.Index).GetHpPercent(); }
	public void PlayerHpReset() { GetModelNumber(Player.Index).Hp = GetModelNumber(Player.Index).HpMax; }


	public int PlayerStamina { get { return GetModelNumber(Player.Index).Stamina; } set { GetModelNumber(Player.Index).Stamina = value; } }
	public int PlayerStaminaMax { get { return GetModelNumber(Player.Index).StaminaMax; } }
	public float PlayerStaminaPercent() { return GetModelNumber(Player.Index).GetStaminaPercent(); }
	public void PlayerStaminaReset() { GetModelNumber(Player.Index).ResetStamina(); }



	public int PlayerLevel { get { return GetModelNumber(Player.Index).Level; }
		set { GetModelNumber(Player.Index).Level = value; } }
	public int PlayerLevelMax { get { return GetModelNumber(Player.Index).Level; } }
	public void PlayerLevelReset() { GetModelNumber(Player.Index).ResetLevel(); }

	public int PlayerExp { get { return GetModelNumber(Player.Index).Exp; } 
		set { GetModelNumber(Player.Index).Exp = value; } }
	public int PlayerExpMax { get { return GetModelNumber(Player.Index).ExpMax; } }
	public float PlayerExpPercent() { return GetModelNumber(Player.Index).GetExpPercent(); }
	public void PlayerExpReset() { GetModelNumber(Player.Index).ResetExp(); }

	public bool PlayerIsDead { get { return GetModelNumber(Player.Index).bDead; } }

	public int PlayerBaseDamage { get { return GetModelNumber(Player.Index).Damage; } }

	public int PlayerShield { get { return GetModelNumber(Player.Index).Shield; } set { GetModelNumber(Player.Index).Shield = value; } }
	public int PlayerShieldMax { get { return GetModelNumber(Player.Index).ShieldMax; } }


	public float PlayerESkill { get { return GetModelNumber(Player.Index).ESkillCurr; } set { GetModelNumber(Player.Index).ESkillCurr = value; } }
	public bool PlayerESkillUse { get { return GetModelNumber(Player.Index).ESkillCurr < GetModelNumber(Player.Index).ESkillMax; } }
	public void PlayerESkillReset() { GetModelNumber(Player.Index).ESkillCurr = GetModelNumber(Player.Index).ESkillMax; }


	public float PlayerQSkill { get { return GetModelNumber(Player.Index).QSkillCurr; } set { GetModelNumber(Player.Index).QSkillCurr = value; } }
	public bool PlayerQSkillUse { get { return GetModelNumber(Player.Index).QSkillCurr < GetModelNumber(Player.Index).QSkillMax; } }
	public void PlayerQSkillReset() { GetModelNumber(Player.Index).QSkillCurr = GetModelNumber(Player.Index).QSkillMax; }


	public CharacterData GetModelNumber(ePlayerCharIndex _index)
	{
		foreach (var character in CharacterDataList)
		{
			if (character.Index == _index)
			{
				return character;
			}
		}
		return null;
	}

	#endregion


	//#region UserFunctions
	//public uint UserID { get { return UserData.UserID; } set { UserData.UserID = value; } }
	//public string UserName { get { return UserData.UserName; } set { UserData.UserName= value; } }
	//public int Gold { get { return UserData.Gold; } set { UserData.Gold = value; } }
	//public int Jewel { get { return UserData.Jewel; } set { UserData.Jewel = value; } }

	//#endregion
}
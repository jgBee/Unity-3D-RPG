using UnityEngine;

public class WeaponEnum
{
	public enum eWeaponTypeIndex : short
	{
		None = 0,
		OneHandSword,
		TwoHandSword,
		Spear,
		Bow,
		Catalyst
	};

	public static eWeaponTypeIndex GetWeaponType(string _str)
	{
		switch (_str)
		{
			case "OneHandSword":	return eWeaponTypeIndex.OneHandSword;
			case "TwoHandSword":	return eWeaponTypeIndex.TwoHandSword;
			case "Spear":	return eWeaponTypeIndex.Spear;
			case "Bow":	return eWeaponTypeIndex.Bow;
			case "Catalyst":	return eWeaponTypeIndex.Catalyst;

			default:
				Debug.LogError("무기 타입이 정해지지 않았습니다.");
				return eWeaponTypeIndex.None;
		}
	}
}
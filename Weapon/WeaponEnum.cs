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
				Debug.LogError("���� Ÿ���� �������� �ʾҽ��ϴ�.");
				return eWeaponTypeIndex.None;
		}
	}
}
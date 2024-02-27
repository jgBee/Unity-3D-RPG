using UnityEngine;
using static ElementEnum;

public class Elemental : MonoBehaviour
{
	public static eElementRESULT ElementResult(ref eElement _first, ref eElement _second)
	{
		eElementRESULT result = eElementRESULT.Wind_Wind;

		switch (_first)
		{
			case eElement.Wind:
				switch (_second)
				{
					case eElement.Wind: return eElementRESULT.Wind_Wind;
					case eElement.Rock: return eElementRESULT.Wind_Rock;
					case eElement.Thunder: return eElementRESULT.Wind_Thunder;
					case eElement.Grass: return eElementRESULT.Wind_Grass;
					case eElement.Water: return eElementRESULT.Wind_Water;
					case eElement.Fire: return eElementRESULT.Wind_Fire;
					case eElement.Ice: return eElementRESULT.Wind_Ice;
				}
				break;
			case eElement.Rock:
				switch (_second)
				{
					case eElement.Wind: return eElementRESULT.Rock_Wind;
					case eElement.Rock: return eElementRESULT.Rock_Rock;
					case eElement.Thunder: return eElementRESULT.Rock_Thunder;
					case eElement.Grass: return eElementRESULT.Rock_Grass;
					case eElement.Water: return eElementRESULT.Rock_Water;
					case eElement.Fire: return eElementRESULT.Rock_Fire;
					case eElement.Ice: return eElementRESULT.Rock_Ice;
				}
				break;
			case eElement.Thunder:
				switch (_second)
				{
					case eElement.Wind: return eElementRESULT.Thunder_Wind;
					case eElement.Rock: return eElementRESULT.Thunder_Rock;
					case eElement.Thunder: return eElementRESULT.Thunder_Thunder;
					case eElement.Grass: return eElementRESULT.Thunder_Grass;
					case eElement.Water: return eElementRESULT.Thunder_Water;
					case eElement.Fire: return eElementRESULT.Thunder_Fire;
					case eElement.Ice: return eElementRESULT.Thunder_Ice;
				}
				break;
			case eElement.Grass:
				switch (_second)
				{
					case eElement.Wind: return eElementRESULT.Grass_Wind;
					case eElement.Rock: return eElementRESULT.Grass_Rock;
					case eElement.Thunder: return eElementRESULT.Grass_Thunder;
					case eElement.Grass: return eElementRESULT.Grass_Grass;
					case eElement.Water: return eElementRESULT.Grass_Water;
					case eElement.Fire: return eElementRESULT.Grass_Fire;
					case eElement.Ice: return eElementRESULT.Grass_Ice;
				}
				break;
			case eElement.Water:
				switch (_second)
				{
					case eElement.Wind: return eElementRESULT.Water_Wind;
					case eElement.Rock: return eElementRESULT.Water_Rock;
					case eElement.Thunder: return eElementRESULT.Water_Thunder;
					case eElement.Grass: return eElementRESULT.Water_Grass;
					case eElement.Water: return eElementRESULT.Water_Water;
					case eElement.Fire: return eElementRESULT.Water_Fire;
					case eElement.Ice: return eElementRESULT.Water_Ice;
				}
				break;
			case eElement.Fire:
				switch (_second)
				{
					case eElement.Wind: return eElementRESULT.Fire_Wind;
					case eElement.Rock: return eElementRESULT.Fire_Rock;
					case eElement.Thunder: return eElementRESULT.Fire_Thunder;
					case eElement.Grass: return eElementRESULT.Fire_Grass;
					case eElement.Water: return eElementRESULT.Fire_Water;
					case eElement.Fire: return eElementRESULT.Fire_Fire;
					case eElement.Ice: return eElementRESULT.Fire_Ice;
				}
				break;
			case eElement.Ice:
				switch (_second)
				{
					case eElement.Wind: return eElementRESULT.Ice_Wind;
					case eElement.Rock: return eElementRESULT.Ice_Rock;
					case eElement.Thunder: return eElementRESULT.Ice_Thunder;
					case eElement.Grass: return eElementRESULT.Ice_Grass;
					case eElement.Water: return eElementRESULT.Ice_Water;
					case eElement.Fire: return eElementRESULT.Ice_Fire;
					case eElement.Ice: return eElementRESULT.Ice_Ice;
				}
				break;
		}
		return result;
	}
}
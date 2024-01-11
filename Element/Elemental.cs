using UnityEngine;
using static ElementEnum;

public class Elemental : MonoBehaviour
{
	public static ELEMENTRESULT ElementResult(ref ELEMENT _first, ref ELEMENT _second)
	{
		ELEMENTRESULT result = ELEMENTRESULT.Wind_Wind;

		switch (_first)
		{
			case ELEMENT.Wind:
				switch (_second)
				{
					case ELEMENT.Wind: return ELEMENTRESULT.Wind_Wind;
					case ELEMENT.Rock: return ELEMENTRESULT.Wind_Rock;
					case ELEMENT.Thunder: return ELEMENTRESULT.Wind_Thunder;
					case ELEMENT.Grass: return ELEMENTRESULT.Wind_Grass;
					case ELEMENT.Water: return ELEMENTRESULT.Wind_Water;
					case ELEMENT.Fire: return ELEMENTRESULT.Wind_Fire;
					case ELEMENT.Ice: return ELEMENTRESULT.Wind_Ice;
				}
				break;
			case ELEMENT.Rock:
				switch (_second)
				{
					case ELEMENT.Wind: return ELEMENTRESULT.Rock_Wind;
					case ELEMENT.Rock: return ELEMENTRESULT.Rock_Rock;
					case ELEMENT.Thunder: return ELEMENTRESULT.Rock_Thunder;
					case ELEMENT.Grass: return ELEMENTRESULT.Rock_Grass;
					case ELEMENT.Water: return ELEMENTRESULT.Rock_Water;
					case ELEMENT.Fire: return ELEMENTRESULT.Rock_Fire;
					case ELEMENT.Ice: return ELEMENTRESULT.Rock_Ice;
				}
				break;
			case ELEMENT.Thunder:
				switch (_second)
				{
					case ELEMENT.Wind: return ELEMENTRESULT.Thunder_Wind;
					case ELEMENT.Rock: return ELEMENTRESULT.Thunder_Rock;
					case ELEMENT.Thunder: return ELEMENTRESULT.Thunder_Thunder;
					case ELEMENT.Grass: return ELEMENTRESULT.Thunder_Grass;
					case ELEMENT.Water: return ELEMENTRESULT.Thunder_Water;
					case ELEMENT.Fire: return ELEMENTRESULT.Thunder_Fire;
					case ELEMENT.Ice: return ELEMENTRESULT.Thunder_Ice;
				}
				break;
			case ELEMENT.Grass:
				switch (_second)
				{
					case ELEMENT.Wind: return ELEMENTRESULT.Grass_Wind;
					case ELEMENT.Rock: return ELEMENTRESULT.Grass_Rock;
					case ELEMENT.Thunder: return ELEMENTRESULT.Grass_Thunder;
					case ELEMENT.Grass: return ELEMENTRESULT.Grass_Grass;
					case ELEMENT.Water: return ELEMENTRESULT.Grass_Water;
					case ELEMENT.Fire: return ELEMENTRESULT.Grass_Fire;
					case ELEMENT.Ice: return ELEMENTRESULT.Grass_Ice;
				}
				break;
			case ELEMENT.Water:
				switch (_second)
				{
					case ELEMENT.Wind: return ELEMENTRESULT.Water_Wind;
					case ELEMENT.Rock: return ELEMENTRESULT.Water_Rock;
					case ELEMENT.Thunder: return ELEMENTRESULT.Water_Thunder;
					case ELEMENT.Grass: return ELEMENTRESULT.Water_Grass;
					case ELEMENT.Water: return ELEMENTRESULT.Water_Water;
					case ELEMENT.Fire: return ELEMENTRESULT.Water_Fire;
					case ELEMENT.Ice: return ELEMENTRESULT.Water_Ice;
				}
				break;
			case ELEMENT.Fire:
				switch (_second)
				{
					case ELEMENT.Wind: return ELEMENTRESULT.Fire_Wind;
					case ELEMENT.Rock: return ELEMENTRESULT.Fire_Rock;
					case ELEMENT.Thunder: return ELEMENTRESULT.Fire_Thunder;
					case ELEMENT.Grass: return ELEMENTRESULT.Fire_Grass;
					case ELEMENT.Water: return ELEMENTRESULT.Fire_Water;
					case ELEMENT.Fire: return ELEMENTRESULT.Fire_Fire;
					case ELEMENT.Ice: return ELEMENTRESULT.Fire_Ice;
				}
				break;
			case ELEMENT.Ice:
				switch (_second)
				{
					case ELEMENT.Wind: return ELEMENTRESULT.Ice_Wind;
					case ELEMENT.Rock: return ELEMENTRESULT.Ice_Rock;
					case ELEMENT.Thunder: return ELEMENTRESULT.Ice_Thunder;
					case ELEMENT.Grass: return ELEMENTRESULT.Ice_Grass;
					case ELEMENT.Water: return ELEMENTRESULT.Ice_Water;
					case ELEMENT.Fire: return ELEMENTRESULT.Ice_Fire;
					case ELEMENT.Ice: return ELEMENTRESULT.Ice_Ice;
				}
				break;
		}
		return result;
	}
}
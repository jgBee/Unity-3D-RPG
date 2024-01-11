using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIPlayerInfo : MonoBehaviour
{
	[SerializeField] private Image Hp;
	[SerializeField] private Image Exp;
	[SerializeField] private Image Icon;
	[SerializeField] private TextMeshProUGUI level;
	[SerializeField] private TextMeshProUGUI tag;
	[SerializeField] private TextMeshProUGUI name;

	public void SetInfo(string _name,int _tag, float _hpPer, float _expPer, int _level)
	{
		name.text = _name; tag.text = "#" + _tag.ToString();
		Hp.fillAmount = _hpPer; Exp.fillAmount= _expPer; 
		level.text = _level.ToString();
		//Icon.sprite = _spr;
	}
	public void SetName(string _str) { name.text = _str; }

	public void SetHp(float _percent){ Hp.fillAmount = _percent; }
	public void SetExp(float _percent) { Exp.fillAmount = _percent; }

	public void SetIcon(ref Sprite _spr) { Icon.sprite = _spr; }

	public void SetLevel(int _level) { level.text = _level.ToString(); }
}
using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using TMPro;


public class UIManager : SlngleTonMonobehaviour<UIManager>
{
	public Canvas staticCanvas;
	public Canvas dynamicCanvas;

	public bool bUIOn = false;

	public GameObject minimap;

	[SerializeField] private GameObject fieldUI;

	[SerializeField] private UIPlayerInfo playerInfoBar;
	[SerializeField] private Inventory inventory;
	[SerializeField] private Joystick joystick;

	[Header("Status")]
	[SerializeField] private TextMeshProUGUI staminaText;
	[SerializeField] private TextMeshProUGUI jewelText;
	[SerializeField] private TextMeshProUGUI goldText;

	[Header("UI")]
	[SerializeField] private GameObject setting;
	[SerializeField] private GameObject shopGold;
	[SerializeField] private GameObject shopJewel;
	[SerializeField] private GameObject shopItemBox;
	[SerializeField] private GameObject questBoard;
	[SerializeField] private QuestInfoPanel questInfoPanel;
	[SerializeField] private UIChatWindow chatWindow;

	[SerializeField] private UIPlayerActionButton attackBtn;
	[SerializeField] private UIPlayerActionButton eSkillBtn;
	[SerializeField] private UIPlayerActionButton qSkillBtn;

	[SerializeField] private KeyGuide keyGuide;
	[SerializeField] private UIPlayMode playMode;
	[SerializeField] private UINotifyGame notifyGame;

	[SerializeField] private UIWarning uiWarning;

	[SerializeField] private BossBar bossBar;

	[SerializeField] private UIFieldTopButton fieldButtonQuest;
	[SerializeField] private UIFieldTopButton fieldButtonInventory;

	private Vector3 joystickPos;


	public void StaticCanvasInChild(ref Transform _tr)
	{
		_tr.parent = staticCanvas.transform;
	}

	public void DynamicCanvasInChild(ref Transform _tr)
	{
		_tr.parent = dynamicCanvas.transform;
	}


	#region UI
	public void Inventory(bool _visible)
	{
		bUIOn = _visible;
		if (_visible == true) fieldButtonInventory.ResetNotify();
		inventory.Active(_visible);
	}

	public void Minimap(bool _visible)
	{
		bUIOn = _visible;
		minimap.gameObject.SetActive(_visible);
	}

	public void Setting(bool _visible)
	{
		bUIOn = _visible;
		setting.gameObject.SetActive(_visible);
	}

	public void ShopGold(bool _visible)
	{
		bUIOn = _visible;
		shopGold.gameObject.SetActive(_visible);
	}

	public void ShopJewel(bool _visible)
	{
		bUIOn = _visible;
		shopJewel.gameObject.SetActive(_visible);
	}

	public void ShopItemBox(bool _visible)
	{
		bUIOn = _visible;
		shopItemBox.gameObject.SetActive(_visible);
	}

	public void QuestBoard(bool _visible)
	{
		bUIOn = _visible;
		if (_visible == true) fieldButtonQuest.ResetNotify();
		questBoard.gameObject.SetActive(_visible);
	}

	public void UIChatWindow(bool _visible)
	{
		bUIOn = _visible;
		chatWindow.gameObject.SetActive(false);
	}

	public void BossBar(bool _visible)
	{
		bossBar.Active(_visible);
	}

	public void SetBossBar(float _hpPer, int _hp, int _hpMax)
	{
		bossBar.OnBar(_hpPer, _hp, _hpMax);
	}

	public void Warning(bool _active, float _maxTime)
	{
		uiWarning.Active(_active, _maxTime);
	}
	public bool UIChatWindowGetActive() { return chatWindow.gameObject.activeSelf; }

	#endregion


	public void GoField(bool _flag)
	{
		if (_flag)
		{
			bUIOn = false;
			//CursorLock(true);
			fieldUI.SetActive(true);
			setting.gameObject.SetActive(false);
			shopGold.gameObject.SetActive(false);
			shopJewel.gameObject.SetActive(false);
			shopItemBox.gameObject.SetActive(false);
			questBoard.gameObject.SetActive(false);
		}
		else
		{
			bUIOn = true;
			//CursorLock(false);
			fieldUI.SetActive(false);
		}
	}
	public void CursorLock(bool _flag)
	{
		if (_flag)
		{
			Cursor.visible = false;
			Cursor.lockState = CursorLockMode.Locked;

		}
		else
		{
			Cursor.visible = true;
			Cursor.lockState = CursorLockMode.None;
		}
	}

	public Vector3 GetJoystick()
	{
		if (joystickPos == null) joystickPos = new Vector3();
		joystickPos.x = joystick.Horizontal;
		joystickPos.y = 0;
		joystickPos.z = joystick.Vertical;
		return joystickPos;
	}

	//	public void Init(string[] _chatList,string _name, string _job, Sprite _charImamge, UnityAction _action)
	public void OpenUIChatWindow(ref List<string> _chatList, string _name, string _job, Texture _charImamge)
	{
		if (chatWindow.gameObject.activeSelf == true) return;

		bUIOn = true;
		chatWindow.gameObject.SetActive(true);
		chatWindow.Init(ref _chatList, _name, _job, _charImamge);
	}


	#region QuestInfo
	public void WaitQuestInfo(int _questNumber)
	{
		bUIOn = true;
		questInfoPanel.Init(_questNumber, false, delegate () { QuestManager.Instance.QuestIn(_questNumber); bUIOn = false; fieldButtonQuest.OnNotify(); }, delegate () { bUIOn = false; }, delegate () { bUIOn = false; });

	}

	public void RewardQuestInfo(int _questNumber, UnityAction _action)
	{
		bUIOn = true;
		questInfoPanel.Init(_questNumber, true, delegate () { QuestManager.Instance.QuestClear(_questNumber); if (_action != null) _action(); bUIOn = false; fieldButtonQuest.OnNotify(); }, delegate () { bUIOn = false; }, delegate () { bUIOn = false; });
	}

	public void QuestInfoOkOnly(int _questNumber, UnityAction _okAction)
	{
		bUIOn = true;
		questInfoPanel.Init(_questNumber, true, delegate () { if (_okAction != null) _okAction(); bUIOn = false; fieldButtonQuest.OnNotify(); }, delegate () { bUIOn = false; }, delegate () { bUIOn = false; });
	}
	#endregion


	public void SetPlayerBarInfo(string _name, int _tag, float _hpPer, float _expPer, int _level)
	{
		playerInfoBar.SetInfo(_name, _tag, _hpPer, _expPer, _level);
	}


	public void SetStamina(int _curr, int _max)
	{
		staminaText.text = _curr + "/" + _max;
	}


	public void SetJewel(int _value)
	{
		jewelText.text = _value.ToString();
	}

	public void SetGold(int _value)
	{
		goldText.text = _value.ToString();
	}


	public void SetESkill(float _timeValue, float _percentage)
	{
		eSkillBtn.SetText(_percentage, _timeValue);
	}
	public void SetQSkill(float _timeValue, float _percentage)
	{
		qSkillBtn.SetText(_percentage, _timeValue);
	}


	public void PlayMode(int _num)
	{
		playMode.OnMessage(_num);
	}

	public void KeyGuide(string _key)
	{
		keyGuide.OnMessage(_key);
	}

	public void NotifyGame(float _viewTime, string _str)
	{
		notifyGame.OnNotify(_viewTime, _str);
	}

	public void AddFieldButtonInventoryAddNotify()
	{
		fieldButtonInventory.OnNotify();
	}


	public void TestActiveJoystickAndActionButton(bool _active)
	{
		joystick.gameObject.SetActive(_active);
		attackBtn.gameObject.SetActive(_active);
		eSkillBtn.gameObject.SetActive(_active);
		qSkillBtn.gameObject.SetActive(_active);
	}
}
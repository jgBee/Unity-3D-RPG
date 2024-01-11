using UnityEngine.EventSystems;
using UnityEngine;

public enum AxisOptions
{
	Both, 
	Horizontal,
	Vertical
}

// https://docs.unity3d.com/kr/530/Manual/SupportedEvents.html
public class Joystick : MonoBehaviour, IPointerDownHandler, IDragHandler,IPointerUpHandler
{
	private Vector2 input = Vector2.zero;

	private float deadZone = 0;
	private float handleRange = 1;
	
	private AxisOptions axisOptions = AxisOptions.Both;

	private bool snapX = false;
	private bool snapY = false;
	private bool IsPointerUp { get; set; }

	[SerializeField] protected RectTransform background = null;
	[SerializeField] private RectTransform handle = null;
	private RectTransform baseRect = null;

	private Canvas canvas;
	private Camera cam;

	public float Horizontal { get { return (snapX) ? SnapFloat(input.x, AxisOptions.Horizontal) : input.x; } }
	public float Vertical { get { return (snapY) ? SnapFloat(input.y, AxisOptions.Vertical) : input.y; } }

	public bool SnapX { get { return snapX; } set { snapX = value; } }
	public bool SnapY { get { return snapY; } set { snapY = value; } }


	public float DeadZone
	{
		get { return deadZone; }
		set { }
	}

	public float HandleRange
	{
		get { return handleRange; }
		set { handleRange = Mathf.Abs(value); }
	}

	protected virtual void Start()
	{
		IsPointerUp = true;

		HandleRange = handleRange;
		DeadZone = deadZone;
		baseRect = GetComponent<RectTransform>();
		canvas = GetComponentInParent<Canvas>();

		Vector2 center = new Vector2(0.5f, 0.5f);
		background.pivot = center;
		handle.anchorMin = center;
		handle.anchorMax = center;
		handle.pivot = center;
		handle.anchoredPosition = Vector2.zero;
	}

	private void FormatInput()
	{
		if (axisOptions == AxisOptions.Horizontal) input = new Vector2(input.x, 0f);
		else if (axisOptions == AxisOptions.Vertical) input = new Vector2(0f, input.y);
	}

	private float SnapFloat(float _value, AxisOptions _snapAxis)
	{
		if (_value == 0) return _value;
		float angle = Vector2.Angle(input, Vector2.up);

		switch (axisOptions)
		{
			case AxisOptions.Both:
				if(_snapAxis == AxisOptions.Horizontal)
				{
					if (angle < 22.5f || angle > 157.5f) return 0;
					else return (_value > 0) ? 1 : -1;
				}
				break;
			case AxisOptions.Horizontal:
				return _value;

				break;
			case AxisOptions.Vertical:
				if (angle > 67.5f && angle < 112.5f) return 0;
				else return (_value > 0) ? 1 : -1;
			default:
				if (_value > 0) return 1;
				if (_value < 0) return -1;
				break;
		}
		return 0;
	}

	protected Vector2 ScreenPointToAnchoredPosition(Vector2 _screenPosition)
	{
		Vector2 localPoint = Vector2.zero;
		if(RectTransformUtility.ScreenPointToLocalPointInRectangle(baseRect, _screenPosition, cam, out localPoint))
		{
			Vector2 pivotOffset = baseRect.pivot * baseRect.sizeDelta;
			return localPoint - (background.anchorMax * baseRect.sizeDelta) + pivotOffset;
		}
		return Vector2.zero;
	}

	protected virtual void HandleInput(float _magnitude, Vector2 _normalized, Vector2 _radius, Camera _cam)
	{
		if (_magnitude > deadZone)
		{
			if (_magnitude > 1) input = _normalized;
		}
		else input = Vector2.zero;	 

	}

#region PointerDown
	public virtual void OnPointerDown(PointerEventData _eventData)
	{
		OnDrag(_eventData);
	}
#endregion

#region Drag
	public void OnDrag(PointerEventData _eventData)
	{
		IsPointerUp = false;

		cam = null;
		if(canvas.renderMode == RenderMode.ScreenSpaceCamera)
		{
			cam = canvas.worldCamera;
		}
		Vector2 pos = RectTransformUtility.WorldToScreenPoint(cam, background.position);
		Vector2 radius = background.sizeDelta / 2;
		input = (_eventData.position - pos) / (radius * canvas.scaleFactor);
		FormatInput();
		HandleInput(input.magnitude, input.normalized, radius, cam);
		handle.anchoredPosition = input * radius * handleRange;
	}
#endregion

#region PointerUp
	public virtual void OnPointerUp(PointerEventData _eventData)
	{
		input = Vector2.zero;
		IsPointerUp = true;
		handle.anchoredPosition = Vector2.zero;
	}

	public void PointerUp()
	{
		input = Vector2.zero;
		IsPointerUp = true;
		handle.anchoredPosition = Vector2.zero;
	}
	#endregion



}
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


/// <summary>
/// @Date: 20220215
/// @namespace: cuj
/// @File: SpriteAni.cs
/// @constructor: Jayce
/// @version: v1.0
/// @inheritance: MonoBehaviour
/// @brif: 스프라이트 에니메이션
/// 단순히 스프라이트만 가지고 에니메이션을 표현하고 싶을때 사용
/// 이미지 오프젝트 만들고 listSprite에 이미지를 드래그 해서 넣어준다.
/// 1. UI->Image객체 생성
/// 2. 객체에 SpriteAni 추가
/// 3. listSprite 이미지들 드레그 해서 추가
/// 4. Reset버튼을 눌러서 초기화 해줌
/// </summary>
namespace cuj
{
	public class SpriteAni : MonoBehaviour
	{
		[SerializeField]
		[Tooltip("에니메이션 속도")]
		private float fSpeed = 0.33f;
		[SerializeField]
		[Tooltip("이미지 싸이즈에 맞춰서 렉트를 조정")]
		private bool bImageSize = true;
		[SerializeField]
		[Tooltip("이미지 크기(인스펙터에서 사용시 건들지 말것")]
		private float fMultiple = 1.0f;
		[SerializeField]
		[Tooltip("에니메이션 반복")]
		private bool bRepeat = true;
		[SerializeField]
		[Tooltip("반복횟수")]
		private int nRepeatCount = 0;
		[SerializeField]
		[Tooltip("반복이 끝나고 마지막 장면 유지")]
		private bool bMaintain = true;
		[SerializeField]
		[Tooltip("2d에니메이션에서 사용할 스프라이트 리스트")]
		private List<Sprite> listSprite;

		private int nAniCount = 0;
		private int nLoopingCount = 0;
		private int nRepeatedCount = 0;
		private bool bLoopAni = false;
		private float fAniFrameTime = 0.0f;
		private void Start()
		{
			//StartAni();
		}
		/// <summary>
		/// 이미지의 총갯수 확인
		/// </summary>
		/// <returns>장수 반환</returns>
		public int GetCount()
		{
			return listSprite.Count;
		}
		/// <summary>
		/// 반복여부 설정
		/// </summary>
		/// <param name="_count">반복횟수</param>
		/// <param name="_repeat">반복설정</param>
		/// <param name="_maintain">마지막장면 유지</param>
		public void SetLoop(int _count, bool _repeat, bool _maintain)
		{
			nRepeatCount = _count;
			bRepeat = _repeat;
			bMaintain = _maintain;
		}
		/// <summary>
		/// 원하는 시작 장면 설정
		/// </summary>
		/// <param name="_index">장면 색인</param>
		public void SetIndex(int _index)
		{
			StopAni(true);
			nAniCount = _index;
			GetComponent<Image>().sprite = listSprite[_index];
		}

		public void SetReverse()
		{
			listSprite.Reverse();
		}

		/// <summary>
		/// 회전량
		/// </summary>
		/// <param name="_rotate">rot = _rotate</param>
		public void SetRotation(Vector3 _rotate)
		{
			RectTransform rectTransform = GetComponent<RectTransform>();
			rectTransform.rotation = Quaternion.Euler(_rotate);
		}


		/// <summary>
		/// 에니메이션 시작
		/// </summary>
		public void StartAni()
		{
			if (bLoopAni) return;

			gameObject.SetActive(true);
			RectTransform rectTransform = GetComponent<RectTransform>();
			nAniCount = 0;
			if (bImageSize)
			{
				rectTransform.sizeDelta = new Vector2(listSprite[nAniCount].rect.width * fMultiple, listSprite[nAniCount].rect.height * fMultiple);
			}

			GetComponent<Image>().sprite = listSprite[nAniCount];
			nAniCount++;
			bLoopAni = true;
		}

		private System.Action EventCall;
		private int CallIndex = -1;
		/// <summary>
		/// StartAni() 같지만 완료시 이벤트 콜 발생 
		/// </summary>
		/// <param name="_CallIndex">이벤트 콜 받고 싶은 위치</param>
		/// <param name="_EventCall">콜 받고싶은 함수</param>
		public void StartAniEventCall(int _CallIndex = 0, System.Action _EventCall = null)
		{
			if (bLoopAni) return;

			EventCall = _EventCall;
			CallIndex = _CallIndex;

			gameObject.SetActive(true);
			RectTransform rectTransform = GetComponent<RectTransform>();
			nAniCount = 0;
			rectTransform.sizeDelta = new Vector2(listSprite[nAniCount].rect.width * fMultiple, listSprite[nAniCount].rect.height * fMultiple);
			GetComponent<Image>().sprite = listSprite[nAniCount];
			nAniCount++;
			bLoopAni = true;
		}

		/// <summary>
		/// 에니메이션 멈춤
		/// </summary>
		/// <param name="_Visible">에니메이션 완료후 사라짐 여부</param>
		public void StopAni(bool _Visible = false)
		{
			bLoopAni = false;
			gameObject.SetActive(_Visible);
		}

		/// <summary>
		/// 실제 외부에서 호출 하면 문제가 발생할수 있으므로 외부 호출 금지
		/// </summary>
		private void LoopAni()
		{
			fAniFrameTime += Time.deltaTime;
			if (fSpeed > fAniFrameTime)
			{
				return;
			}

			fAniFrameTime = 0.0f;

			GetComponent<Image>().sprite = listSprite[nAniCount];
			if (EventCall != null && nAniCount == CallIndex)
			{
				EventCall();
			}
			nAniCount++;

			if (listSprite.Count <= nAniCount)
			{
				nRepeatedCount++;
				nAniCount = 0;
				if (!bRepeat)
				{
					if (nRepeatCount <= nRepeatedCount)
					{
						if (!bMaintain)
						{
							gameObject.SetActive(false);
						}

						bLoopAni = false;
					}
				}
			}
		}

		private void Update()
		{
			if (bLoopAni)
			{
				LoopAni();
			}
		}

		public void SpriteListReverse()
		{
			listSprite.Reverse();
		}

		/*
        IEnumerator Animaiton_Sprite()
        {
            while (true)
            {
                GetComponent<Image>().sprite = listSprite[AniCount];
                if (EventCall != null && AniCount == CallIndex)
                {
                    EventCall();
                }
                AniCount++;

                if (listSprite.Count <= AniCount)
                {
                    nRepeatedCount++;
                    AniCount = 0;
                    if (!bRepeat)
                    {
                        if (nRepeatCount <= nRepeatedCount)
                        {
                            if (!bMaintain)
                            {
                                gameObject.SetActive(false);
                            }

                            break;
                        }
                    }
                }

                yield return new WaitForSeconds(fSpeed);
            }
        }/**/

		public void OnLoopAni()
		{
			LoopAni();
		}
	}

	/// <summary>
	/// Inspector창에 Reset버튼과 SpriteTest버튼 생성
	/// SpriteTest버튼으로 한장씩 이미지를 확인 가능
	/// Reset버튼으로 Ani첫장으로 되돌림
	/// </summary>
	//[CustomEditor(typeof(SpriteAni))]
	//public class SpriteAniButton : UnityEditor.Editor
	//{
	//	public override void OnInspectorGUI()
	//	{
	//		base.OnInspectorGUI();

	//		SpriteAni generator = (SpriteAni)target;

	//		//var style = new GUIStyle(GUI.skin.button);
	//		//style.normal.textColor = Color.blue;
	//		//style.fontSize = 70;
	//		//if (GUILayout.Button("Sprite Test",style))
	//		if (GUILayout.Button("Reset"))
	//		{
	//			generator.SetIndex(0);
	//		}

	//		if (GUILayout.Button("Sprite Test"))
	//		{
	//			generator.OnLoopAni();
	//		}

	//		if (GUILayout.Button("Start Ani"))
	//		{
	//			generator.StartAni();
	//		}

	//		if (GUILayout.Button("Stop Ani"))
	//		{
	//			generator.StopAni();
	//		}

	//		if (GUILayout.Button("Left"))
	//		{
	//			generator.SetRotation(new Vector3(0, 0, 0));
	//		}
	//		if (GUILayout.Button("Right"))
	//		{
	//			generator.SetRotation(new Vector3(0, 180, 0));
	//		}

	//		if (GUILayout.Button("Reverse"))
	//			generator.SetReverse();

	//		//Rect lastRect = GUILayoutUtility.GetLastRect();
	//		//Rect buttonRect = new Rect(lastRect.x, lastRect.y + EditorGUIUtility.singleLineHeight, 100, 30);
	//		//if (GUI.Button(buttonRect, "Sprite Test"))
	//		//{
	//		//    generator.LoopAni();
	//		//}
	//	}
	//}
}

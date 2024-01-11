using UnityEngine;

public class UIWarning : MonoBehaviour
{
    private float currTime;
	private float maxTime;

    public void Active(bool _active, float _maxTime)
    {
        gameObject.SetActive(_active);
        maxTime = _maxTime;
        currTime = 0.0f;
    }

	void Update()
    {
        if (UIManager.Instance.bUIOn) return;
        else
        {
            if(currTime>= maxTime)
            {
                gameObject.SetActive(false);
                return;
            }
            else
            {
                currTime += Time.deltaTime; 
            }
        }
    }
}

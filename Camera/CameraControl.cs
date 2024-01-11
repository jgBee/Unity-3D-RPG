using Cinemachine;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    UIManager uimanager;

    [SerializeField]CinemachineFreeLook cinemachineFreelook;
    // Start is called before the first frame update
    void Start()
    {
        uimanager = UIManager.Instance;
		if (cinemachineFreelook == null)
			gameObject.GetComponent<CameraControl>().enabled = false;

	}

    // Update is called once per frame
    void Update()
    {
        if(uimanager.bUIOn)
        {
            cinemachineFreelook.enabled = false;
		}
        else
        {
			cinemachineFreelook.enabled = true;
		}
    }
}

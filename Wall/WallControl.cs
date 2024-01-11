using UnityEngine;

public class WallControl : MonoBehaviour
{
    public bool bRenderer = false;

    void Start()
    {
        for (int i =0; i < transform.childCount; i++)
        {
            transform.GetChild(i).GetComponent<MeshRenderer>().enabled = bRenderer;
        }
    }
}
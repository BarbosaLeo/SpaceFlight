using UnityEngine;

public class CopyRotation : MonoBehaviour
{
    public GameObject playerCam;

    void Update()
    {
        transform.rotation = playerCam.transform.rotation;
    }
}

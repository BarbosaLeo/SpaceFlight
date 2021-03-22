using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public GameObject target;
    public GameObject player;
    Rigidbody playerRig;
    Rigidbody camRig;

    private void Awake()
    {
        camRig = GetComponent<Rigidbody>();
        playerRig = player.GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        transform.position = target.transform.position;
        camRig.velocity = playerRig.velocity;

        //transform.rotation = target.transform.rotation;
        transform.rotation = SmoothDamp.Rotate(transform.rotation, target.transform.rotation, 1f, .5f);
    }
}

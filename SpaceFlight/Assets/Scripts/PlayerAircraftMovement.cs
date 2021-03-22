using System.Collections;
using UnityEngine;

public class PlayerAircraftMovement : MonoBehaviour
{

    float forceMultiplier = 100f;
    float thrustForce = 5f;

    public float throttle { get; private set; } = .1f;

    float throttleIncrement = .01f;
    float throttleDecrement = .01f;
    float throttleDelay = 5f;

    Vector3 linearForce = new Vector3(100f,100f,100f);
    Vector3 linearInputForce = Vector3.zero;

    Vector3 angularForce = new Vector3(100f,100f,100f);
    Vector3 angularInputForce = Vector3.zero;
    
    Rigidbody playerRig;

    void Awake()
    {
        playerRig = GetComponent<Rigidbody> ();
    }


    void Update()
    {
        if (!GameState._gamePaused)
        {
            GetInputs();
        }
    }

    void FixedUpdate()
    {
        playerRig.AddRelativeForce(linearInputForce * forceMultiplier, ForceMode.Force);
        playerRig.AddRelativeTorque(angularInputForce * forceMultiplier, ForceMode.Force);
    }




    public void PhysicsInputs(Vector3 linearInput, Vector3 angularInput)
    {
        linearInputForce = MultiplyV3(linearInput, linearForce);
        angularInputForce = MultiplyV3(angularInput, angularForce);
    }




    void GetInputs()
    {
        float _roll = Input.GetAxis("Horizontal");
        float _pitch = Input.GetAxis("Vertical");
        float _elevate = Input.GetAxis("Elevator");
        float _accelerate = Input.GetAxis("tUp");
        float _decelerate = Input.GetAxis("tDown");

        Mathf.Clamp(_roll, -1f, 1f);

        if (throttle <= 1 && throttle >= 0)
        {
            StartCoroutine(ThrottleInput(_accelerate, _decelerate));
        }

        PhysicsInputs(new Vector3(0.0f,_elevate,throttle*thrustForce), new Vector3(_pitch, 0, -_roll));
    }



    Vector3 MultiplyV3(Vector3 a, Vector3 b)
    {
        Vector3 v3;

        v3.x = a.x * b.x;
        v3.y = a.y * b.y;
        v3.z = a.z * b.z;

        return v3;
    }

    IEnumerator ThrottleInput(float _accelerate, float _decelerate)
    {
        if(_accelerate > 0)
        {
            throttle += throttleIncrement;
            if(throttle > 1f)
            {
                throttle = 1f;
            }
            yield return new WaitForSeconds(throttleDelay);
        }
        if (_decelerate > 0)
        {
            throttle -= throttleDecrement;
            if(throttle < 0)
            {
                throttle = 0;
            }
            yield return new WaitForSeconds(throttleDelay);
        }
    }
}

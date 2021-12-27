using UnityEngine;

public class Grenade : MonoBehaviour
{
    public Rigidbody grenade;
    public GameObject grenadeObj;
    public float throwForce;

    public Rigidbody[] ExplodeRigidbodies;
    public float Impulse;

    public float timer = 3.0f;
    private bool _timerOn;
    private float _timeLeft;

    private void Start()
    {
        _timeLeft = timer;
        _timerOn = false;
    }

    void Update()
    {
        // Press 'E' key to move.
        if (Input.GetKeyDown(KeyCode.E)) { ThrowGrenade(); }

        // Press 'Space' key to explode
        if (Input.GetKeyDown(KeyCode.Space)) { Explode(); }

        if ( _timerOn ) 
        {
            _timeLeft -= Time.deltaTime;
            Debug.Log(_timeLeft);
        }
        if (_timeLeft < 0f) 
        {
            Explode(); 
            Debug.Log("BOOOOM!!!!");
        }
    }

    private void ThrowGrenade() 
    {
        _timerOn = true;
        Vector3 grenadePos = grenade.position;
        Vector3 direction = grenadePos.normalized;
        grenade.AddForce(direction * throwForce, ForceMode.Impulse);
    }
    private void Explode() 
    {
        Vector3 explodeCenter = grenade.transform.position;

        foreach (var explodeRigidbody in ExplodeRigidbodies)
        {
            Vector3 grenadeDistance = explodeRigidbody.position - explodeCenter;
            Vector3 direction = grenadeDistance.normalized;
            explodeRigidbody.AddForce(direction * Impulse, ForceMode.Impulse);

            DestroyGrenade();
            _timerOn = false;
        }
    }
    private void DestroyGrenade()
    {
        Destroy(grenadeObj);
    }
}

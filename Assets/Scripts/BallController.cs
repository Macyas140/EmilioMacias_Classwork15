using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class BallController : MonoBehaviour
{
    public float speed = 10f;
    public float force = 10f;
    public float FallLimit = -10f;
    public Transform spawnPoint;
    public KeyDirection[] keys;
    public KeyDirection jump;
    
    private Rigidbody _rigidbody;
    private Vector3 _torque =Vector3.zero;
    private Vector3 _jump;
    private Vector3 _initialPosition;
    
    [System.Serializable]
    public struct KeyDirection
    {
        public KeyCode key;
        public Vector3 direction;
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _initialPosition = transform.position;
        if(spawnPoint == null){
            GameObject newPoint = new GameObject("spawnPoint");
            newPoint.transform.position = _initialPosition;
            spawnPoint = newPoint.transform;
        }
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyDirection key in keys)
        {
            if (Input.GetKey(key.key))
            {
                _torque += key.direction;
            }
        }

        if (Input.GetKeyDown(jump.key))
        {
            _jump+=jump.direction;
        }

        if(transform.position.y < FallLimit){
            spawn();
        }
    }

    private void FixedUpdate()
    {
        _rigidbody.AddTorque(_torque * speed * Time.fixedDeltaTime);
        _torque = Vector3.zero;
        
        _rigidbody.AddForce(_jump * force);
        _jump = Vector3.zero;
    }

    private void spawn(){
        transform.position = spawnPoint.position;
        _rigidbody.linearVelocity = Vector3.zero;
        _rigidbody.angularVelocity = Vector3.zero;
    }
}

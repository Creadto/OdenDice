using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickTester : MonoBehaviour
{
    public List<Rigidbody> DiceRigids = new();
    public List<MeshCollider> DiceColliders = new();
    public Transform Destination;
    public Transform DiceCup;

    private float _timer = 0f;
    private bool _isShaking = false;
    private Vector3 _dirVec = Vector3.up;

    private void Shake()
    {
        if (Destination.localPosition.y < DiceCup.localPosition.y)
        {
            // Down
            _dirVec = Vector3.down;
        }
        else if (DiceCup.localPosition.y < 2f)
        {
            // Up
            _dirVec = Vector3.up;
        }

        Vector3 nextVec = _dirVec * 50.0f * Time.deltaTime;
        DiceCup.Translate(nextVec);

        
        foreach (var rigid in DiceRigids)
        {
            float dirX = Random.Range(0, 500);
            float dirY = Random.Range(0, 500);
            float dirZ = Random.Range(0, 500);
            float randDir = Random.Range(-1, 1);

            rigid.AddForce(Vector3.down * Random.Range(1, 10));
            rigid.AddTorque(dirX * randDir, dirY* randDir, dirZ* randDir);
        }
    }

    private void SetInitPostion()
    {
        Vector3 nextVec = new Vector3(DiceCup.localPosition.x, 3f, DiceCup.localPosition.z);
        DiceCup.localPosition = nextVec;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetMouseButtonDown(0))
        {
            _timer = 0f;
            _isShaking  = true;
            foreach (var collider in DiceColliders)
            {
                collider.material.staticFriction = 0.05f;
            }
        }
        if(_isShaking)
        {
            _timer += Time.deltaTime;
            if (_timer < 5f)
            {
                Shake();
            }
            else if(_timer >= 5f && _timer <= 8.4f)
            {
                SetInitPostion();
            }
            else
            {
                _isShaking = false;
                foreach (var collider in DiceColliders)
                {
                    collider.material.staticFriction = 30f;
                }
            }
        }
    }

    private void FixedUpdate()
    {

    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Ball : MonoBehaviour
{
    [SerializeField] private float _force = 5f;
    [SerializeField] private AudioSource _shootingAudio = null;
    [SerializeField] private Camera _camera;

    private Vector2 _whilePosition;

    private float _pullDistance, _startPosition, lrPullDistance;

    private Vector3 _offset;

    private float _screenSizePercentH, _screenSizePercentW;

    private float _cannonPower = 10f, _rotationPower = 10f;


    private void Start()
    {
        _screenSizePercentH = (Screen.height / Screen.height) * 100;
        _screenSizePercentW = (Screen.width / Screen.width) * 100;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            GetComponent<Rigidbody>().AddForce(new Vector3(0, 0 , -20), ForceMode.Impulse);
        }
    }

    private void Launch()
    {
        //_shootingAudio.Play();

        GetComponent<Rigidbody>().AddForce(new Vector3(10, 0, 0), ForceMode.Impulse);
        _pullDistance = 0;
    }
}

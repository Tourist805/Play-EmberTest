using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Launcher : MonoBehaviour
{
    //Establish Variables

    //position vector
    private Vector2 _whilePos;

    //distance and angle pulled left or right/up or down
    private float pullDis, startPos, lrPullDis;

    //ball object to launch
    [SerializeField] private GameObject _ballPrefab;
    private GameObject _instanceBall;

    //canon offset
    private Vector3 offset;

    //percentage variables
    private float _screenSizePercentH, _screenSizePercentW;

    public float CanonPower = 10;
    public float RotationPower = 10;

    // Start is called before the first frame update
    private void Start()
    {
        //get screen size percentage
        _screenSizePercentH = (Screen.height / Screen.height) * 100;
        _screenSizePercentW = (Screen.width / Screen.width) * 100;
    }

    // Update is called once per frame
    private void Update()
    {
        //if there is a touch on the screen
        if (Input.touchCount > 0)
        {
            //get 1st touch from array
            Touch touch = Input.GetTouch(0);

            //Handle finger movements based on TouchPhase
            switch (touch.phase)
            {
                //when the first touch is detected 
                case TouchPhase.Began:

                    break;

                //while a finger is on screen find its position and calculate release power
                case TouchPhase.Moved:
                    startPos = Screen.height / 2;
                    _whilePos = touch.position;
                    pullDis = _whilePos.y - startPos;
                    lrPullDis = _whilePos.x - Screen.width / 2;
                    break;

                //when the first touch leaves the screen record its end position
                case TouchPhase.Ended:
                    _whilePos = touch.position;
                    if (pullDis < 0)
                    {
                        //launch the ball
                        Launch();
                    }
                    break;
            }
        }
    }

    private void Launch()
    {
        //instantiate a copy of the ball object
        _instanceBall = Instantiate(_ballPrefab, this.transform.position + offset, Quaternion.identity);

        //send it with force from input
        _instanceBall.GetComponent<Rigidbody>().AddForce(new Vector3(pullDis * CanonPower, -pullDis * CanonPower, -lrPullDis * RotationPower), ForceMode.Impulse);
        pullDis = 0;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputMouse_Z : MonoBehaviour
{
    private float _lastFrameMousePositionX;
    private float _lastFrameMousePositionY;

    private float _moveFactorX;
    private float _moveFactorY;

    public float MoveFactorX => _moveFactorX;
    public float MoveFactorY => _moveFactorY;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _lastFrameMousePositionX = Input.mousePosition.x;
            _lastFrameMousePositionY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButton(0))
        {
            _moveFactorX = Input.mousePosition.x - _lastFrameMousePositionX;
            _lastFrameMousePositionX = Input.mousePosition.x;

            _moveFactorY = Input.mousePosition.y - _lastFrameMousePositionY;
            _lastFrameMousePositionY = Input.mousePosition.y;
        }
        else if (Input.GetMouseButtonUp(0))
        {
            _moveFactorX = 0;
            _moveFactorY = 0;
        }
    }
}

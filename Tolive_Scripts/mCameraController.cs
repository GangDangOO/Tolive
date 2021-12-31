using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class mCameraController : MonoBehaviour {
    Vector3 FirstPoint;
    Vector3 SecondPoint;
    public float xAngle = 0f;
    public float yAngle = 55f;
    float xAngleTemp;
    float yAngleTemp;

    public void BeginDrag(Vector2 a_FirstPoint) {
        FirstPoint = a_FirstPoint;
        xAngleTemp = xAngle;
        yAngleTemp = yAngle;
    }

    public void OnDrag(Vector2 a_SecondPoint) {
        SecondPoint = a_SecondPoint;
        xAngle = xAngleTemp + (SecondPoint.x - FirstPoint.x) * 180 / Screen.width;
        yAngle = yAngleTemp - (SecondPoint.y - FirstPoint.y) * 90 * 3f / Screen.height; // Y값 변화가 좀 느려서 3배 곱해줌.

        // 회전값을 40~85로 제한
        if (yAngle < 40f)
            yAngle = 40f;
        if (yAngle > 85f)
            yAngle = 85f;

        transform.rotation = Quaternion.Euler(yAngle, xAngle, 0.0f);
    }
}

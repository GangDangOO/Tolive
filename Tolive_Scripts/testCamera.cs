using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class testCamera : MonoBehaviour
{

    [SerializeField]
    private float walkSpeed;
    [SerializeField]
    private float lookSensitivity; //카메라 민감도
    [SerializeField]
    private float cameraRotationLimit;
    private float currentCameraRotationX; //현재 보고잇는 방향
    private float currentCameraRotationY;

    [SerializeField]
    private Camera theCamera;
    private Rigidbody myRigid;

    void Start()
    {
       
        myRigid = GetComponent<Rigidbody>();    
    }
    


    void Update()
    {
        Move();
        CameraRotation();
       
    }

    private void Move() {
        float _moveDirX = Input.GetAxisRaw("Horizontal");
        float _moveDirZ = Input.GetAxisRaw("Vertical");

        Vector3 _moveHorizontal = transform.right * _moveDirX;
        Vector3 _moveVertical = transform.forward * _moveDirZ;

        Vector3 _velocity = (_moveHorizontal + _moveVertical).normalized * walkSpeed;
        myRigid.MovePosition(transform.position + _velocity * Time.deltaTime);
    }

    private void CameraRotation() {
        //상하 카메라 회전
        /*float _xRotation = Input.GetAxisRaw("Mouse Y");
        float _cameraRotationX = _xRotation * lookSensitivity;
        currentCameraRotationX -= _cameraRotationX;
        currentCameraRotationX = Mathf.Clamp(currentCameraRotationX, -cameraRotationLimit, cameraRotationLimit); //한계 두기

        theCamera.transform.localEulerAngles = new Vector3(currentCameraRotationX, 0f, 0f);*/

        //좌우 캐릭터 회전
        float _yRotation = Input.GetAxisRaw("Mouse X");
        Vector3 _cameraRotationY = new Vector3(0f, _yRotation, 0f) * lookSensitivity;
        myRigid.MoveRotation(myRigid.rotation * Quaternion.Euler(_cameraRotationY));
       
    }
   
}

using System.Collections;
using System.Collections.Generic;
using PickUps;
using UnityEditor;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private GameObject rotationTransformObject;
    
    [SerializeField]
    private Camera cam;

    [SerializeField] 
    private float speed = 0;

    [SerializeField] private float backWardsSpeedRatio = 0.5f;
    [SerializeField]
    private float sideSpeed = 1;
    
    [SerializeField]
    private bool _isDriving = true;
    private bool _changingOnOff = true;
    private Vector3 _currentPosition;
    private Transform _currentTransform;
    private bool _forward = true;
    private bool _inputPrev = false;
    private PickUp _pickUp;
    private bool _game= false;

    private float eyeHeight;


    void Start()
    {
        _currentTransform = rotationTransformObject.transform;
        _currentPosition = transform.position;
        _pickUp = GetComponent<PickUp>();
        eyeHeight = _currentPosition.y;
        GameEventSystem.current.OnStartGame += StartPlaying;
        GameEventSystem.current.OnContinueGame += ContinuePlaying;
    }

    void Update()
    {
        if (_game)
        {

        TurnBikeOnOff();
        if (_isDriving) {
            
            Driving();
        }

        if (!_inputPrev && (Input.touchCount > 0 || Input.GetKeyDown(KeyCode.Mouse0)))
        {
            _inputPrev = true;
        }
        else
            _inputPrev = false;
        }

    }

    private void MoveCurrentPositionBasedOnCamera()
    {
        var camTransform = cam.transform;
        
            _currentTransform.rotation = camTransform.rotation;
            _currentPosition += _currentTransform.forward * speed * Time.deltaTime;
        
        
        //print(_currentTransform.forward);
        //_currentPosition += camTransform.right * camTransform.rotation.z * sideSpeed * Time.deltaTime * -1;
        _currentPosition.y = eyeHeight;
    }

    private void Driving()
    {
        MoveCurrentPositionBasedOnCamera();
        transform.position = _currentPosition;
    }

    private void TurnBikeOnOff()
    {
        if (cam.transform.eulerAngles.x <  50 || cam.transform.eulerAngles.x >= 100)
        {
            if (!_changingOnOff)
            {
                GameEventSystem.current.PauseGame();
                _isDriving = false;
                _pickUp.CanPickup = false;
                _changingOnOff = true;  
            }
            
        }
        else if (_changingOnOff)
        {
            _changingOnOff = false;
        }
        
    }

    private void StartPlaying()
    {
        _game = true;
        _isDriving = true;
        _pickUp.CanPickup = true;
    }

    private void ContinuePlaying()
    {
        _isDriving = true;
        _pickUp.CanPickup = true;
    }


}

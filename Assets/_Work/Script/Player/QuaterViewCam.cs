using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuaterViewCam : MonoBehaviour
{
    public void Start()
    {
        _targetTransform = _targetCharacter.transform;
    }

    [SerializeField]
    CharacterMove _targetCharacter;

    [SerializeField]
    float _camHeight;

    [SerializeField]
    float _camDistance;

    Transform _targetTransform;

    void LateUpdate()
    {
        var nextPosition = _targetTransform.position;

        nextPosition.y += _camHeight;
        nextPosition.z -= _camDistance;

        transform.position = nextPosition;
        transform.LookAt(_targetTransform);
    }
}
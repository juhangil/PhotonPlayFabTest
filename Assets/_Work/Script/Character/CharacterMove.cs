using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class CharacterMove : MonoBehaviour
{
    public void MoveToDirection(Vector3 direction)
    {
        direction = direction.normalized;

        _character.SimpleMove(direction * _speed);
    }

    [SerializeField]
    float _speed;

    CharacterController _character;

    void Awake()
    {
        _character = GetComponent<CharacterController>();
    }
}

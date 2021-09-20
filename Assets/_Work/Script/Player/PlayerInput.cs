using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterMove))]
public class PlayerInput : MonoBehaviour
{
    [SerializeField]
    CharacterMove _characterMove;

    void Update()
    {
        var forwardOffset = transform.forward * Input.GetAxisRaw("Vertical");
        var rightOffset = transform.right * Input.GetAxisRaw("Horizontal");
        var nextMove = (forwardOffset + rightOffset).normalized;

        _characterMove.MoveToDirection(nextMove);
    }
}
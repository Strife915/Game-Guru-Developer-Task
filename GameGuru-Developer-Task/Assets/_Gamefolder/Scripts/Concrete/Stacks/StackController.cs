using System.Collections;
using UnityEngine;
using Zenject;

public class StackController : MonoBehaviour
{
    [Inject] IMover _mover;

    IEnumerator Start()
    {
        _mover.Move();
        yield return new WaitForSeconds(2f);
        _mover.StopMovement();
    }
}
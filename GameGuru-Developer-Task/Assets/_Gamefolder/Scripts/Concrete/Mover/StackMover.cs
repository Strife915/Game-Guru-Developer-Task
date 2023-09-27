using UnityEngine;

public class StackMover :  IMover
{
    public void Move()
    {
        Debug.Log("Moving");   
    }

    public void StopMovement()
    {
        Debug.Log("Stop movement");
    }
}

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wait : TaskBT
{
    private float ElapsedTime { get; set; } = 0;
    private float SecondsToWait { get; set; } = 0;

    public Wait(float secondsToWait) => SecondsToWait = secondsToWait;

    //On tient pour acquis qu'Execute va être appeler à chaque frame
    public override TaskState Execute()
    {
        ElapsedTime += Time.deltaTime;

        if (ElapsedTime > SecondsToWait)
        {
            ElapsedTime = 0;
            return TaskState.Success;
        }

        return TaskState.Running;
    }
}
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task3 : TaskBluePrint
{
    public static Task3 instance {get; set;} = new Task3();
    public int numberOfJumps = 0 , totalJumps = 5;

    void Awake()
    {
        MakeInstance();
    }
    public override void StartTask()
    {
        TaskName = "Jumping";
        TaskDescription = "Use the space bar to make the player jump 5 times";
        TaskCompleted = false;
        text.text = TaskName + "\n" + "\n" + TaskDescription;
        StartCoroutine(TextVanish(text));
    }

    public override void UpdateTask()
    {

        if(numberOfJumps == totalJumps){
            TaskCompleted = true;
        }
    }

    public override void EndTask()
    {
        text.text = completedMessage;
    }

    public void MakeInstance(){
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }
}

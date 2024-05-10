using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task1 : TaskBluePrint
{
    public static Task1 instance {get; set;} = new Task1();
    public PlayerMovementScript playerMovementScript;
    private float time = 0f;

    void Awake()
    {
        MakeInstance();
    }
    public override void StartTask()
    {
        TaskName = "Move the Player";
        TaskDescription = "Use the WASD to move the player around the scene";
        TaskCompleted = false; 
        text.text = TaskName + "\n" + "\n" + TaskDescription;
        StartCoroutine(TextVanish(text));
    }

    public override void UpdateTask()
    {
        if(playerMovementScript.GetComponent<Rigidbody>().velocity != Vector3.zero){
            time += Time.deltaTime;
        }
        if(time > 10f){
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

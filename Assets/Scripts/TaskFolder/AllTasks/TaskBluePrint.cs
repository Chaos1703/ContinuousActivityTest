using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class TaskBluePrint : MonoBehaviour
{
    public abstract void StartTask();
    public abstract void UpdateTask();    
    public abstract void EndTask();
    protected string TaskName;
    protected string TaskDescription;
    public bool TaskCompleted;
    protected string completedMessage = "Task Completed!";
    public TextMeshProUGUI text;

    public IEnumerator TextVanish(TextMeshProUGUI text)
    {
        yield return new WaitForSeconds(3f);
        text.text = "";
    }
}

using System.Linq;
using System.Reflection;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public List<TaskBluePrint> taskQueue;
    public TaskBluePrint currentTask;
    public static TaskManager instance;
    private int taskCount = 0; private bool wait;

    void Awake()
    {
        MakeInstance();
        taskQueue = new List<TaskBluePrint>();
        wait = false;
    }

    void Start()
    {
        AddTasks();
        StartNextTask();
    }
    void Update()
    {
        if (currentTask != null)
        {
            currentTask.UpdateTask();
            if (currentTask.TaskCompleted && !wait)
            {
                currentTask.EndTask();
                StartCoroutine(NewTaskStart());
            }
        }
    }

    public void StartNextTask()
    {
        if(taskCount < taskQueue.Count)
        {
            currentTask = taskQueue[taskCount];
            currentTask.StartTask();
            taskCount++;
        }
        else
        {
            currentTask = null;
        }
    }

    public void AddTasks()
{
    // Get the assembly that contains the TaskBluePrint class
    var assembly = typeof(TaskBluePrint).Assembly;

    // Get all types derived from TaskBluePrint
    var derivedTypes = assembly.GetTypes().Where(t => t.IsSubclassOf(typeof(TaskBluePrint)));

    // Create an instance of each derived type and add it to the taskQueue
    foreach (var type in derivedTypes)
    {
        var instanceProperty = type.GetProperty("instance", BindingFlags.Public | BindingFlags.Static);
        Debug.Log(instanceProperty);
        Debug.Log(type);
        if (instanceProperty != null)
        {
            var instance = (TaskBluePrint)instanceProperty.GetValue(null);
            taskQueue.Add(instance);
        }
    }
}

    void MakeInstance(){
        if(instance == null)
        {
            instance = this;
        }
        else if(instance != this)
        {
            Destroy(this.gameObject);
        }
    }

    IEnumerator NewTaskStart(){
        wait = true;
        yield return new WaitForSeconds(1.5f);
        wait = false;
        StartNextTask();
    }
}

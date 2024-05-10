using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task2 : TaskBluePrint
{
    public static Task2 instance {get; set;} = new Task2();
    public GameObject coin;
    [HideInInspector]
    public int coinsCollected = 0 , totalCoins = 5;

    void Awake()
    {
        MakeInstance();
    }
    public override void StartTask()
    {
        TaskName = "Collect Coins";
        TaskDescription = "Collect all the coins in the scene";
        TaskCompleted = false;
        CoinSpawn();
        text.text = TaskName + "\n" + "\n" + TaskDescription;
        StartCoroutine(TextVanish(text));
    }

    public override void UpdateTask()
    {
        if(coinsCollected == totalCoins){
            TaskCompleted = true;
        }
    }

    public override void EndTask()
    {
        text.text = completedMessage;
    }

    void CoinSpawn()
    {
        for (int i = 0; i < totalCoins; i++)
        {
            Instantiate(coin, new Vector3(Random.Range(-4.08f, 15.07f), 0.409f, Random.Range(-4.4f, 14.48f)), Quaternion.identity);
        }
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

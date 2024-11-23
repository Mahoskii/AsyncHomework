using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class AsyncTesting : MonoBehaviour
{
    private Task[] tasks = new Task[] { PrintAnotherSomething(), PrintFromInsideAsyncTask() };
    async void Start()
    {
        Debug.Log("I come brefore the funtion");
        PrintSomething();
        await PrintAnotherSomething();
        Debug.Log("I come after the function");
        await Task.WhenAll(tasks);
        Debug.Log("We done printin' and greetin'");
    }

    private static async void PrintSomething()
    {
        Debug.Log("Hello from inside the function!");
        await Task.Delay(2000);
    }

    private static async Task PrintAnotherSomething()
    {
        Debug.Log("I'm printing another something");
        await Task.Delay(5000);
        Debug.Log("I'm done printing another something");
        await PrintFromInsideAsyncTask();
    }

    private static async Task PrintFromInsideAsyncTask()
    {
        PrintSomething();
        Debug.Log("I'm printing from a function inside a function");
        await Task.Delay(3000);
        Debug.Log("I'm done printing from a function inside a function.");
        
    }
 
}

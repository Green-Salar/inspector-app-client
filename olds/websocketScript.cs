using System.Collections;
using System.Collections.Generic;
using System;
using System.Linq;
using System.Threading.Tasks;
using UnityEngine;

public class websocketScript : MonoBehaviour
{
    // Start is called before the first frame update
    public async void go()
    {
        
        await foreach (int n in GenerateNumbersAsync(5))
        {
            Debug.Log(n);
            Debug.Log(" ");
        }
        Debug.Log("hihohaaa");
        return ;
    }

    private async IAsyncEnumerable<int> GenerateNumbersAsync(int count)
    {
        for (int i = 0; i < count; i++)
        {
            yield return await ProduceNumberAsync(i);
        }
    }

    private async Task<int> ProduceNumberAsync(int seed)
    {
        await Task.Delay(1000);
        return 2 * seed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }



}

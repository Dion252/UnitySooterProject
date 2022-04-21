using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Counter : MonoBehaviour
{
    Text text;

    int count = 0;


    // Start is called before the first frame update
    void Start()
    {

        text = GetComponent<Text>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddForKill()
    {

        count = count + 1;

        text.text = $"{count}";

    }

}

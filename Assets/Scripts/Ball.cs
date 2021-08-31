using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{
    public int id;
    void update()
    {

        if (id == 0)
        {
            Debug.Log("id 0 hit");
        }
        else if (id == 1)
        {
            Debug.Log("id 1 hit");
        }
    }
}

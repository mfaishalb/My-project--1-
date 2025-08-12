using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireManager : MonoBehaviour
{
    public Transform[] rightTargets;

    void Start()
    {
        ShuffleTargets();
    }

    void ShuffleTargets()
    {
        for (int i = 0; i < rightTargets.Length; i++)
        {
            int rand = Random.Range(i, rightTargets.Length);
            Vector3 tempPos = rightTargets[i].position;
            rightTargets[i].position = rightTargets[rand].position;
            rightTargets[rand].position = tempPos;
        }
    }
}


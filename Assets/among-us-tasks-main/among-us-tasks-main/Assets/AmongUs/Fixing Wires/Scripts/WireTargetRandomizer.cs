using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WireTargetRandomizer : MonoBehaviour
{
    public Transform[] targets; // semua WireTarget kanan

    void Start()
    {
        ShufflePositions();
    }

    void ShufflePositions()
    {
        // simpan posisi awal
        Vector3[] startPos = new Vector3[targets.Length];
        for (int i = 0; i < targets.Length; i++)
        {
            startPos[i] = targets[i].position;
        }

        // acak urutan
        for (int i = 0; i < targets.Length; i++)
        {
            int rnd = Random.Range(0, targets.Length);
            Vector3 temp = targets[i].position;
            targets[i].position = targets[rnd].position;
            targets[rnd].position = temp;
        }
    }
}
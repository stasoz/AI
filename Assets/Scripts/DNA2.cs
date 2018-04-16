﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DNA2 : MonoBehaviour {

    List<int> genes = new List<int>();
    int dnaLength = 0;
    int maxValues = 0;

    public DNA2(int l,int v)
    {
        dnaLength = l;
        maxValues = v;
        SetRandom();
    }
    public void SetRandom()
    {
        genes.Clear();
        for(int i=0;i<dnaLength;i++)
        {
            genes.Add(Random.Range(-maxValues, maxValues));
        }
    }
    public void Combine(DNA2 d1,DNA2 d2)
    {
        for(int i=0;i<dnaLength;i++)
        {
            genes[i] = Random.Range(0, 10) < 5 ? d1.genes[i] : d2.genes[i];
        }
    }
    public void Mutate()
    {
        genes[Random.Range(0, dnaLength)] = Random.Range(-maxValues, maxValues);
    }
    public int GetGene(int pos)
    {
        return genes[pos];
    }
}

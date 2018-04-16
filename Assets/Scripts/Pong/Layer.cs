using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Layer : MonoBehaviour {

    public int numNeurons;
    public List<Neyron> neurons = new List<Neyron>();

    public Layer(int nNeurons, int numNeuronInputs)
    {
        numNeurons = nNeurons;
        for (int i = 0; i < nNeurons; i++)
        {
            neurons.Add(new Neyron(numNeuronInputs));
        }
    }
}

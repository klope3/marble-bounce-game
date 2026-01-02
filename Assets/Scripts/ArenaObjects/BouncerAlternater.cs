using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerAlternater : MonoBehaviour
{
    [SerializeField] private Bouncer[] bouncerObjects;
    [SerializeField] private int activeBouncers;
    [SerializeField] private float changeInterval;
    private float timer;

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer > changeInterval)
        {
            int[] bouncerIndices = Utils.GetConsecutiveInts(0, bouncerObjects.Length);
            int[] randomIndices = Utils.ChooseRandomFromCollection(bouncerIndices, activeBouncers);
            bool[] activeStates = new bool[bouncerObjects.Length];
            foreach (int i in randomIndices)
            {
                activeStates[i] = true;
            }
            for (int i = 0; i < activeStates.Length; i++)
            {
                bouncerObjects[i].SetActiveState(activeStates[i]);
            }

            timer = 0;
        }
    }
}

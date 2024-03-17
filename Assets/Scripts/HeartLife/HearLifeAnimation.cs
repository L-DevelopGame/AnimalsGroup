using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearLifeAnimation : MonoBehaviour
{
    [SerializeField]
    private float minValue = 0.1f; // Min value for scaling

    [SerializeField]
    private float maxValue = 2f; // Max value for scaling

    void Update()
    {
        // Calculate the scaled value based on time and the min/max range
        float scaledValue = Mathf.Abs(Mathf.Sin(Time.time));
        float mappedScale = Map(scaledValue, 0f, 1f, minValue, maxValue);

        // Apply the scale to the object
        transform.localScale = new Vector3(mappedScale, mappedScale, 1);
    }

    // Map function to map one range of values to another
    float Map(float value, float inMin, float inMax, float outMin, float outMax)
    {
        return (value - inMin) * (outMax - outMin) / (inMax - inMin) + outMin;
    }
}

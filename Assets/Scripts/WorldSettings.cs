using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldSettings : MonoBehaviour
{
    public enum Bodies
    {
        Earth,
        Moon
    }

    public Bodies CelestialBody;

    private void Update()
    {
        switch (CelestialBody)
        {
            case Bodies.Earth:
                Physics.gravity = new Vector3(0, -9.81f, 0);
                break;
            case Bodies.Moon:
                Physics.gravity = new Vector3(0, -1.621f, 0);
                break;
        }

    }
}
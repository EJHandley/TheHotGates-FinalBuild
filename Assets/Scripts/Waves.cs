using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waves : MonoBehaviour
{

    [System.Serializable]
    public static class Wave
    {
        [System.Serializable]
        public class WaveGroup
        {
            public string name;
            public Transform enemy;
            public int count;
            public float rate;
        }
    }

}

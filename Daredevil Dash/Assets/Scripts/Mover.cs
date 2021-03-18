using System;

using UnityEngine;

namespace DaredevilDash
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float xValue = 1.0f;
        [SerializeField] private float yValue = 1.0f;
        [SerializeField] private float zValue = 1.0f;

        // Update is called once per frame
        public void Update()
        {
            var y = (float) Math.Sin(Time.time) * yValue;
            var x = xValue * Time.deltaTime;
            var z = zValue * Time.deltaTime;
            
            transform.Translate(x, y, z);
        }
    }
}

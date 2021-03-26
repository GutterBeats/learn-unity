using UnityEngine;

namespace DaredevilDash
{
    public class ObjectHit : MonoBehaviour
    {
        private void OnCollisionEnter(Collision other)
        {
            UpdateColor(Color.red);
        }

        private void OnCollisionExit(Collision other)
        {
            UpdateColor(Color.white);
        }

        private void UpdateColor(Color color)
        {
            var mesh = GetComponent<MeshRenderer>();
            mesh.material.color = color;
        }
    }
}

using UnityEngine;

namespace DaredevilDash
{
    public class Mover : MonoBehaviour
    {
        [SerializeField] private float moveSpeed = 1.0f;
        [SerializeField] private float rotationSpeed = 1.0f;
        
        // Update is called once per frame
        public void Update()
        {
            MovePlayer();
        }

        private void MovePlayer()
        {
            var movementThisFrame = moveSpeed * Time.deltaTime;
            var rotationThisFrame = rotationSpeed * Time.deltaTime;

            var zValue = Input.GetAxis("Vertical") * movementThisFrame;
            var yValue = Input.GetAxis("Horizontal") * rotationThisFrame;

            transform.Translate(0, 0, zValue);
            transform.Rotate(0, yValue, 0);
        }
    }
}

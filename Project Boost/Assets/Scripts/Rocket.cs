using UnityEngine;

namespace ProjectBoost
{
    public class Rocket : MonoBehaviour
    {
        private Rigidbody _rigidbody;

        // Use this for initialization
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        private void Update()
        {
            ProcessInput();
        }

        private void ProcessInput()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _rigidbody.AddRelativeForce(Vector3.up);
            }

            if (Input.GetKey(KeyCode.A))
            {

            }
            else if (Input.GetKey(KeyCode.D))
            {

            }
        }
    }
}

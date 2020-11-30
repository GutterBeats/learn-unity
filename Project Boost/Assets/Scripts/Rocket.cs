using UnityEngine;

namespace ProjectBoost
{
    public class Rocket : MonoBehaviour
    {
        private Rigidbody _rigidbody;
        private AudioSource _audio;

        // Use this for initialization
        private void Start()
        {
            _rigidbody = GetComponent<Rigidbody>();
            _audio = GetComponent<AudioSource>();
        }

        // Update is called once per frame
        private void Update()
        {
            Thrust();
            Rotate();
        }

        private void Thrust()
        {
            if (Input.GetKey(KeyCode.Space))
            {
                _rigidbody.AddRelativeForce(Vector3.up);

                _audio.mute = false;
            }
            else _audio.mute = true;
        }

        private void Rotate()
        {
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-Vector3.forward);
            }
        }
    }
}

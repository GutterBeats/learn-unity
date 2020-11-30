using UnityEngine;

namespace ProjectBoost
{
    public class Rocket : MonoBehaviour
    {
        [SerializeField]
        private float rcsThrust = 100f;

        [SerializeField]
        private float mainThrust = 100f;

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
            float thrustThisFrame = mainThrust * Time.deltaTime;
            if (Input.GetKey(KeyCode.Space))
            {
                _rigidbody.AddRelativeForce(Vector3.up * thrustThisFrame);

                _audio.mute = false;
            }
            else _audio.mute = true;
        }

        private void Rotate()
        {
            _rigidbody.freezeRotation = true;

            float rotationThisFrame = rcsThrust * Time.deltaTime;
            if (Input.GetKey(KeyCode.A))
            {
                transform.Rotate(Vector3.forward * rotationThisFrame);
            }
            else if (Input.GetKey(KeyCode.D))
            {
                transform.Rotate(-Vector3.forward * rotationThisFrame);
            }

            _rigidbody.freezeRotation = false;
        }
    }
}

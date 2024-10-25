using System;
using UnityEngine;

namespace Sid.Scripts.Gameplay
{
    public class MeteorLogic : MonoBehaviour
    {
        [SerializeField] private Vector3 directionOfMotion = Vector3.back;
        [SerializeField] private float directionalSpeed = 1;

        private void FixedUpdate()
        {
            transform.position += directionOfMotion * (directionalSpeed * Time.deltaTime);
        }
    }
}

using Sid.Scripts.GlobalStuff;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.Gameplay
{
    public class PlayerLogic : MonoBehaviour
    {
        private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Meteor"))
            {
                GlobalVariables.GameFailed = true;
                SceneManager.LoadScene("Scenes/Sid/End");
            }
        }
    }
}

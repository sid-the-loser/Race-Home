using System;
using Sid.Scripts.GlobalStuff;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.MainMenu
{
    public class MainMenuController : MonoBehaviour
    {
        [Header("Camera and Related")]
        [SerializeField] private GameObject mainCamera;
        [SerializeField] private float rotationAnimationSpeed;

        [Header("Menu Audio")] 
        [SerializeField] private AudioSource clickSounds;

        [SerializeField] private float buttonDelay = 0.1f;
        
        [Header("Menu and Related")]
        [SerializeField] private GameObject[] menuArray;
        [SerializeField] private int currentMenu;

        private Vector3 _initialCameraRotation;
        private float _currentY;

        private void Start()
        {
            _initialCameraRotation = mainCamera.transform.rotation.eulerAngles;
            mainCamera.transform.rotation = Quaternion.Euler(_initialCameraRotation.x, 0, _initialCameraRotation.z);
            UpdateCurrentMenu();
            GlobalVariables.Difficulty = 0;
            GlobalVariables.GameFailed = false; // instead, i could put this in a game object that handles something in
                                                // the gameplay scene
        }

        private void Update()
        {
            _currentY += rotationAnimationSpeed * Time.deltaTime;
            mainCamera.transform.rotation = Quaternion.Euler(_initialCameraRotation.x, _currentY, 
                _initialCameraRotation.z);
        }

        public void SetCurrentMenu(int index)
        {
            currentMenu = index;
            UpdateCurrentMenu();
        }

        private void UpdateCurrentMenu()
        {
            clickSounds.Play();
            foreach (var menu in menuArray)
            {
                menu.SetActive(false);
            }
            menuArray[currentMenu].SetActive(true);
        }

        private void StartStory()
        {
            SceneManager.LoadScene("Scenes/Sid/Start");
        }

        public void QuitButtonLogic()
        {
            clickSounds.Play();
            Application.Quit();
        }

        public void EasyButtonLogic()
        {
            clickSounds.Play();
            GlobalVariables.Difficulty = 0;
            Invoke(nameof(StartStory), buttonDelay);
        }

        public void NormalButtonLogic()
        {
            clickSounds.Play();
            GlobalVariables.Difficulty = 1;
            Invoke(nameof(StartStory), buttonDelay);
        }

        public void HardButtonLogic()
        {
            clickSounds.Play();
            GlobalVariables.Difficulty = 2;
            Invoke(nameof(StartStory), buttonDelay);
        }
    }
}

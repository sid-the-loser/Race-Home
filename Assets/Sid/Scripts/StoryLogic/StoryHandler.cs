using System;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Sid.Scripts.StoryLogic
{
    public class StoryHandler : MonoBehaviour
    {

        [SerializeField] private bool storyStart;
        [SerializeField] private StoryBlock[] storyBlocks;
        [SerializeField] private AudioSource clickSound;

        private int _currentStoryBlock = 0;

        private void Start()
        {
            UpdateStoryBlock(true);
            clickSound.mute = true;
        }

        public void NextButtonLogic()
        {
            clickSound.mute = false;
            if (clickSound is not null) clickSound.Play();
            if (_currentStoryBlock < storyBlocks.Length - 1)
            {
                _currentStoryBlock++;
                UpdateStoryBlock();
            }
            else
            {
                SceneManager.LoadScene(storyStart ? "Scenes/Sid/Gameplay" : "Scenes/Sid/MainMenu");
            }
        }

        private void UpdateStoryBlock(bool force=false)
        {
            foreach (var block in storyBlocks)
            {
                block.currentCard = false;
            }

            storyBlocks[_currentStoryBlock].currentCard = true;
        }
    }
}

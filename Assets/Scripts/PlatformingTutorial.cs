using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

namespace EnterKratos
{
    public class PlatformingTutorial : MonoBehaviour
    {
        [SerializeField]
        private List<YarnCharacter> characters;

        private DialogueRunner _dialogueRunner;

        public void SetDialogueSystem(GameObject obj)
        {
            var characterView = obj.GetComponentInChildren<YarnCharacterView>();
            foreach (var character in characters)
            {
                characterView.AddCharacter(character);
            }

            _dialogueRunner = obj.GetComponentInChildren<DialogueRunner>();
        }

        public void StartDialogue(string startNode)
        {
            _dialogueRunner.Stop();
            _dialogueRunner.StartDialogue(startNode);
        }
    }
}
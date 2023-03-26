using System.Collections.Generic;
using UnityEngine;
using Yarn.Unity;
using Yarn.Unity.Example;

namespace EnterKratos.Tutorials
{
    public class TutorialBase : MonoBehaviour
    {
        [SerializeField]
        private DialogueRunner dialogueRunner;

        [SerializeField]
        private List<YarnCharacter> characters;

        public void SetDialogueSystem(GameObject obj)
        {
            var characterView = obj.GetComponentInChildren<YarnCharacterView>();
            foreach (var character in characters)
            {
                characterView.AddCharacter(character);
            }

            dialogueRunner = obj.GetComponentInChildren<DialogueRunner>();
        }

        public void StartDialogue(string startNode)
        {
            dialogueRunner.Stop();
            dialogueRunner.StartDialogue(startNode);
        }
    }
}
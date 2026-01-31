using UnityEngine;

namespace UniGit.AIAssistant.Runtime
{
    /// <summary>
    /// Runtime component for AI-assisted GameObjects
    /// Can be attached to objects for dynamic behavior
    /// </summary>
    public class AIAssistantComponent : MonoBehaviour
    {
        [Header("AI Assistant Info")]
        [TextArea(3, 5)]
        public string generationPrompt = "Created by AI Assistant";
        
        [SerializeField] private bool showGizmos = true;
        [SerializeField] private Color gizmoColor = Color.cyan;

        private void OnDrawGizmos()
        {
            if (!showGizmos) return;

            Gizmos.color = gizmoColor;
            Gizmos.DrawWireSphere(transform.position, 0.5f);
        }

        /// <summary>
        /// Called by AI Assistant when object is created
        /// </summary>
        public void OnAICreated(string prompt)
        {
            generationPrompt = prompt;
            Debug.Log($"AI Assistant created: {gameObject.name} with prompt: {prompt}");
        }
    }
}

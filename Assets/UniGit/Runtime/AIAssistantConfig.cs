using System;
using UnityEngine;

namespace UniGit.Runtime
{
    /// <summary>
    /// Configuration settings for the AI Assistant
    /// </summary>
    [CreateAssetMenu(fileName = "AIAssistantConfig", menuName = "UniGit/AI Assistant Config")]
    public class AIAssistantConfig : ScriptableObject
    {
        [Header("API Settings")]
        [Tooltip("The API endpoint URL for AI communication")]
        public string apiEndpoint = "https://api.openai.com/v1/chat/completions";
        
        [Tooltip("Your API key for authentication")]
        public string apiKey = "";
        
        [Header("Model Settings")]
        [Tooltip("The AI model to use (e.g., gpt-4, gpt-3.5-turbo)")]
        public string model = "gpt-3.5-turbo";
        
        [Range(0f, 2f)]
        [Tooltip("Controls randomness in responses (0=focused, 2=creative)")]
        public float temperature = 0.7f;
        
        [Range(1, 4000)]
        [Tooltip("Maximum tokens in the response")]
        public int maxTokens = 2000;
        
        [Header("Context Settings")]
        [Tooltip("System prompt that defines the assistant's behavior")]
        [TextArea(3, 10)]
        public string systemPrompt = "You are a helpful Unity development assistant. You help with scripting, scene setup, asset management, and general Unity questions.";
        
        [Tooltip("Include Unity project context in requests")]
        public bool includeProjectContext = true;
        
        [Tooltip("Include scene information in requests")]
        public bool includeSceneContext = true;
    }
}

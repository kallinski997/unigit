using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Networking;

namespace UniGit.Runtime
{
    /// <summary>
    /// Core service for communicating with AI API
    /// </summary>
    public class AIAssistantService
    {
        private AIAssistantConfig config;
        private List<ChatMessage> conversationHistory;

        public AIAssistantService(AIAssistantConfig config)
        {
            this.config = config;
            this.conversationHistory = new List<ChatMessage>();
            
            // Add system message
            if (!string.IsNullOrEmpty(config.systemPrompt))
            {
                conversationHistory.Add(new ChatMessage
                {
                    role = "system",
                    content = config.systemPrompt
                });
            }
        }

        /// <summary>
        /// Send a message to the AI and get a response
        /// </summary>
        public async Task<string> SendMessageAsync(string userMessage, string context = null)
        {
            try
            {
                // Build the full message with context
                string fullMessage = userMessage;
                if (!string.IsNullOrEmpty(context))
                {
                    fullMessage = $"Context:\n{context}\n\nUser Question:\n{userMessage}";
                }

                // Add user message to history
                conversationHistory.Add(new ChatMessage
                {
                    role = "user",
                    content = fullMessage
                });

                // Create request payload
                var requestData = new ChatCompletionRequest
                {
                    model = config.model,
                    messages = conversationHistory.ToArray(),
                    temperature = config.temperature,
                    max_tokens = config.maxTokens
                };

                string jsonRequest = JsonUtility.ToJson(requestData);
                
                // Send request
                byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonRequest);
                
                using (UnityWebRequest request = new UnityWebRequest(config.apiEndpoint, "POST"))
                {
                    request.uploadHandler = new UploadHandlerRaw(bodyRaw);
                    request.downloadHandler = new DownloadHandlerBuffer();
                    request.SetRequestHeader("Content-Type", "application/json");
                    request.SetRequestHeader("Authorization", $"Bearer {config.apiKey}");

                    // Send and await completion using TaskCompletionSource
                    var tcs = new TaskCompletionSource<bool>();
                    var operation = request.SendWebRequest();
                    operation.completed += _ => tcs.SetResult(true);
                    await tcs.Task;

                    if (request.result == UnityWebRequest.Result.Success)
                    {
                        string responseText = request.downloadHandler.text;
                        var response = JsonUtility.FromJson<ChatCompletionResponse>(responseText);
                        
                        if (response != null && response.choices != null && response.choices.Length > 0)
                        {
                            string assistantMessage = response.choices[0].message.content;
                            
                            // Add assistant response to history
                            conversationHistory.Add(new ChatMessage
                            {
                                role = "assistant",
                                content = assistantMessage
                            });
                            
                            return assistantMessage;
                        }
                        
                        return "Error: No response from AI";
                    }
                    else
                    {
                        return $"Error: {request.error}\n{request.downloadHandler.text}";
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Exception: {ex.Message}";
            }
        }

        /// <summary>
        /// Clear conversation history
        /// </summary>
        public void ClearHistory()
        {
            conversationHistory.Clear();
            
            // Re-add system message
            if (!string.IsNullOrEmpty(config.systemPrompt))
            {
                conversationHistory.Add(new ChatMessage
                {
                    role = "system",
                    content = config.systemPrompt
                });
            }
        }

        /// <summary>
        /// Get conversation history
        /// </summary>
        public List<ChatMessage> GetHistory()
        {
            return new List<ChatMessage>(conversationHistory);
        }
    }

    [Serializable]
    public class ChatMessage
    {
        public string role;
        public string content;
    }

    [Serializable]
    public class ChatCompletionRequest
    {
        public string model;
        public ChatMessage[] messages;
        public float temperature;
        public int max_tokens;
    }

    [Serializable]
    public class ChatCompletionResponse
    {
        public Choice[] choices;
    }

    [Serializable]
    public class Choice
    {
        public ChatMessage message;
    }
}

using UnityEngine;
using UnityEditor;
using UniGit.Runtime;
using System.Collections.Generic;

namespace UniGit.Editor
{
    /// <summary>
    /// Main Editor Window for AI Assistant interaction
    /// </summary>
    public class AIAssistantWindow : EditorWindow
    {
        private AIAssistantConfig config;
        private AIAssistantService service;
        private Vector2 scrollPosition;
        private Vector2 configScrollPosition;
        private string userInput = "";
        private List<ConversationEntry> conversation = new List<ConversationEntry>();
        private bool isProcessing = false;
        private bool showConfig = false;
        private string configPath = "Assets/UniGit/Resources/AIAssistantConfig.asset";

        [MenuItem("Window/UniGit/AI Assistant")]
        public static void ShowWindow()
        {
            var window = GetWindow<AIAssistantWindow>("AI Assistant");
            window.minSize = new Vector2(400, 300);
            window.Show();
        }

        private void OnEnable()
        {
            LoadOrCreateConfig();
            InitializeService();
        }

        private void LoadOrCreateConfig()
        {
            // Try to load existing config
            config = Resources.Load<AIAssistantConfig>("AIAssistantConfig");
            
            if (config == null)
            {
                // Create default config
                config = ScriptableObject.CreateInstance<AIAssistantConfig>();
                
                // Try to save it
                string resourcesPath = "Assets/UniGit/Resources";
                if (!AssetDatabase.IsValidFolder(resourcesPath))
                {
                    string fullPath = System.IO.Path.Combine(Application.dataPath, "UniGit", "Resources");
                    System.IO.Directory.CreateDirectory(fullPath);
                    AssetDatabase.Refresh();
                }
                
                try
                {
                    AssetDatabase.CreateAsset(config, configPath);
                    AssetDatabase.SaveAssets();
                    Debug.Log($"Created new AI Assistant config at {configPath}");
                }
                catch (System.Exception ex)
                {
                    Debug.LogWarning($"Could not save config asset: {ex.Message}");
                }
            }
        }

        private void InitializeService()
        {
            if (config != null)
            {
                service = new AIAssistantService(config);
                conversation.Clear();
                conversation.Add(new ConversationEntry
                {
                    role = "system",
                    message = "AI Assistant initialized. How can I help you with Unity today?",
                    timestamp = System.DateTime.Now
                });
            }
        }

        private void OnGUI()
        {
            EditorGUILayout.BeginVertical();
            
            // Header
            DrawHeader();
            
            // Main content area
            if (showConfig)
            {
                DrawConfigPanel();
            }
            else
            {
                DrawChatPanel();
            }
            
            EditorGUILayout.EndVertical();
        }

        private void DrawHeader()
        {
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            
            GUILayout.Label("UniGit AI Assistant", EditorStyles.boldLabel);
            
            GUILayout.FlexibleSpace();
            
            if (GUILayout.Button(showConfig ? "Chat" : "Settings", EditorStyles.toolbarButton, GUILayout.Width(70)))
            {
                showConfig = !showConfig;
            }
            
            if (GUILayout.Button("Clear", EditorStyles.toolbarButton, GUILayout.Width(50)))
            {
                conversation.Clear();
                if (service != null)
                {
                    service.ClearHistory();
                }
                conversation.Add(new ConversationEntry
                {
                    role = "system",
                    message = "Conversation cleared.",
                    timestamp = System.DateTime.Now
                });
            }
            
            EditorGUILayout.EndHorizontal();
        }

        private void DrawChatPanel()
        {
            // Conversation history
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.ExpandHeight(true));
            
            foreach (var entry in conversation)
            {
                DrawConversationEntry(entry);
            }
            
            EditorGUILayout.EndScrollView();
            
            // Input area
            EditorGUILayout.Space(5);
            EditorGUILayout.BeginHorizontal();
            
            EditorGUILayout.LabelField("Your message:", GUILayout.Width(100));
            
            GUI.enabled = !isProcessing;
            userInput = EditorGUILayout.TextField(userInput);
            
            if (GUILayout.Button(isProcessing ? "Sending..." : "Send", GUILayout.Width(80)) || ShouldSendMessageOnKeyPress())
            {
                SendMessage();
            }
            
            GUI.enabled = true;
            
            EditorGUILayout.EndHorizontal();
            EditorGUILayout.Space(5);
        }

        private bool ShouldSendMessageOnKeyPress()
        {
            return Event.current.type == EventType.KeyDown && 
                   Event.current.keyCode == KeyCode.Return && 
                   !string.IsNullOrWhiteSpace(userInput);
        }

        private void DrawConfigPanel()
        {
            configScrollPosition = EditorGUILayout.BeginScrollView(configScrollPosition);
            
            EditorGUILayout.Space(10);
            EditorGUILayout.LabelField("API Configuration", EditorStyles.boldLabel);
            EditorGUILayout.HelpBox("Configure your AI Assistant settings below. Make sure to set your API key.", MessageType.Info);
            
            EditorGUI.BeginChangeCheck();
            
            config.apiEndpoint = EditorGUILayout.TextField("API Endpoint", config.apiEndpoint);
            config.apiKey = EditorGUILayout.PasswordField("API Key", config.apiKey);
            
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Model Configuration", EditorStyles.boldLabel);
            
            config.model = EditorGUILayout.TextField("Model", config.model);
            config.temperature = EditorGUILayout.Slider("Temperature", config.temperature, 0f, 2f);
            config.maxTokens = EditorGUILayout.IntSlider("Max Tokens", config.maxTokens, 1, 4000);
            
            EditorGUILayout.Space(5);
            EditorGUILayout.LabelField("Context Settings", EditorStyles.boldLabel);
            
            config.systemPrompt = EditorGUILayout.TextArea(config.systemPrompt, GUILayout.Height(100));
            config.includeProjectContext = EditorGUILayout.Toggle("Include Project Context", config.includeProjectContext);
            config.includeSceneContext = EditorGUILayout.Toggle("Include Scene Context", config.includeSceneContext);
            
            if (EditorGUI.EndChangeCheck())
            {
                EditorUtility.SetDirty(config);
            }
            
            EditorGUILayout.Space(10);
            
            if (GUILayout.Button("Reinitialize Service"))
            {
                InitializeService();
                EditorUtility.DisplayDialog("Service Reinitialized", "AI Assistant service has been reinitialized with new settings.", "OK");
            }
            
            EditorGUILayout.EndScrollView();
        }

        private void DrawConversationEntry(ConversationEntry entry)
        {
            Color bgColor;
            switch (entry.role)
            {
                case "user":
                    bgColor = new Color(0.3f, 0.5f, 0.7f, 0.3f);
                    break;
                case "assistant":
                    bgColor = new Color(0.3f, 0.7f, 0.5f, 0.3f);
                    break;
                default:
                    bgColor = new Color(0.5f, 0.5f, 0.5f, 0.3f);
                    break;
            }
            
            var oldColor = GUI.backgroundColor;
            GUI.backgroundColor = bgColor;
            
            EditorGUILayout.BeginVertical(EditorStyles.helpBox);
            
            EditorGUILayout.BeginHorizontal();
            EditorGUILayout.LabelField($"{entry.role.ToUpper()} - {entry.timestamp:HH:mm:ss}", EditorStyles.boldLabel);
            EditorGUILayout.EndHorizontal();
            
            EditorGUILayout.LabelField(entry.message, EditorStyles.wordWrappedLabel);
            
            EditorGUILayout.EndVertical();
            
            GUI.backgroundColor = oldColor;
            
            EditorGUILayout.Space(5);
        }

        private async void SendMessage()
        {
            if (string.IsNullOrWhiteSpace(userInput) || isProcessing)
                return;

            if (service == null)
            {
                EditorUtility.DisplayDialog("Error", "AI Assistant service is not initialized. Please check your configuration.", "OK");
                return;
            }

            if (string.IsNullOrWhiteSpace(config.apiKey))
            {
                EditorUtility.DisplayDialog("API Key Required", "Please set your API key in the Settings panel before using the AI Assistant.", "OK");
                showConfig = true;
                return;
            }

            string message = userInput;
            userInput = "";
            isProcessing = true;
            
            // Add user message to conversation
            conversation.Add(new ConversationEntry
            {
                role = "user",
                message = message,
                timestamp = System.DateTime.Now
            });
            
            Repaint();
            
            // Get context if enabled
            string context = "";
            if (config.includeProjectContext || config.includeSceneContext)
            {
                context = UnityContextProvider.GetProjectContext(config.includeSceneContext);
            }
            
            // Send to AI
            string response = await service.SendMessageAsync(message, context);
            
            // Add assistant response to conversation
            conversation.Add(new ConversationEntry
            {
                role = "assistant",
                message = response,
                timestamp = System.DateTime.Now
            });
            
            isProcessing = false;
            Repaint();
            
            // Auto-scroll to bottom
            scrollPosition.y = float.MaxValue;
        }

        private class ConversationEntry
        {
            public string role;
            public string message;
            public System.DateTime timestamp;
        }
    }
}

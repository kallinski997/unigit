using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using System.Linq;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Main AI Assistant Editor Window for Unity
    /// Provides an interface for AI-powered level design and development assistance
    /// </summary>
    public class AIAssistantWindow : EditorWindow
    {
        private string promptInput = "";
        private Vector2 scrollPosition;
        private List<ConversationEntry> conversationHistory = new List<ConversationEntry>();
        private GUIStyle messageStyle;
        private GUIStyle userMessageStyle;
        private GUIStyle assistantMessageStyle;
        private bool stylesInitialized = false;

        [MenuItem("Window/AI Assistant")]
        public static void ShowWindow()
        {
            AIAssistantWindow window = GetWindow<AIAssistantWindow>("AI Assistant");
            window.minSize = new Vector2(400, 300);
            window.Show();
        }

        private void OnEnable()
        {
            conversationHistory = new List<ConversationEntry>();
            conversationHistory.Add(new ConversationEntry
            {
                isUser = false,
                message = "Welcome to the Unity AI Assistant! I can help you with:\n\n" +
                         "• Level Design - Create and arrange GameObjects\n" +
                         "• Scene Analysis - Optimize your scenes\n" +
                         "• Object Generation - Generate prefabs and materials\n" +
                         "• Code Snippets - Get Unity script examples\n" +
                         "• Best Practices - Unity development tips\n\n" +
                         "Type your request below and press Enter or click Submit."
            });
        }

        private void InitializeStyles()
        {
            if (stylesInitialized) return;

            messageStyle = new GUIStyle(EditorStyles.label)
            {
                wordWrap = true,
                richText = true,
                padding = new RectOffset(10, 10, 5, 5)
            };

            userMessageStyle = new GUIStyle(messageStyle)
            {
                normal = { background = MakeTexture(2, 2, new Color(0.3f, 0.5f, 0.8f, 0.3f)) }
            };

            assistantMessageStyle = new GUIStyle(messageStyle)
            {
                normal = { background = MakeTexture(2, 2, new Color(0.2f, 0.2f, 0.2f, 0.3f)) }
            };

            stylesInitialized = true;
        }

        private Texture2D MakeTexture(int width, int height, Color color)
        {
            Color[] pixels = new Color[width * height];
            for (int i = 0; i < pixels.Length; i++)
                pixels[i] = color;

            Texture2D texture = new Texture2D(width, height);
            texture.SetPixels(pixels);
            texture.Apply();
            return texture;
        }

        private void OnGUI()
        {
            InitializeStyles();

            EditorGUILayout.BeginVertical();

            // Header
            EditorGUILayout.BeginHorizontal(EditorStyles.toolbar);
            GUILayout.Label("Unity AI Assistant", EditorStyles.boldLabel);
            
            if (GUILayout.Button("Clear", EditorStyles.toolbarButton, GUILayout.Width(50)))
            {
                ClearConversation();
            }
            
            if (GUILayout.Button("Help", EditorStyles.toolbarButton, GUILayout.Width(50)))
            {
                ShowHelp();
            }
            EditorGUILayout.EndHorizontal();

            // Conversation History
            scrollPosition = EditorGUILayout.BeginScrollView(scrollPosition, GUILayout.ExpandHeight(true));
            
            foreach (var entry in conversationHistory)
            {
                DrawMessage(entry);
                GUILayout.Space(5);
            }
            
            EditorGUILayout.EndScrollView();

            // Input Area
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("Your Prompt:", EditorStyles.boldLabel);
            
            EditorGUILayout.BeginHorizontal();
            
            // Multi-line text input
            promptInput = EditorGUILayout.TextArea(promptInput, GUILayout.Height(60));
            
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.BeginHorizontal();
            
            GUILayout.FlexibleSpace();
            
            if (GUILayout.Button("Submit", GUILayout.Width(100), GUILayout.Height(30)) || 
                (Event.current.type == EventType.KeyDown && Event.current.keyCode == KeyCode.Return && Event.current.control))
            {
                ProcessPrompt();
            }
            
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();
            EditorGUILayout.EndVertical();
        }

        private void DrawMessage(ConversationEntry entry)
        {
            GUIStyle style = entry.isUser ? userMessageStyle : assistantMessageStyle;
            string prefix = entry.isUser ? "You: " : "AI: ";
            
            EditorGUILayout.BeginVertical(style);
            EditorGUILayout.LabelField(prefix + entry.message, messageStyle);
            EditorGUILayout.EndVertical();
        }

        private void ProcessPrompt()
        {
            if (string.IsNullOrWhiteSpace(promptInput))
                return;

            // Add user message
            conversationHistory.Add(new ConversationEntry
            {
                isUser = true,
                message = promptInput
            });

            // Process the prompt and generate response
            string response = GenerateResponse(promptInput);
            
            conversationHistory.Add(new ConversationEntry
            {
                isUser = false,
                message = response
            });

            promptInput = "";
            scrollPosition = new Vector2(0, float.MaxValue);
            Repaint();
        }

        private string GenerateResponse(string prompt)
        {
            string lowerPrompt = prompt.ToLower();

            // Level Design Commands
            if (lowerPrompt.Contains("create") || lowerPrompt.Contains("generate") || lowerPrompt.Contains("add"))
            {
                return HandleCreationRequest(prompt);
            }
            // Analysis Commands
            else if (lowerPrompt.Contains("analyze") || lowerPrompt.Contains("optimize") || lowerPrompt.Contains("check"))
            {
                return HandleAnalysisRequest(prompt);
            }
            // Code Generation
            else if (lowerPrompt.Contains("script") || lowerPrompt.Contains("code") || lowerPrompt.Contains("component"))
            {
                return HandleCodeRequest(prompt);
            }
            // Material/Shader requests
            else if (lowerPrompt.Contains("material") || lowerPrompt.Contains("shader") || lowerPrompt.Contains("texture"))
            {
                return HandleMaterialRequest(prompt);
            }
            // General help
            else
            {
                return HandleGeneralRequest(prompt);
            }
        }

        private string HandleCreationRequest(string prompt)
        {
            string response = "I can help you create objects in your scene!\n\n";

            if (prompt.ToLower().Contains("cube") || prompt.ToLower().Contains("würfel"))
            {
                LevelDesignHelper.CreatePrimitive(PrimitiveType.Cube, Vector3.zero);
                response += "✓ Created a Cube at the origin.\n\n";
            }
            else if (prompt.ToLower().Contains("sphere") || prompt.ToLower().Contains("kugel"))
            {
                LevelDesignHelper.CreatePrimitive(PrimitiveType.Sphere, Vector3.zero);
                response += "✓ Created a Sphere at the origin.\n\n";
            }
            else if (prompt.ToLower().Contains("plane") || prompt.ToLower().Contains("ebene"))
            {
                LevelDesignHelper.CreatePrimitive(PrimitiveType.Plane, Vector3.zero);
                response += "✓ Created a Plane at the origin.\n\n";
            }
            else if (prompt.ToLower().Contains("grid") || prompt.ToLower().Contains("raster"))
            {
                LevelDesignHelper.CreateObjectGrid(5, 5, 2f, PrimitiveType.Cube);
                response += "✓ Created a 5x5 grid of cubes with 2 unit spacing.\n\n";
            }
            else if (prompt.ToLower().Contains("light") || prompt.ToLower().Contains("licht"))
            {
                LevelDesignHelper.CreateLight(LightType.Directional, Vector3.up * 10);
                response += "✓ Created a Directional Light.\n\n";
            }

            response += "You can also ask me to:\n";
            response += "• Create specific primitives (cube, sphere, plane, cylinder, capsule)\n";
            response += "• Generate object grids\n";
            response += "• Add lights to your scene\n";
            response += "• Create empty parent objects for organization";

            return response;
        }

        private string HandleAnalysisRequest(string prompt)
        {
            var analysis = SceneAnalyzer.AnalyzeCurrentScene();
            
            string response = "Scene Analysis Results:\n\n";
            response += $"Total GameObjects: {analysis.totalObjects}\n";
            response += $"Active Objects: {analysis.activeObjects}\n";
            response += $"Inactive Objects: {analysis.inactiveObjects}\n";
            response += $"Lights: {analysis.lightCount}\n";
            response += $"Cameras: {analysis.cameraCount}\n";
            response += $"Missing References: {analysis.missingReferences}\n\n";

            if (analysis.missingReferences > 0)
            {
                response += "⚠ Warning: Found missing references in your scene!\n";
            }

            if (analysis.lightCount == 0)
            {
                response += "💡 Tip: Your scene has no lights. Consider adding lighting for better visualization.\n";
            }

            if (analysis.totalObjects > 1000)
            {
                response += "⚠ Performance: Your scene has many objects. Consider using object pooling or LOD systems.\n";
            }

            return response;
        }

        private string HandleCodeRequest(string prompt)
        {
            string response = "Here's a code snippet that might help:\n\n";

            if (prompt.ToLower().Contains("movement") || prompt.ToLower().Contains("move"))
            {
                response += CodeSnippets.GetMovementScript();
            }
            else if (prompt.ToLower().Contains("rotation") || prompt.ToLower().Contains("rotate"))
            {
                response += CodeSnippets.GetRotationScript();
            }
            else if (prompt.ToLower().Contains("trigger") || prompt.ToLower().Contains("collision"))
            {
                response += CodeSnippets.GetTriggerScript();
            }
            else
            {
                response += CodeSnippets.GetBasicScript();
            }

            response += "\n\nYou can copy this code and create a new script in your project.";
            return response;
        }

        private string HandleMaterialRequest(string prompt)
        {
            string response = "Material & Shader Information:\n\n";
            
            response += "I can help you with:\n";
            response += "• Creating basic materials\n";
            response += "• Applying colors to objects\n";
            response += "• Setting up PBR materials\n";
            response += "• Understanding shader properties\n\n";

            if (prompt.ToLower().Contains("create"))
            {
                var mat = MaterialHelper.CreateBasicMaterial("NewMaterial", Color.white);
                response += $"✓ Created a new material: {mat.name}\n";
                response += "You can find it in your project and apply it to objects.";
            }
            else
            {
                response += "Ask me to 'create a material' to generate a new one!";
            }

            return response;
        }

        private string HandleGeneralRequest(string prompt)
        {
            return "I'm here to help with Unity development!\n\n" +
                   "Try asking me to:\n" +
                   "• 'Create a cube' or 'Generate a grid of objects'\n" +
                   "• 'Analyze the scene' to get optimization tips\n" +
                   "• 'Show me a movement script'\n" +
                   "• 'Create a material'\n" +
                   "• 'Add a light to the scene'\n\n" +
                   "What would you like to do?";
        }

        private void ClearConversation()
        {
            conversationHistory.Clear();
            OnEnable();
        }

        private void ShowHelp()
        {
            conversationHistory.Add(new ConversationEntry
            {
                isUser = false,
                message = "AI Assistant Help:\n\n" +
                         "Commands you can use:\n" +
                         "• Level Design: 'create cube', 'generate grid', 'add light'\n" +
                         "• Analysis: 'analyze scene', 'optimize', 'check performance'\n" +
                         "• Code: 'movement script', 'rotation code', 'trigger example'\n" +
                         "• Materials: 'create material', 'shader help'\n\n" +
                         "Keyboard Shortcuts:\n" +
                         "• Ctrl+Enter: Submit prompt\n" +
                         "• Clear button: Reset conversation"
            });
            
            scrollPosition = new Vector2(0, float.MaxValue);
            Repaint();
        }

        private class ConversationEntry
        {
            public bool isUser;
            public string message;
        }
    }
}

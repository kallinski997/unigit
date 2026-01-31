using UnityEngine;
using UnityEditor;
using UniGit.Runtime;

namespace UniGit.Editor
{
    /// <summary>
    /// Editor utilities for AI Assistant
    /// </summary>
    public static class AIAssistantEditorUtils
    {
        [MenuItem("Assets/Create/UniGit/AI Assistant Config")]
        public static void CreateAIAssistantConfig()
        {
            var config = ScriptableObject.CreateInstance<AIAssistantConfig>();
            
            string path = "Assets/AIAssistantConfig.asset";
            
            // If called from context menu, use selected folder
            if (Selection.activeObject != null)
            {
                string selectedPath = AssetDatabase.GetAssetPath(Selection.activeObject);
                if (System.IO.Directory.Exists(selectedPath))
                {
                    path = selectedPath + "/AIAssistantConfig.asset";
                }
            }
            
            path = AssetDatabase.GenerateUniqueAssetPath(path);
            
            AssetDatabase.CreateAsset(config, path);
            AssetDatabase.SaveAssets();
            
            EditorUtility.FocusProjectWindow();
            Selection.activeObject = config;
            
            Debug.Log($"Created AI Assistant Config at {path}");
        }

        [MenuItem("GameObject/UniGit/Analyze Selected Object", false, 10)]
        public static void AnalyzeSelectedObject()
        {
            if (Selection.activeGameObject == null)
            {
                EditorUtility.DisplayDialog("No Selection", "Please select a GameObject to analyze.", "OK");
                return;
            }

            string context = UnityContextProvider.GetGameObjectContext(Selection.activeGameObject);
            
            // Copy to clipboard
            EditorGUIUtility.systemCopyBuffer = context;
            
            Debug.Log("GameObject context copied to clipboard:\n" + context);
            EditorUtility.DisplayDialog("Context Copied", 
                "GameObject context has been copied to clipboard and logged to console.", "OK");
        }

        [MenuItem("GameObject/UniGit/Analyze Selected Object", true)]
        public static bool ValidateAnalyzeSelectedObject()
        {
            return Selection.activeGameObject != null;
        }

        [MenuItem("Tools/UniGit/Get Project Context")]
        public static void GetProjectContext()
        {
            string context = UnityContextProvider.GetProjectContext(true);
            
            // Copy to clipboard
            EditorGUIUtility.systemCopyBuffer = context;
            
            Debug.Log("Project context copied to clipboard:\n" + context);
            EditorUtility.DisplayDialog("Context Copied", 
                "Project context has been copied to clipboard and logged to console.", "OK");
        }

        [MenuItem("Tools/UniGit/About")]
        public static void ShowAbout()
        {
            EditorUtility.DisplayDialog("UniGit - Unity AI Assistant",
                "Version 1.0.0\n\n" +
                "A Unity plugin for direct AI interaction within the Unity Editor.\n\n" +
                "Features:\n" +
                "- Chat with AI directly in Unity\n" +
                "- Automatic project context inclusion\n" +
                "- Scene analysis capabilities\n" +
                "- Configurable AI models and parameters\n\n" +
                "To get started:\n" +
                "1. Open Window > UniGit > AI Assistant\n" +
                "2. Configure your API settings\n" +
                "3. Start chatting!\n\n" +
                "Created by kallinski997",
                "OK");
        }
    }
}

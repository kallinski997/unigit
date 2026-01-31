using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace UniGit.Runtime
{
    /// <summary>
    /// Provides context information about the Unity project and scene
    /// </summary>
    public static class UnityContextProvider
    {
        /// <summary>
        /// Get comprehensive project context
        /// </summary>
        public static string GetProjectContext(bool includeScene = true)
        {
            StringBuilder context = new StringBuilder();
            
            context.AppendLine("=== Unity Project Context ===");
            context.AppendLine($"Unity Version: {Application.unityVersion}");
            context.AppendLine($"Platform: {Application.platform}");
            context.AppendLine($"Product Name: {Application.productName}");
            context.AppendLine($"Company Name: {Application.companyName}");
            context.AppendLine($"Data Path: {Application.dataPath}");
            
            if (includeScene)
            {
                context.AppendLine();
                context.AppendLine(GetSceneContext());
            }
            
            return context.ToString();
        }

        /// <summary>
        /// Get information about the current scene
        /// </summary>
        public static string GetSceneContext()
        {
            StringBuilder context = new StringBuilder();
            
            context.AppendLine("=== Current Scene Context ===");
            
            var scene = UnityEngine.SceneManagement.SceneManager.GetActiveScene();
            context.AppendLine($"Scene Name: {scene.name}");
            context.AppendLine($"Scene Path: {scene.path}");
            context.AppendLine($"Root Objects Count: {scene.rootCount}");
            
            // List root game objects
            var rootObjects = scene.GetRootGameObjects();
            if (rootObjects.Length > 0)
            {
                context.AppendLine("\nRoot GameObjects:");
                foreach (var obj in rootObjects)
                {
                    context.AppendLine($"  - {obj.name} (Active: {obj.activeSelf})");
                    ListComponents(obj, context, "    ");
                }
            }
            
            return context.ToString();
        }

        /// <summary>
        /// Get information about a specific GameObject
        /// </summary>
        public static string GetGameObjectContext(GameObject obj)
        {
            if (obj == null) return "GameObject is null";
            
            StringBuilder context = new StringBuilder();
            context.AppendLine($"=== GameObject: {obj.name} ===");
            context.AppendLine($"Active: {obj.activeSelf}");
            context.AppendLine($"Tag: {obj.tag}");
            context.AppendLine($"Layer: {LayerMask.LayerToName(obj.layer)}");
            context.AppendLine($"Position: {obj.transform.position}");
            context.AppendLine($"Rotation: {obj.transform.rotation.eulerAngles}");
            context.AppendLine($"Scale: {obj.transform.localScale}");
            
            ListComponents(obj, context, "");
            
            return context.ToString();
        }

        private static void ListComponents(GameObject obj, StringBuilder context, string indent)
        {
            var components = obj.GetComponents<Component>();
            if (components.Length > 0)
            {
                context.AppendLine($"{indent}Components:");
                foreach (var comp in components)
                {
                    if (comp != null)
                    {
                        context.AppendLine($"{indent}  - {comp.GetType().Name}");
                    }
                }
            }
        }

        /// <summary>
        /// Get build settings information
        /// </summary>
        public static string GetBuildContext()
        {
            StringBuilder context = new StringBuilder();
            
            context.AppendLine("=== Build Settings ===");
            context.AppendLine($"Build Target: {Application.platform}");
            
            #if UNITY_EDITOR
            context.AppendLine($"Development Build: {UnityEditor.EditorUserBuildSettings.development}");
            #endif
            
            return context.ToString();
        }
    }
}

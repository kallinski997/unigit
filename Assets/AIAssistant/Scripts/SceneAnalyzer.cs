using UnityEngine;
using UnityEngine.SceneManagement;
using System.Linq;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Analyzes Unity scenes for optimization and issues
    /// </summary>
    public static class SceneAnalyzer
    {
        public class SceneAnalysisResult
        {
            public int totalObjects;
            public int activeObjects;
            public int inactiveObjects;
            public int lightCount;
            public int cameraCount;
            public int missingReferences;
            public int emptyGameObjects;
            public int staticObjects;
        }

        /// <summary>
        /// Analyzes the current scene and returns statistics
        /// </summary>
        public static SceneAnalysisResult AnalyzeCurrentScene()
        {
            var result = new SceneAnalysisResult();
            
            GameObject[] allObjects = Object.FindObjectsOfType<GameObject>(true);
            result.totalObjects = allObjects.Length;
            
            foreach (GameObject obj in allObjects)
            {
                if (obj.activeInHierarchy)
                    result.activeObjects++;
                else
                    result.inactiveObjects++;

                if (obj.isStatic)
                    result.staticObjects++;

                // Check for components
                if (obj.GetComponent<Light>() != null)
                    result.lightCount++;
                
                if (obj.GetComponent<Camera>() != null)
                    result.cameraCount++;

                // Check for missing references
                Component[] components = obj.GetComponents<Component>();
                foreach (Component comp in components)
                {
                    if (comp == null)
                        result.missingReferences++;
                }

                // Check if empty
                if (obj.GetComponents<Component>().Length == 1) // Only Transform
                    result.emptyGameObjects++;
            }

            return result;
        }

        /// <summary>
        /// Finds all objects with missing script references
        /// </summary>
        public static GameObject[] FindObjectsWithMissingScripts()
        {
            GameObject[] allObjects = Object.FindObjectsOfType<GameObject>(true);
            return allObjects.Where(obj =>
            {
                Component[] components = obj.GetComponents<Component>();
                return components.Any(c => c == null);
            }).ToArray();
        }

        /// <summary>
        /// Finds all empty GameObjects (only Transform component)
        /// </summary>
        public static GameObject[] FindEmptyGameObjects()
        {
            GameObject[] allObjects = Object.FindObjectsOfType<GameObject>(true);
            return allObjects.Where(obj => obj.GetComponents<Component>().Length == 1).ToArray();
        }

        /// <summary>
        /// Gets performance metrics for the scene
        /// </summary>
        public static string GetPerformanceReport()
        {
            var result = AnalyzeCurrentScene();
            
            string report = "=== Scene Performance Report ===\n\n";
            report += $"Total GameObjects: {result.totalObjects}\n";
            report += $"Active Objects: {result.activeObjects}\n";
            report += $"Static Objects: {result.staticObjects}\n";
            report += $"Lights: {result.lightCount}\n";
            report += $"Cameras: {result.cameraCount}\n";
            report += $"Empty GameObjects: {result.emptyGameObjects}\n";
            report += $"Missing References: {result.missingReferences}\n\n";

            report += "=== Recommendations ===\n";
            
            if (result.lightCount > 4)
                report += "⚠ Consider reducing light count or using baked lighting\n";
            
            if (result.emptyGameObjects > 10)
                report += "⚠ Clean up empty GameObjects to improve hierarchy readability\n";
            
            if (result.missingReferences > 0)
                report += "❌ Fix missing script references immediately\n";
            
            if (result.staticObjects < result.totalObjects * 0.1f)
                report += "💡 Mark non-moving objects as static for better performance\n";

            return report;
        }
    }
}

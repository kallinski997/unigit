using UnityEngine;
using UnityEditor;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Menu items for quick access to AI Assistant features
    /// </summary>
    public static class AIAssistantMenuItems
    {
        [MenuItem("AI Assistant/Open Window", priority = 1)]
        public static void OpenAssistant()
        {
            AIAssistantWindow.ShowWindow();
        }

        [MenuItem("AI Assistant/Quick Actions/Create Grid 5x5", priority = 100)]
        public static void CreateGrid5x5()
        {
            LevelDesignHelper.CreateObjectGrid(5, 5, 2f, PrimitiveType.Cube);
        }

        [MenuItem("AI Assistant/Quick Actions/Create Basic Room", priority = 101)]
        public static void CreateBasicRoom()
        {
            LevelDesignHelper.CreateBasicRoom(10f, 10f, 3f);
        }

        [MenuItem("AI Assistant/Quick Actions/Add Directional Light", priority = 102)]
        public static void AddDirectionalLight()
        {
            LevelDesignHelper.CreateLight(LightType.Directional, new Vector3(0, 10, 0));
        }

        [MenuItem("AI Assistant/Analysis/Analyze Current Scene", priority = 200)]
        public static void AnalyzeScene()
        {
            var result = SceneAnalyzer.AnalyzeCurrentScene();
            string report = SceneAnalyzer.GetPerformanceReport();
            
            EditorUtility.DisplayDialog("Scene Analysis", report, "OK");
        }

        [MenuItem("AI Assistant/Analysis/Find Missing Scripts", priority = 201)]
        public static void FindMissingScripts()
        {
            GameObject[] objects = SceneAnalyzer.FindObjectsWithMissingScripts();
            
            if (objects.Length > 0)
            {
                Selection.objects = objects;
                Debug.LogWarning($"Found {objects.Length} objects with missing scripts. They are now selected.");
            }
            else
            {
                Debug.Log("No missing scripts found in the scene!");
            }
        }

        [MenuItem("AI Assistant/Analysis/Find Empty GameObjects", priority = 202)]
        public static void FindEmptyObjects()
        {
            GameObject[] objects = SceneAnalyzer.FindEmptyGameObjects();
            
            if (objects.Length > 0)
            {
                Selection.objects = objects;
                Debug.Log($"Found {objects.Length} empty GameObjects. They are now selected.");
            }
            else
            {
                Debug.Log("No empty GameObjects found!");
            }
        }

        [MenuItem("AI Assistant/Level Design/Arrange in Line", priority = 300)]
        [MenuItem("GameObject/AI Assistant/Arrange in Line")]
        public static void ArrangeInLine()
        {
            if (Selection.gameObjects.Length == 0)
            {
                EditorUtility.DisplayDialog("Error", "Please select objects to arrange.", "OK");
                return;
            }
            
            LevelDesignHelper.ArrangeInLine(2f);
        }

        [MenuItem("AI Assistant/Level Design/Arrange in Circle", priority = 301)]
        [MenuItem("GameObject/AI Assistant/Arrange in Circle")]
        public static void ArrangeInCircle()
        {
            if (Selection.gameObjects.Length == 0)
            {
                EditorUtility.DisplayDialog("Error", "Please select objects to arrange.", "OK");
                return;
            }
            
            LevelDesignHelper.ArrangeInCircle(5f);
        }

        [MenuItem("AI Assistant/Templates/Platformer Level", priority = 350)]
        public static void CreatePlatformerLevel()
        {
            LevelTemplates.CreatePlatformerLevel();
            Debug.Log("Created platformer level template");
        }

        [MenuItem("AI Assistant/Templates/Maze", priority = 351)]
        public static void CreateMaze()
        {
            LevelTemplates.CreateMaze(10, 10);
            Debug.Log("Created 10x10 maze template");
        }

        [MenuItem("AI Assistant/Templates/Arena", priority = 352)]
        public static void CreateArena()
        {
            LevelTemplates.CreateArena(10f);
            Debug.Log("Created arena template");
        }

        [MenuItem("AI Assistant/Templates/Race Track", priority = 353)]
        public static void CreateRaceTrack()
        {
            LevelTemplates.CreateRaceTrack();
            Debug.Log("Created race track template");
        }

        [MenuItem("AI Assistant/Materials/Create Basic Material", priority = 400)]
        public static void CreateBasicMaterial()
        {
            MaterialHelper.CreateBasicMaterial("NewMaterial", Color.white);
            Debug.Log("Created new material in Assets folder");
        }

        [MenuItem("AI Assistant/Materials/Create Emissive Material", priority = 401)]
        public static void CreateEmissiveMaterial()
        {
            MaterialHelper.CreateEmissiveMaterial("EmissiveMaterial", Color.cyan, 2f);
            Debug.Log("Created emissive material in Assets folder");
        }

        [MenuItem("AI Assistant/Help/Documentation", priority = 1000)]
        public static void OpenDocumentation()
        {
            Application.OpenURL("https://github.com/kallinski997/unigit");
        }

        [MenuItem("AI Assistant/Help/About", priority = 1001)]
        public static void ShowAbout()
        {
            EditorUtility.DisplayDialog(
                "AI Assistant for Unity",
                "Version 1.0.0\n\n" +
                "An AI-powered assistant to accelerate Unity development.\n\n" +
                "Features:\n" +
                "• AI-powered chat interface\n" +
                "• Level design automation\n" +
                "• Scene analysis and optimization\n" +
                "• Code snippet generation\n" +
                "• Material creation helpers\n\n" +
                "© 2024 UniGit",
                "OK"
            );
        }
    }
}

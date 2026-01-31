using UnityEngine;
using UnityEditor;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Preferences window for AI Assistant settings
    /// </summary>
    public class AIAssistantPreferences : EditorWindow
    {
        private const string PREF_DEFAULT_GRID_SIZE = "AIAssistant_DefaultGridSize";
        private const string PREF_DEFAULT_SPACING = "AIAssistant_DefaultSpacing";
        private const string PREF_AUTO_SELECT = "AIAssistant_AutoSelect";
        private const string PREF_SHOW_TIPS = "AIAssistant_ShowTips";
        private const string PREF_LANGUAGE = "AIAssistant_Language";

        private int defaultGridSize;
        private float defaultSpacing;
        private bool autoSelect;
        private bool showTips;
        private int languageIndex;
        private readonly string[] languages = new string[] { "English", "Deutsch" };

        [MenuItem("AI Assistant/Settings", priority = 999)]
        public static void ShowPreferences()
        {
            AIAssistantPreferences window = GetWindow<AIAssistantPreferences>("AI Assistant Settings");
            window.minSize = new Vector2(400, 300);
            window.Show();
        }

        private void OnEnable()
        {
            LoadPreferences();
        }

        private void LoadPreferences()
        {
            defaultGridSize = EditorPrefs.GetInt(PREF_DEFAULT_GRID_SIZE, 5);
            defaultSpacing = EditorPrefs.GetFloat(PREF_DEFAULT_SPACING, 2f);
            autoSelect = EditorPrefs.GetBool(PREF_AUTO_SELECT, true);
            showTips = EditorPrefs.GetBool(PREF_SHOW_TIPS, true);
            languageIndex = EditorPrefs.GetInt(PREF_LANGUAGE, 0);
        }

        private void SavePreferences()
        {
            EditorPrefs.SetInt(PREF_DEFAULT_GRID_SIZE, defaultGridSize);
            EditorPrefs.SetFloat(PREF_DEFAULT_SPACING, defaultSpacing);
            EditorPrefs.SetBool(PREF_AUTO_SELECT, autoSelect);
            EditorPrefs.SetBool(PREF_SHOW_TIPS, showTips);
            EditorPrefs.SetInt(PREF_LANGUAGE, languageIndex);
        }

        private void OnGUI()
        {
            EditorGUILayout.Space();
            EditorGUILayout.LabelField("AI Assistant Settings", EditorStyles.boldLabel);
            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Level Design Defaults", EditorStyles.boldLabel);
            
            defaultGridSize = EditorGUILayout.IntSlider("Default Grid Size", defaultGridSize, 2, 20);
            defaultSpacing = EditorGUILayout.Slider("Default Object Spacing", defaultSpacing, 0.5f, 10f);
            
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Behavior Settings", EditorStyles.boldLabel);
            
            autoSelect = EditorGUILayout.Toggle("Auto-Select Created Objects", autoSelect);
            showTips = EditorGUILayout.Toggle("Show Tips in Responses", showTips);
            
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();

            EditorGUILayout.BeginVertical("box");
            EditorGUILayout.LabelField("Interface Settings", EditorStyles.boldLabel);
            
            languageIndex = EditorGUILayout.Popup("Preferred Language", languageIndex, languages);
            
            EditorGUILayout.EndVertical();

            EditorGUILayout.Space();
            EditorGUILayout.Space();

            EditorGUILayout.BeginHorizontal();
            
            if (GUILayout.Button("Save", GUILayout.Height(30)))
            {
                SavePreferences();
                ShowNotification(new GUIContent("Settings saved!"));
            }
            
            if (GUILayout.Button("Reset to Defaults", GUILayout.Height(30)))
            {
                if (EditorUtility.DisplayDialog("Reset Settings", 
                    "Are you sure you want to reset all settings to defaults?", 
                    "Yes", "No"))
                {
                    ResetToDefaults();
                }
            }
            
            EditorGUILayout.EndHorizontal();

            EditorGUILayout.Space();

            EditorGUILayout.HelpBox(
                "These settings control the default behavior of the AI Assistant. " +
                "You can override these settings with specific commands in the chat interface.",
                MessageType.Info);
        }

        private void ResetToDefaults()
        {
            defaultGridSize = 5;
            defaultSpacing = 2f;
            autoSelect = true;
            showTips = true;
            languageIndex = 0;
            
            SavePreferences();
            ShowNotification(new GUIContent("Settings reset to defaults!"));
        }

        // Static helper methods for other classes to access preferences
        public static int GetDefaultGridSize()
        {
            return EditorPrefs.GetInt(PREF_DEFAULT_GRID_SIZE, 5);
        }

        public static float GetDefaultSpacing()
        {
            return EditorPrefs.GetFloat(PREF_DEFAULT_SPACING, 2f);
        }

        public static bool GetAutoSelect()
        {
            return EditorPrefs.GetBool(PREF_AUTO_SELECT, true);
        }

        public static bool GetShowTips()
        {
            return EditorPrefs.GetBool(PREF_SHOW_TIPS, true);
        }

        public static string GetPreferredLanguage()
        {
            int index = EditorPrefs.GetInt(PREF_LANGUAGE, 0);
            return index == 0 ? "en" : "de";
        }
    }
}

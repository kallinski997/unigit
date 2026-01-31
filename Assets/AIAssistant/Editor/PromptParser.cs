using UnityEngine;
using UnityEditor;
using System.Text.RegularExpressions;

namespace UniGit.AIAssistant.Editor
{
    /// <summary>
    /// Advanced prompt parser for more intelligent command interpretation
    /// </summary>
    public static class PromptParser
    {
        /// <summary>
        /// Extracts numbers from a prompt
        /// </summary>
        public static int[] ExtractNumbers(string prompt)
        {
            MatchCollection matches = Regex.Matches(prompt, @"\d+");
            int[] numbers = new int[matches.Count];
            
            for (int i = 0; i < matches.Count; i++)
            {
                int.TryParse(matches[i].Value, out numbers[i]);
            }
            
            return numbers;
        }

        /// <summary>
        /// Extracts color from prompt (e.g., "red", "blue", "#FF0000")
        /// </summary>
        public static Color? ExtractColor(string prompt)
        {
            string lowerPrompt = prompt.ToLower();
            
            // Named colors
            if (lowerPrompt.Contains("red") || lowerPrompt.Contains("rot"))
                return Color.red;
            if (lowerPrompt.Contains("blue") || lowerPrompt.Contains("blau"))
                return Color.blue;
            if (lowerPrompt.Contains("green") || lowerPrompt.Contains("grün"))
                return Color.green;
            if (lowerPrompt.Contains("yellow") || lowerPrompt.Contains("gelb"))
                return Color.yellow;
            if (lowerPrompt.Contains("white") || lowerPrompt.Contains("weiß"))
                return Color.white;
            if (lowerPrompt.Contains("black") || lowerPrompt.Contains("schwarz"))
                return Color.black;
            if (lowerPrompt.Contains("cyan"))
                return Color.cyan;
            if (lowerPrompt.Contains("magenta"))
                return Color.magenta;
            if (lowerPrompt.Contains("gray") || lowerPrompt.Contains("grey") || lowerPrompt.Contains("grau"))
                return Color.gray;
            
            // Hex color codes
            Match hexMatch = Regex.Match(prompt, @"#([0-9A-Fa-f]{6})");
            if (hexMatch.Success)
            {
                string hex = hexMatch.Groups[1].Value;
                if (ColorUtility.TryParseHtmlString("#" + hex, out Color color))
                    return color;
            }
            
            return null;
        }

        /// <summary>
        /// Determines primitive type from prompt
        /// </summary>
        public static PrimitiveType? ExtractPrimitiveType(string prompt)
        {
            string lowerPrompt = prompt.ToLower();
            
            if (lowerPrompt.Contains("cube") || lowerPrompt.Contains("würfel"))
                return PrimitiveType.Cube;
            if (lowerPrompt.Contains("sphere") || lowerPrompt.Contains("kugel"))
                return PrimitiveType.Sphere;
            if (lowerPrompt.Contains("cylinder") || lowerPrompt.Contains("zylinder"))
                return PrimitiveType.Cylinder;
            if (lowerPrompt.Contains("capsule") || lowerPrompt.Contains("kapsel"))
                return PrimitiveType.Capsule;
            if (lowerPrompt.Contains("plane") || lowerPrompt.Contains("ebene"))
                return PrimitiveType.Plane;
            if (lowerPrompt.Contains("quad"))
                return PrimitiveType.Quad;
            
            return null;
        }

        /// <summary>
        /// Extracts grid dimensions from prompt (e.g., "5x5", "3 by 4")
        /// </summary>
        public static (int rows, int cols)? ExtractGridDimensions(string prompt)
        {
            // Pattern: "5x5" or "5 x 5"
            Match match = Regex.Match(prompt, @"(\d+)\s*x\s*(\d+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                int.TryParse(match.Groups[1].Value, out int rows);
                int.TryParse(match.Groups[2].Value, out int cols);
                return (rows, cols);
            }
            
            // Pattern: "5 by 5"
            match = Regex.Match(prompt, @"(\d+)\s+by\s+(\d+)", RegexOptions.IgnoreCase);
            if (match.Success)
            {
                int.TryParse(match.Groups[1].Value, out int rows);
                int.TryParse(match.Groups[2].Value, out int cols);
                return (rows, cols);
            }
            
            return null;
        }

        /// <summary>
        /// Checks if prompt is a question
        /// </summary>
        public static bool IsQuestion(string prompt)
        {
            string lowerPrompt = prompt.ToLower().Trim();
            
            return lowerPrompt.StartsWith("what") ||
                   lowerPrompt.StartsWith("how") ||
                   lowerPrompt.StartsWith("why") ||
                   lowerPrompt.StartsWith("when") ||
                   lowerPrompt.StartsWith("where") ||
                   lowerPrompt.StartsWith("who") ||
                   lowerPrompt.StartsWith("can") ||
                   lowerPrompt.StartsWith("is") ||
                   lowerPrompt.StartsWith("was") ||
                   lowerPrompt.EndsWith("?");
        }

        /// <summary>
        /// Extracts action from prompt (create, delete, modify, etc.)
        /// </summary>
        public static string ExtractAction(string prompt)
        {
            string lowerPrompt = prompt.ToLower();
            
            if (lowerPrompt.Contains("create") || lowerPrompt.Contains("add") || 
                lowerPrompt.Contains("make") || lowerPrompt.Contains("generate") ||
                lowerPrompt.Contains("erstelle") || lowerPrompt.Contains("erstell"))
                return "create";
            
            if (lowerPrompt.Contains("delete") || lowerPrompt.Contains("remove") ||
                lowerPrompt.Contains("lösche") || lowerPrompt.Contains("entferne"))
                return "delete";
            
            if (lowerPrompt.Contains("modify") || lowerPrompt.Contains("change") ||
                lowerPrompt.Contains("update") || lowerPrompt.Contains("ändere"))
                return "modify";
            
            if (lowerPrompt.Contains("analyze") || lowerPrompt.Contains("check") ||
                lowerPrompt.Contains("analysiere") || lowerPrompt.Contains("prüfe"))
                return "analyze";
            
            if (lowerPrompt.Contains("arrange") || lowerPrompt.Contains("organize") ||
                lowerPrompt.Contains("ordne") || lowerPrompt.Contains("organisiere"))
                return "arrange";
            
            return "unknown";
        }

        /// <summary>
        /// Extracts position keywords from prompt
        /// </summary>
        public static Vector3? ExtractPosition(string prompt)
        {
            string lowerPrompt = prompt.ToLower();
            
            if (lowerPrompt.Contains("origin") || lowerPrompt.Contains("center") || 
                lowerPrompt.Contains("zentrum") || lowerPrompt.Contains("ursprung"))
                return Vector3.zero;
            
            if (lowerPrompt.Contains("above") || lowerPrompt.Contains("up") || lowerPrompt.Contains("oben"))
                return Vector3.up * 5;
            
            if (lowerPrompt.Contains("below") || lowerPrompt.Contains("down") || lowerPrompt.Contains("unten"))
                return Vector3.down * 5;
            
            // Try to extract coordinates like "at (5, 2, 3)" or "at 5 2 3"
            Match coordMatch = Regex.Match(prompt, @"at\s*\(?\s*(-?\d+(?:\.\d+)?)\s*,?\s*(-?\d+(?:\.\d+)?)\s*,?\s*(-?\d+(?:\.\d+)?)\s*\)?");
            if (coordMatch.Success)
            {
                float.TryParse(coordMatch.Groups[1].Value, out float x);
                float.TryParse(coordMatch.Groups[2].Value, out float y);
                float.TryParse(coordMatch.Groups[3].Value, out float z);
                return new Vector3(x, y, z);
            }
            
            return null;
        }

        /// <summary>
        /// Suggests completions based on partial prompt
        /// </summary>
        public static string[] GetSuggestions(string partialPrompt)
        {
            string lower = partialPrompt.ToLower();
            
            if (lower.StartsWith("cre"))
                return new string[] { "create cube", "create sphere", "create grid", "create room", "create light" };
            
            if (lower.StartsWith("gen"))
                return new string[] { "generate grid", "generate maze", "generate arena" };
            
            if (lower.StartsWith("add"))
                return new string[] { "add light", "add cube", "add sphere" };
            
            if (lower.StartsWith("ana"))
                return new string[] { "analyze scene", "analyze performance" };
            
            if (lower.StartsWith("show"))
                return new string[] { "show movement script", "show trigger script", "show rotation code" };
            
            return new string[0];
        }
    }
}

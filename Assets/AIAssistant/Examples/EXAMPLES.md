# Examples - AI Assistant für Unity

Diese Beispiele zeigen, wie Sie den AI Assistant effektiv nutzen können.

## Beispiel 1: Schnelles Level-Design

### Prompt-Sequenz:
```
1. "Create a basic room"
2. "Add a light to the scene"
3. "Create a 3x3 grid of cubes"
```

### Ergebnis:
- Ein vollständiger Raum mit Wänden und Boden
- Beleuchtung für bessere Sicht
- 9 Würfel als Platzhalter für Gameplay-Elemente

## Beispiel 2: Material-Workflow

### Prompts:
```
1. "Create a material"
2. "Create an emissive material"
```

### Verwendung:
1. Wähle Objekte in der Szene aus
2. Wende das Material über den Inspector an
3. Passe Eigenschaften nach Bedarf an

## Beispiel 3: Scene-Optimierung

### Workflow:
```
1. "Analyze the scene"
2. Überprüfe die Empfehlungen
3. "Find missing scripts"
4. Behebe gefundene Probleme
```

### Performance-Check:
- Objekt-Anzahl
- Beleuchtung
- Fehlende Referenzen
- Optimierungsvorschläge

## Beispiel 4: Code-Generierung

### Für Bewegung:
```
Prompt: "Show me a movement script"
```

Ergebnis: Vollständiges Movement-Script mit:
- WASD-Steuerung
- Springen
- Rigidbody-Integration

### Für Trigger:
```
Prompt: "Give me a trigger example"
```

Ergebnis: Trigger-System mit:
- OnTriggerEnter/Exit Events
- Tag-Filtering
- UnityEvents für Inspector

## Beispiel 5: Objekt-Arrangement

### Via Menu:
```
1. Wähle mehrere Objekte aus
2. GameObject > AI Assistant > Arrange in Circle
```

### Via Prompt:
```
"Arrange objects in a line"
```

## Beispiel 6: Komplexe Level-Templates

### Platformer Level:
```csharp
// Via Code:
LevelTemplates.CreatePlatformerLevel();

// Erstellt:
- Boden
- Mehrere Plattformen
- Spawn-Point
- Ziel
```

### Arena:
```csharp
// Via Code:
LevelTemplates.CreateArena(15f);

// Erstellt:
- Runde Arena mit 15m Radius
- Umgebende Wände
- Zentrale Säule
```

### Maze:
```csharp
// Via Code:
LevelTemplates.CreateMaze(10, 10);

// Erstellt:
- 10x10 Labyrinth
- Außenwände
- Interne Wände-Struktur
```

## Beispiel 7: Programmatische Nutzung

```csharp
using UniGit.AIAssistant.Editor;
using UnityEngine;

public class MyLevelGenerator : MonoBehaviour
{
    void GenerateLevel()
    {
        // Erstelle Raum
        var room = LevelDesignHelper.CreateBasicRoom(15f, 15f, 4f);
        
        // Füge Beleuchtung hinzu
        LevelDesignHelper.CreateLight(LightType.Directional, Vector3.up * 10);
        
        // Erstelle Objekt-Grid für Gegner-Spawns
        var spawns = LevelDesignHelper.CreateObjectGrid(5, 5, 3f);
        
        // Analysiere die Szene
        var analysis = SceneAnalyzer.AnalyzeCurrentScene();
        Debug.Log($"Level hat {analysis.totalObjects} Objekte");
    }
}
```

## Beispiel 8: Custom Workflow

### Level-Design-Pipeline:
```
1. "Create a basic room" 
   → Grundstruktur
   
2. "Add directional light"
   → Beleuchtung
   
3. "Create a 5x5 grid"
   → Gameplay-Elemente platzieren
   
4. "Create a material"
   → Visuals verbessern
   
5. "Analyze the scene"
   → Optimierung prüfen
```

## Beispiel 9: Rapid Prototyping

### Schnelle Arena-Erstellung:
```
// 1. Grundstruktur
LevelTemplates.CreateArena(20f);

// 2. Spawn-Points
for (int i = 0; i < 4; i++)
{
    float angle = i * 90f * Mathf.Deg2Rad;
    Vector3 pos = new Vector3(Mathf.Cos(angle) * 15f, 1f, Mathf.Sin(angle) * 15f);
    LevelDesignHelper.CreatePrimitive(PrimitiveType.Sphere, pos);
}

// 3. Beleuchtung
LevelDesignHelper.CreateLight(LightType.Point, new Vector3(0, 10, 0));
```

## Beispiel 10: Testing & Debugging

### Scene-Analyse für QA:
```csharp
// Automatische Checks
var analysis = SceneAnalyzer.AnalyzeCurrentScene();

if (analysis.missingReferences > 0)
{
    Debug.LogError($"Found {analysis.missingReferences} missing references!");
    var objects = SceneAnalyzer.FindObjectsWithMissingScripts();
    Selection.objects = objects;
}

if (analysis.lightCount == 0)
{
    Debug.LogWarning("No lights in scene - adding default light");
    LevelDesignHelper.CreateLight(LightType.Directional, Vector3.up * 10);
}
```

## Best Practices

1. **Klare Prompts**: Verwende spezifische Anweisungen
2. **Iterativ arbeiten**: Baue schrittweise auf
3. **Analyse nutzen**: Regelmäßig Scene analysieren
4. **Organisation**: Nutze Parent-Objekte für Struktur
5. **Code-Snippets**: Passe generierte Scripts an deine Bedürfnisse an

## Tipps

- Kombiniere mehrere Features für komplexe Workflows
- Nutze Quick Actions für wiederholende Aufgaben
- Experimentiere mit verschiedenen Prompts
- Verwende die programmatische API für Custom-Tools
- Integriere den AI Assistant in deine bestehenden Workflows

## Häufige Anwendungsfälle

1. **Rapid Prototyping**: Schnell Ideen testen
2. **Level Blockout**: Grundlegende Geometrie erstellen
3. **Code Learning**: Scripts als Lernmaterial nutzen
4. **Scene Cleanup**: Probleme finden und beheben
5. **Batch Operations**: Viele Objekte gleichzeitig bearbeiten

---

Weitere Beispiele und Updates findest du auf GitHub!

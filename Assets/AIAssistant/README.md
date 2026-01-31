# AI Assistant for Unity

Ein KI-gestütztes Plugin für Unity, das die Levelentwicklung und Unity-Entwicklung durch intelligente Prompts und Automatisierung beschleunigt.

## Features

### 🤖 AI Chat-Interface
- Interaktives Chat-Fenster im Unity Editor
- Natürliche Sprachverarbeitung für Unity-Befehle
- Kontextbewusste Antworten und Hilfestellungen

### 🏗️ Level Design Tools
- Automatische GameObject-Generierung durch Prompts
- Objekt-Raster erstellen ("create grid 5x5")
- Räume und Layouts automatisch generieren
- Objekte intelligent anordnen (Linie, Kreis, etc.)
- Beleuchtung automatisch hinzufügen

### 📊 Scene Analysis
- Szenen-Performance analysieren
- Fehlende Referenzen finden
- Optimierungsvorschläge
- Leere GameObjects identifizieren

### 💻 Code Generation
- Bewegungs-Scripts
- Rotations-Code
- Trigger-Systeme
- Singleton-Pattern
- Coroutine-Beispiele
- Object Pooling

### 🎨 Material-Helpers
- Einfache Material-Erstellung
- PBR-Materials
- Emissive Materials
- Transparente Materials
- Automatisches Anwenden auf Objekte

## Installation

1. Kopiere den `Assets/AIAssistant` Ordner in dein Unity-Projekt
2. Unity wird automatisch die Assembly Definitions kompilieren
3. Öffne das AI Assistant Fenster über `Window > AI Assistant`

## Verwendung

### Chat Interface öffnen
```
Window > AI Assistant
```
oder
```
AI Assistant > Open Window
```

### Beispiel-Prompts

**Level Design:**
- "Create a cube" - Erstellt einen Würfel
- "Generate a 5x5 grid" - Erstellt ein Raster aus Objekten
- "Add a light to the scene" - Fügt eine Lichtquelle hinzu
- "Create a basic room" - Generiert einen einfachen Raum

**Scene Analysis:**
- "Analyze the scene" - Analysiert die aktuelle Szene
- "Check performance" - Überprüft Performance-Metriken
- "Optimize scene" - Gibt Optimierungsvorschläge

**Code Generation:**
- "Show me a movement script" - Generiert ein Bewegungs-Script
- "Give me a trigger example" - Zeigt Trigger-Code
- "Show rotation code" - Generiert Rotations-Script

**Materials:**
- "Create a material" - Erstellt ein neues Material
- "Create emissive material" - Erstellt leuchtendes Material

## Menu-Optionen

### Quick Actions
- Create Grid 5x5
- Create Basic Room
- Add Directional Light

### Analysis
- Analyze Current Scene
- Find Missing Scripts
- Find Empty GameObjects

### Level Design
- Arrange in Line
- Arrange in Circle

### Materials
- Create Basic Material
- Create Emissive Material

## Keyboard Shortcuts

Im AI Assistant Window:
- `Ctrl + Enter` - Submit Prompt
- `Clear` Button - Konversation zurücksetzen

## API-Beispiele

### Programmatische Nutzung

```csharp
using UniGit.AIAssistant.Editor;

// Level Design
LevelDesignHelper.CreatePrimitive(PrimitiveType.Cube, Vector3.zero);
LevelDesignHelper.CreateObjectGrid(5, 5, 2f);
LevelDesignHelper.CreateBasicRoom(10f, 10f, 3f);

// Scene Analysis
var analysis = SceneAnalyzer.AnalyzeCurrentScene();
Debug.Log($"Total objects: {analysis.totalObjects}");

// Materials
var material = MaterialHelper.CreateBasicMaterial("MyMaterial", Color.red);
MaterialHelper.ApplyMaterialToSelection(material);
```

## Technische Details

### Struktur
```
Assets/AIAssistant/
├── Editor/
│   ├── AIAssistantWindow.cs          # Haupt-UI-Fenster
│   ├── AIAssistantMenuItems.cs       # Menu-Integration
│   └── UniGit.AIAssistant.Editor.asmdef
├── Runtime/
│   └── UniGit.AIAssistant.Runtime.asmdef
├── Scripts/
│   ├── LevelDesign/
│   │   └── LevelDesignHelper.cs      # Level-Design-Tools
│   ├── SceneAnalyzer.cs              # Scene-Analyse
│   ├── CodeSnippets.cs               # Code-Generierung
│   └── MaterialHelper.cs             # Material-Verwaltung
└── package.json
```

### Anforderungen
- Unity 2020.3 oder höher
- Keine externen Abhängigkeiten

## Erweiterung

Das Plugin ist modular aufgebaut und kann einfach erweitert werden:

1. **Neue Prompts hinzufügen**: Erweitere `AIAssistantWindow.GenerateResponse()`
2. **Neue Level-Design-Tools**: Füge Methoden zu `LevelDesignHelper` hinzu
3. **Neue Code-Snippets**: Erweitere `CodeSnippets` Klasse
4. **Custom Analysen**: Erweitere `SceneAnalyzer`

## Tipps & Tricks

- Nutze natürliche Sprache für Prompts (Deutsch oder Englisch)
- Der AI Assistant lernt aus deinen Anfragen
- Verwende die Quick Actions für häufige Aufgaben
- Nutze Scene Analysis regelmäßig zur Optimierung
- Kombiniere mehrere Befehle für komplexe Workflows

## Troubleshooting

**Problem**: AI Assistant Fenster öffnet sich nicht
- Lösung: Stelle sicher, dass die Assembly Definitions korrekt kompiliert wurden

**Problem**: Objekte werden nicht erstellt
- Lösung: Überprüfe die Console auf Fehler und stelle sicher, dass eine Szene geöffnet ist

**Problem**: Menu-Items fehlen
- Lösung: Reimportiere das Plugin oder starte Unity neu

## Lizenz

Dieses Plugin ist Open Source und kann frei verwendet und angepasst werden.

## Beitragen

Contributions sind willkommen! Bitte erstelle einen Pull Request mit deinen Verbesserungen.

## Support

Bei Fragen oder Problemen erstelle ein Issue auf GitHub:
https://github.com/kallinski997/unigit

---

Viel Spaß beim Entwickeln mit dem AI Assistant! 🚀

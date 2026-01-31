# UniGit - Unity AI Assistant Plugin

Ein Unity Plugin für direkte KI-Interaktion im Unity Editor.

## Übersicht

UniGit ist ein leistungsstarkes Unity Editor Plugin, das es ermöglicht, direkt mit einer KI (wie ChatGPT) innerhalb des Unity Editors zu interagieren. Das Plugin bietet eine intuitive Chat-Oberfläche und kann automatisch Kontext über Ihr Unity-Projekt und Ihre Szenen bereitstellen.

## Features

- 🤖 **Direkte KI-Integration**: Chatten Sie mit KI direkt im Unity Editor
- 📋 **Automatischer Kontext**: Projekt- und Szeneninformationen werden automatisch an die KI übermittelt
- ⚙️ **Konfigurierbar**: Passen Sie KI-Modell, Temperatur und andere Parameter an
- 🔍 **Analyse-Tools**: Analysieren Sie GameObjects und erhalten Sie detaillierte Informationen
- 💬 **Gesprächsverlauf**: Behalten Sie den Überblick über Ihre Konversation
- 🎨 **Benutzerfreundliche UI**: Saubere und intuitive Editor-Oberfläche

## Installation

1. Kopieren Sie den `Assets/UniGit` Ordner in Ihr Unity-Projekt
2. Unity importiert automatisch alle benötigten Dateien
3. Das Plugin ist nun einsatzbereit!

## Erste Schritte

### 1. Öffnen Sie das AI Assistant Fenster

Gehen Sie zu `Window > UniGit > AI Assistant` im Unity Menü.

### 2. Konfigurieren Sie Ihre API-Einstellungen

1. Klicken Sie auf den "Settings" Button in der Toolbar
2. Geben Sie Ihren API-Schlüssel ein
3. Optional: Passen Sie weitere Einstellungen an:
   - **API Endpoint**: Die URL Ihres KI-Dienstes (Standard: OpenAI)
   - **Model**: Das zu verwendende KI-Modell (z.B. gpt-3.5-turbo, gpt-4)
   - **Temperature**: Steuert die Kreativität der Antworten (0 = fokussiert, 2 = kreativ)
   - **Max Tokens**: Maximale Länge der Antwort
   - **System Prompt**: Definiert das Verhalten des Assistenten
   - **Include Project Context**: Fügt Projektinformationen hinzu
   - **Include Scene Context**: Fügt Szeneninformationen hinzu

### 3. Starten Sie die Unterhaltung

1. Kehren Sie zum Chat zurück (klicken Sie auf "Chat" Button)
2. Geben Sie Ihre Frage oder Anfrage ein
3. Drücken Sie "Send" oder Enter

## Verwendung

### Chat mit der KI

Stellen Sie Fragen zu:
- Unity-Scripting und C#
- Szenen-Setup und Optimierung
- Asset-Management
- Best Practices
- Fehlersuche und Debugging
- Und vieles mehr!

**Beispielfragen:**
```
"Wie erstelle ich ein Player Controller Script?"
"Was ist der Unterschied zwischen Update und FixedUpdate?"
"Wie optimiere ich die Performance meiner Szene?"
"Erkläre mir das Unity Event System"
```

### GameObject Analyse

1. Wählen Sie ein GameObject in der Hierarchie oder Szene
2. Rechtsklick > `UniGit > Analyze Selected Object`
3. Die Informationen werden in die Zwischenablage kopiert und in der Konsole ausgegeben

### Projekt-Kontext abrufen

Gehen Sie zu `Tools > UniGit > Get Project Context`, um eine Übersicht über Ihr Projekt zu erhalten.

## API-Konfiguration

### OpenAI API

1. Erstellen Sie einen Account bei [OpenAI](https://platform.openai.com/)
2. Generieren Sie einen API-Schlüssel
3. Geben Sie den Schlüssel in den Einstellungen ein

**Endpoint**: `https://api.openai.com/v1/chat/completions`

### Andere API-Anbieter

Das Plugin unterstützt jeden OpenAI-kompatiblen API-Endpunkt. Passen Sie einfach die Endpoint-URL in den Einstellungen an.

## Architektur

### Komponenten

```
Assets/UniGit/
├── Runtime/
│   ├── AIAssistantConfig.cs        # Konfigurationseinstellungen
│   ├── AIAssistantService.cs       # API-Kommunikation
│   └── UnityContextProvider.cs     # Kontext-Sammlung
├── Editor/
│   ├── AIAssistantWindow.cs        # Haupt-Editor-Fenster
│   └── AIAssistantEditorUtils.cs   # Hilfstools und Menüs
└── Resources/
    └── AIAssistantConfig.asset      # Gespeicherte Konfiguration
```

### Klassen

- **AIAssistantConfig**: ScriptableObject für alle Einstellungen
- **AIAssistantService**: Verwaltet API-Kommunikation und Gesprächsverlauf
- **UnityContextProvider**: Sammelt Informationen über Projekt und Szene
- **AIAssistantWindow**: EditorWindow für die Chat-Oberfläche
- **AIAssistantEditorUtils**: Hilfsfunktionen und Menü-Items

## Systemanforderungen

- Unity 2019.4 oder höher
- .NET 4.x Scripting Runtime
- Internet-Verbindung für API-Zugriff

## Sicherheit

⚠️ **Wichtig**: 
- Ihr API-Schlüssel wird lokal in der Config-Asset gespeichert
- Teilen Sie Ihre Config-Dateien nicht öffentlich
- Fügen Sie `**/AIAssistantConfig.asset` zu Ihrer .gitignore hinzu, wenn Sie den Schlüssel dort speichern

## Fehlerbehebung

### "API Key Required" Fehler
- Stellen Sie sicher, dass Sie einen gültigen API-Schlüssel in den Einstellungen eingegeben haben

### Keine Antwort von der API
- Überprüfen Sie Ihre Internet-Verbindung
- Verifizieren Sie, dass Ihr API-Schlüssel gültig ist
- Überprüfen Sie die Konsole auf detaillierte Fehlermeldungen

### Langsame Antworten
- Reduzieren Sie die Max Tokens Einstellung
- Deaktivieren Sie "Include Scene Context" bei großen Szenen
- Verwenden Sie ein schnelleres Modell (z.B. gpt-3.5-turbo statt gpt-4)

## Erweiterte Funktionen

### Eigene Systemprompts

Passen Sie den System Prompt in den Einstellungen an, um das Verhalten der KI zu ändern:

```
"Du bist ein Experte für Unity 3D Game Development und spezialisiert auf Performance-Optimierung."
```

### Kontext-Management

Sie können wählen, welche Informationen an die KI gesendet werden:
- **Project Context**: Unity-Version, Plattform, Projektname
- **Scene Context**: Aktuelle Szene, GameObjects, Komponenten

## Bekannte Einschränkungen

- Das Plugin kann keine Dateien direkt ändern (nur Vorschläge geben)
- Die Qualität der Antworten hängt vom verwendeten KI-Modell ab
- API-Aufrufe können Kosten verursachen (je nach Anbieter)

## Lizenz

Dieses Projekt ist Open Source. Siehe LICENSE Datei für Details.

## Beitragen

Contributions sind willkommen! Bitte erstellen Sie ein Issue oder Pull Request auf GitHub.

## Support

Bei Fragen oder Problemen:
- Öffnen Sie ein Issue auf GitHub
- Kontaktieren Sie kallinski997

## Version History

### v1.0.0 (2026-01-31)
- Erste Version
- Chat-Interface mit KI
- Automatischer Kontext
- GameObject-Analyse
- Konfigurierbare Einstellungen

---

**UniGit** - Bringing AI directly into your Unity workflow! 🚀

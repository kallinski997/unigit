# UniGit UI Reference

## AI Assistant Window Interface

### Main Chat View

```
┌─────────────────────────────────────────────────────────────────┐
│ UniGit AI Assistant                    Settings  Clear           │
├─────────────────────────────────────────────────────────────────┤
│                                                                   │
│  ┌─────────────────────────────────────────────────────────┐   │
│  │ SYSTEM - 15:30:12                                        │   │
│  │ AI Assistant initialized. How can I help you with        │   │
│  │ Unity today?                                             │   │
│  └─────────────────────────────────────────────────────────┘   │
│                                                                   │
│  ┌─────────────────────────────────────────────────────────┐   │
│  │ USER - 15:30:45                                          │   │
│  │ How do I rotate a GameObject in code?                    │   │
│  └─────────────────────────────────────────────────────────┘   │
│                                                                   │
│  ┌─────────────────────────────────────────────────────────┐   │
│  │ ASSISTANT - 15:30:48                                     │   │
│  │ You can rotate a GameObject using Transform.Rotate().    │   │
│  │ Here's an example:                                       │   │
│  │                                                           │   │
│  │ void Update() {                                          │   │
│  │     transform.Rotate(0, 50 * Time.deltaTime, 0);        │   │
│  │ }                                                         │   │
│  │                                                           │   │
│  │ This rotates 50 degrees per second around the Y axis.    │   │
│  └─────────────────────────────────────────────────────────┘   │
│                                                                   │
├─────────────────────────────────────────────────────────────────┤
│ Your message: [____________________________________] [Send]      │
└─────────────────────────────────────────────────────────────────┘
```

### Settings Panel

```
┌─────────────────────────────────────────────────────────────────┐
│ UniGit AI Assistant                       Chat     Clear         │
├─────────────────────────────────────────────────────────────────┤
│                                                                   │
│  API Configuration                                               │
│  ℹ Configure your AI Assistant settings below. Make sure to      │
│    set your API key.                                             │
│                                                                   │
│  API Endpoint                                                    │
│  [https://api.openai.com/v1/chat/completions              ]     │
│                                                                   │
│  API Key                                                         │
│  [••••••••••••••••••••••••••••••••••••                    ]     │
│                                                                   │
│  Model Configuration                                             │
│                                                                   │
│  Model                                                           │
│  [gpt-3.5-turbo                                            ]     │
│                                                                   │
│  Temperature                    0.7                              │
│  [━━━━━━━━━━━━━━━━━━━━━○━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━]          │
│                                                                   │
│  Max Tokens                     2000                             │
│  [━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━━○━━━━━━━━━━━━━━━━]          │
│                                                                   │
│  Context Settings                                                │
│                                                                   │
│  System Prompt                                                   │
│  ┌─────────────────────────────────────────────────────────┐   │
│  │ You are a helpful Unity development assistant. You       │   │
│  │ help with scripting, scene setup, asset management,      │   │
│  │ and general Unity questions.                             │   │
│  └─────────────────────────────────────────────────────────┘   │
│                                                                   │
│  ☑ Include Project Context                                      │
│  ☐ Include Scene Context                                        │
│                                                                   │
│  [        Reinitialize Service        ]                          │
│                                                                   │
└─────────────────────────────────────────────────────────────────┘
```

## Unity Menu Integration

### Window Menu

```
Window
  ├── General
  ├── Rendering  
  ├── Animation
  ├── Audio
  ├── Package Manager
  └── UniGit                        ← New!
      └── AI Assistant              ← Opens the chat window
```

### GameObject Context Menu

```
Right-click on any GameObject in Hierarchy:

GameObject
  ├── Create Empty
  ├── 3D Object
  ├── Effects
  ├── Camera
  └── UniGit                        ← New!
      └── Analyze Selected Object   ← Analyzes and copies info
```

### Tools Menu

```
Tools
  ├── Unity Remote
  ├── Package Manager
  ├── Shortcuts Manager
  └── UniGit                        ← New!
      ├── Get Project Context       ← Copies project info
      └── About                     ← Shows plugin info
```

### Assets Create Menu

```
Right-click in Project window:

Assets
  ├── Create
      ├── Folder
      ├── C# Script
      ├── Scene
      └── UniGit                    ← New!
          └── AI Assistant Config   ← Creates config asset
```

## Color Coding

In the chat interface, messages are color-coded for easy identification:

- **System Messages**: Gray background (0.5, 0.5, 0.5, 0.3)
- **User Messages**: Blue background (0.3, 0.5, 0.7, 0.3)
- **Assistant Messages**: Green background (0.3, 0.7, 0.5, 0.3)

## Keyboard Shortcuts

- **Enter**: Send message (when input field is focused)
- **Escape**: Clear input field
- **Ctrl/Cmd + C**: Copy selected text from conversation

## Visual States

### Processing State
When the AI is processing your request:
```
Your message: [____________________________________] [Sending...]
```

### Empty State
When first opened:
```
┌─────────────────────────────────────────────────────────────────┐
│  ┌─────────────────────────────────────────────────────────┐   │
│  │ SYSTEM - 15:30:12                                        │   │
│  │ AI Assistant initialized. How can I help you with        │   │
│  │ Unity today?                                             │   │
│  └─────────────────────────────────────────────────────────┘   │
└─────────────────────────────────────────────────────────────────┘
```

### Error State
If API key is missing:
```
┌──────────────────────────────────────┐
│        API Key Required              │
│                                       │
│  Please set your API key in the      │
│  Settings panel before using the     │
│  AI Assistant.                       │
│                                       │
│              [ OK ]                   │
└──────────────────────────────────────┘
```

## Configuration Asset Inspector

When selecting the AIAssistantConfig.asset in the Project:

```
Inspector
┌─────────────────────────────────────────┐
│ AIAssistantConfig                       │
│ Script: AIAssistantConfig               │
├─────────────────────────────────────────┤
│                                         │
│ ▼ API Settings                          │
│   Api Endpoint                          │
│   [https://api.openai.com/v1/chat...] │
│   Api Key                               │
│   [••••••••••••••••••••••••••]         │
│                                         │
│ ▼ Model Settings                        │
│   Model                                 │
│   [gpt-3.5-turbo                  ]    │
│   Temperature                           │
│   [━━━━━━━━━━━○━━━━━━━━━━━]  0.7       │
│   Max Tokens                            │
│   [━━━━━━━━━━━━━━━━━━○━━━]  2000       │
│                                         │
│ ▼ Context Settings                      │
│   System Prompt                         │
│   [You are a helpful Unity...    ]     │
│   Include Project Context               │
│   ☑                                     │
│   Include Scene Context                 │
│   ☐                                     │
└─────────────────────────────────────────┘
```

## Typical Workflow

1. **Open Window**: Window > UniGit > AI Assistant
2. **First Time Setup**: Click Settings, enter API key
3. **Start Chatting**: Click Chat, type question, press Enter
4. **Get Context**: Right-click GameObject > UniGit > Analyze
5. **Ask About It**: Paste context in chat, ask specific question
6. **Apply Solution**: Copy AI's code suggestions to your scripts

## Tips for Best Experience

- Keep the window docked next to your Console or Inspector
- Use "Clear" button when changing topics
- Enable Scene Context when asking about specific GameObjects
- Disable context for general Unity questions (faster responses)
- The window remembers your conversation until you clear it

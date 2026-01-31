# UniGit Plugin Architecture

## Component Overview

```
┌─────────────────────────────────────────────────────────────────┐
│                         Unity Editor                             │
│                                                                   │
│  ┌────────────────────────────────────────────────────────┐    │
│  │          AI Assistant Window (Editor)                  │    │
│  │  ┌──────────────────────────────────────────────┐     │    │
│  │  │  Chat Interface                              │     │    │
│  │  │  - Message Input                             │     │    │
│  │  │  - Conversation Display                      │     │    │
│  │  │  - Settings Panel                            │     │    │
│  │  └──────────────────────────────────────────────┘     │    │
│  │                      │                                 │    │
│  │                      ▼                                 │    │
│  │  ┌──────────────────────────────────────────────┐     │    │
│  │  │  AI Assistant Service (Runtime)              │     │    │
│  │  │  - Message Management                        │     │    │
│  │  │  - Conversation History                      │     │    │
│  │  │  - API Communication                         │     │    │
│  │  └──────────────────────────────────────────────┘     │    │
│  │            │                        │                  │    │
│  │            ▼                        ▼                  │    │
│  │  ┌──────────────────┐    ┌──────────────────┐        │    │
│  │  │ Unity Context    │    │  AI Assistant    │        │    │
│  │  │ Provider         │    │  Config          │        │    │
│  │  │ (Runtime)        │    │  (ScriptableObj) │        │    │
│  │  └──────────────────┘    └──────────────────┘        │    │
│  └────────────────────────────────────────────────────────┘    │
│                      │                                           │
└──────────────────────│───────────────────────────────────────────┘
                       │
                       ▼
            ┌──────────────────────┐
            │   OpenAI API         │
            │   (or compatible)    │
            └──────────────────────┘
```

## Data Flow

### User Sends Message

```
1. User types message in AIAssistantWindow
   │
   ├─→ Check if API key is configured
   │
   ├─→ If context enabled:
   │   └─→ UnityContextProvider.GetProjectContext()
   │       └─→ Collects: Unity version, platform, scene info
   │
   ├─→ AIAssistantService.SendMessageAsync(message, context)
   │   │
   │   ├─→ Add user message to conversation history
   │   │
   │   ├─→ Create API request payload
   │   │   └─→ Include: model, messages, temperature, max_tokens
   │   │
   │   ├─→ Send HTTP POST to API endpoint
   │   │   └─→ With: Authorization header, JSON body
   │   │
   │   ├─→ Wait for response (async)
   │   │
   │   ├─→ Parse JSON response
   │   │
   │   └─→ Add AI response to conversation history
   │
   └─→ Display response in chat window
```

## Class Relationships

```
AIAssistantWindow (EditorWindow)
    ├── uses → AIAssistantConfig (ScriptableObject)
    │            ├── apiEndpoint: string
    │            ├── apiKey: string
    │            ├── model: string
    │            ├── temperature: float
    │            ├── maxTokens: int
    │            └── systemPrompt: string
    │
    ├── uses → AIAssistantService (Runtime Class)
    │            ├── config: AIAssistantConfig
    │            ├── conversationHistory: List<ChatMessage>
    │            ├── SendMessageAsync(message, context): Task<string>
    │            └── ClearHistory(): void
    │
    └── uses → UnityContextProvider (Static Class)
                 ├── GetProjectContext(): string
                 ├── GetSceneContext(): string
                 ├── GetGameObjectContext(GameObject): string
                 └── GetBuildContext(): string
```

## File Structure

```
Assets/UniGit/
│
├── package.json                          # Package manifest
│
├── Runtime/                              # Runtime scripts (available in builds)
│   ├── UniGit.Runtime.asmdef            # Assembly definition
│   ├── AIAssistantConfig.cs             # Configuration ScriptableObject
│   ├── AIAssistantService.cs            # Core API service
│   └── UnityContextProvider.cs          # Context collection utilities
│
├── Editor/                               # Editor-only scripts
│   ├── UniGit.Editor.asmdef             # Assembly definition
│   ├── AIAssistantWindow.cs             # Main editor window
│   └── AIAssistantEditorUtils.cs        # Editor utilities & menu items
│
├── Resources/                            # Runtime loadable assets
│   └── AIAssistantConfig.asset          # Saved configuration (created at runtime)
│
└── Documentation/
    ├── README.md                         # Main documentation
    ├── QUICKSTART.md                     # Quick start guide
    ├── CONFIGURATION.md                  # Configuration examples
    └── ARCHITECTURE.md                   # This file
```

## API Request Flow

```
┌─────────────────┐
│  User Message   │
└────────┬────────┘
         │
         ▼
┌─────────────────────────────────────┐
│  Build Request Object               │
│  {                                  │
│    "model": "gpt-3.5-turbo",       │
│    "messages": [                    │
│      {                              │
│        "role": "system",            │
│        "content": "You are..."      │
│      },                             │
│      {                              │
│        "role": "user",              │
│        "content": "Context: ... "   │
│      }                              │
│    ],                               │
│    "temperature": 0.7,              │
│    "max_tokens": 2000               │
│  }                                  │
└────────┬────────────────────────────┘
         │
         ▼
┌─────────────────────────────────────┐
│  UnityWebRequest                    │
│  POST to API endpoint               │
│  Headers:                           │
│    - Content-Type: application/json │
│    - Authorization: Bearer {key}    │
└────────┬────────────────────────────┘
         │
         ▼
┌─────────────────────────────────────┐
│  API Response                       │
│  {                                  │
│    "choices": [                     │
│      {                              │
│        "message": {                 │
│          "role": "assistant",       │
│          "content": "Here's how..." │
│        }                            │
│      }                              │
│    ]                                │
│  }                                  │
└────────┬────────────────────────────┘
         │
         ▼
┌─────────────────┐
│  Display Reply  │
└─────────────────┘
```

## Menu Integration

```
Unity Editor Menu Bar
│
├── Window/
│   └── UniGit/
│       └── AI Assistant → Opens AIAssistantWindow
│
├── GameObject/ (Right-click in Hierarchy)
│   └── UniGit/
│       └── Analyze Selected Object → Copies GameObject info to clipboard
│
├── Assets/ (Right-click in Project)
│   └── Create/
│       └── UniGit/
│           └── AI Assistant Config → Creates new config asset
│
└── Tools/
    └── UniGit/
        ├── Get Project Context → Copies project info to clipboard
        └── About → Shows plugin information
```

## Conversation State Management

```
Conversation History Structure:

┌─────────────────────────────────────┐
│  List<ChatMessage>                  │
├─────────────────────────────────────┤
│  [0] System Message                 │
│      "You are a Unity assistant..." │
├─────────────────────────────────────┤
│  [1] User Message                   │
│      "How do I rotate an object?"   │
├─────────────────────────────────────┤
│  [2] Assistant Message              │
│      "You can use Transform.Rotate" │
├─────────────────────────────────────┤
│  [3] User Message                   │
│      "Can you show me code?"        │
├─────────────────────────────────────┤
│  [4] Assistant Message              │
│      "Here's an example: ..."       │
└─────────────────────────────────────┘

All messages are sent with each API call to maintain context
```

## Threading Model

```
Main Thread (Unity)
    │
    ├─→ User clicks Send button
    │   └─→ AIAssistantWindow.SendMessage() [sync]
    │       └─→ AIAssistantService.SendMessageAsync() [async]
    │           │
    │           ├─→ Create UnityWebRequest
    │           │
    │           ├─→ SendWebRequest() [async]
    │           │   └─→ Waits in background
    │           │       └─→ Task.Delay(100) loop
    │           │
    │           └─→ Returns response [async]
    │               └─→ Updates UI on main thread
    │
    └─→ EditorWindow.Repaint() updates UI
```

## Configuration Persistence

```
AIAssistantConfig (ScriptableObject)
    │
    ├─→ Created in Resources folder
    │   Path: Assets/UniGit/Resources/AIAssistantConfig.asset
    │
    ├─→ Loaded via Resources.Load<AIAssistantConfig>("AIAssistantConfig")
    │
    ├─→ Modified in Settings panel
    │   └─→ EditorUtility.SetDirty(config) marks as changed
    │
    └─→ Automatically saved by Unity's AssetDatabase
```

## Extension Points

Developers can extend the plugin by:

1. **Custom Context Providers**
   - Add new methods to UnityContextProvider
   - Collect custom project-specific information

2. **Alternative AI Providers**
   - Change API endpoint in config
   - Ensure API is OpenAI-compatible (same JSON format)

3. **Custom UI Elements**
   - Extend AIAssistantWindow with additional panels
   - Add custom buttons and shortcuts

4. **Specialized Assistants**
   - Create multiple config assets with different system prompts
   - Load different configs for different purposes

## Security Considerations

```
Security Flow:

API Key Storage
    ├─→ Stored in AIAssistantConfig ScriptableObject
    ├─→ Displayed as PasswordField in UI (masked)
    ├─→ NOT encrypted in asset file
    └─→ Should be added to .gitignore

Best Practices:
    ├─→ Don't commit config with API key
    ├─→ Use environment-specific configs
    ├─→ Rotate keys regularly
    └─→ Monitor API usage/costs
```

## Performance Characteristics

- **Window Opening**: Instant (loads config from Resources)
- **Sending Message**: 1-5 seconds (depends on API response time)
- **Context Collection**: < 100ms (scans scene hierarchy)
- **Memory Usage**: Minimal (< 1MB for conversation history)
- **Network Usage**: ~1-5 KB per request (depends on context and response length)

## Future Enhancement Ideas

1. **Code Integration**
   - Direct code insertion into scripts
   - Auto-generation of script files

2. **Asset Management**
   - Help organizing project structure
   - Find and refactor assets

3. **Real-time Analysis**
   - Monitor Play Mode and provide suggestions
   - Performance profiling assistance

4. **Multi-modal Support**
   - Screenshot sharing with AI
   - Voice input/output

5. **Team Features**
   - Shared conversation history
   - Pre-defined templates and workflows

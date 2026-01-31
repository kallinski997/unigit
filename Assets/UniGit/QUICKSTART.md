# Quick Start Guide - UniGit Unity AI Assistant

## Installation in 3 Steps

### Step 1: Add to Unity Project
1. Copy the entire `Assets/UniGit` folder into your Unity project's `Assets` folder
2. Unity will automatically import the plugin
3. Wait for Unity to finish compiling

### Step 2: Open the AI Assistant Window
1. In Unity, go to the menu bar
2. Click `Window` → `UniGit` → `AI Assistant`
3. The AI Assistant window will open

### Step 3: Configure API Settings
1. In the AI Assistant window, click the `Settings` button in the toolbar
2. Enter your API settings:
   - **API Key**: Your OpenAI API key (get one at https://platform.openai.com/api-keys)
   - **Model**: `gpt-3.5-turbo` (recommended for speed) or `gpt-4` (better quality)
   - Leave other settings at defaults for now
3. Click the `Chat` button to return to the chat interface

## Your First Conversation

### Example 1: General Unity Question
```
You: How do I rotate a GameObject in Unity using code?

AI Assistant: [Provides C# code example with explanation]
```

### Example 2: Script Help
```
You: Create a simple player movement script for a 2D game

AI Assistant: [Provides complete script with WASD controls]
```

### Example 3: Scene Context
```
1. Make sure "Include Scene Context" is enabled in Settings
2. Select a GameObject in your scene
3. Ask: "What components does this object have and what do they do?"

AI Assistant: [Analyzes the selected object and explains its components]
```

## Common Use Cases

### 🎮 Game Development Help
- "Create a score manager script"
- "How do I implement a pause menu?"
- "Explain Unity's layer system"

### 🐛 Debugging
- "Why isn't my Rigidbody moving?"
- "Explain this error: NullReferenceException"
- "How do I debug physics issues?"

### ⚡ Performance
- "How can I optimize my scene?"
- "What's the difference between Instantiate and Object Pooling?"
- "How do I reduce draw calls?"

### 🎨 Best Practices
- "What's the best way to organize my project?"
- "Should I use Singleton pattern in Unity?"
- "How do I structure my code for multiplayer?"

## Tips for Best Results

1. **Be Specific**: Instead of "help with movement", say "help with 2D platformer character movement"

2. **Use Context**: Enable "Include Scene Context" when asking about specific GameObjects

3. **Iterative Questions**: Build on previous answers in the conversation

4. **Copy Code**: You can copy the AI's code suggestions directly from the response

5. **Clear When Needed**: Use the "Clear" button to start a fresh conversation on a new topic

## Keyboard Shortcuts

- **Enter**: Send message (when in the input field)
- **Ctrl/Cmd + C**: Copy selected text from responses

## Analyze GameObject Feature

1. Select any GameObject in your scene
2. Right-click on it
3. Choose `UniGit` → `Analyze Selected Object`
4. The GameObject's information is copied to clipboard
5. You can paste this in the chat for specific questions about that object

## Advanced: Custom System Prompts

Want the AI to behave differently? Customize the System Prompt in Settings:

### For UI Development
```
You are a Unity UI expert specializing in Unity's UI Toolkit and Canvas system. 
Focus on responsive design and accessibility.
```

### For Multiplayer Games
```
You are a Unity multiplayer expert familiar with Netcode, Mirror, and Photon. 
Provide network-efficient solutions and explain synchronization concepts.
```

### For Mobile Development
```
You are a Unity mobile development expert. Focus on performance optimization, 
touch controls, and platform-specific best practices for iOS and Android.
```

## Troubleshooting

### "API Key Required" Error
→ You need to add your API key in Settings

### No Response
→ Check your internet connection and API key validity

### Slow Responses
→ Try `gpt-3.5-turbo` model or reduce Max Tokens in Settings

### Rate Limit Error
→ Wait a moment before sending another message (OpenAI has rate limits)

## Cost Management

AI API calls cost money (though usually pennies per conversation). To minimize costs:

1. **Use gpt-3.5-turbo**: Much cheaper than gpt-4
2. **Reduce Max Tokens**: Lower = cheaper (try 1000 instead of 2000)
3. **Disable Context**: Turn off Scene Context for simple questions
4. **Clear History**: Start fresh conversations to reduce context size

## Security Reminder

⚠️ **Never share your API key publicly!**

Add this line to your `.gitignore`:
```
**/AIAssistantConfig.asset
```

## Getting Help

- Check the full [README](README.md) for detailed documentation
- See [CONFIGURATION.md](CONFIGURATION.md) for advanced setup options
- Open an issue on GitHub if you encounter bugs

## Next Steps

Now that you're set up:
1. Try asking a question about Unity
2. Experiment with different context settings
3. Use the GameObject analyzer on your scene objects
4. Customize the system prompt for your needs

**Happy developing with AI assistance! 🚀**

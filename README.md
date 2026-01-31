# UniGit - Unity AI Assistant Plugin

A Unity plugin for direct AI interaction within the Unity Editor.

## Overview

UniGit is a powerful Unity Editor plugin that enables direct interaction with AI (like ChatGPT) within the Unity Editor. The plugin provides an intuitive chat interface and can automatically provide context about your Unity project and scenes.

## Features

- 🤖 **Direct AI Integration**: Chat with AI directly in Unity Editor
- 📋 **Automatic Context**: Project and scene information automatically sent to AI
- ⚙️ **Configurable**: Customize AI model, temperature, and other parameters
- 🔍 **Analysis Tools**: Analyze GameObjects and get detailed information
- 💬 **Conversation History**: Keep track of your conversation
- 🎨 **User-Friendly UI**: Clean and intuitive editor interface

## Quick Start

1. Open `Window > UniGit > AI Assistant`
2. Configure your API settings (Settings button)
3. Start chatting!

## Documentation

See the [full documentation](Assets/UniGit/README.md) for detailed installation instructions, usage examples, and API configuration.

## Requirements

- Unity 2019.4 or higher
- .NET 4.x Scripting Runtime
- Internet connection for API access
- OpenAI API key or compatible API endpoint

## Installation

Copy the `Assets/UniGit` folder into your Unity project. Unity will automatically import all necessary files.

## Example Usage

Ask questions like:
- "How do I create a player controller script?"
- "What's the difference between Update and FixedUpdate?"
- "How can I optimize my scene performance?"
- "Explain the Unity Event System"

## Security Note

⚠️ Keep your API key secure! Add `**/AIAssistantConfig.asset` to your .gitignore if storing the key there.

## License

Open Source - See LICENSE file for details.

## Version

v1.0.0 - Initial release
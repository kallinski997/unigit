# Changelog

All notable changes to the UniGit Unity AI Assistant Plugin will be documented in this file.

## [1.0.0] - 2026-01-31

### Added
- Initial release of UniGit Unity AI Assistant Plugin
- Core AI Assistant service with OpenAI API integration
- Unity Editor window with chat interface
- Automatic project and scene context collection
- Configurable AI settings (model, temperature, max tokens)
- Custom system prompts support
- GameObject analysis tools
- Conversation history management
- Multiple menu integrations:
  - Window > UniGit > AI Assistant
  - GameObject > UniGit > Analyze Selected Object
  - Tools > UniGit > Get Project Context
  - Tools > UniGit > About
- Assembly definitions for Runtime and Editor
- Package manifest for Unity Package Manager compatibility
- Comprehensive documentation (README, CONFIGURATION)
- MIT License
- Example configurations for multiple AI providers

### Features
- **Chat Interface**: Interactive chat window within Unity Editor
- **Context Awareness**: Automatically includes Unity project and scene information
- **Configurable**: Fully customizable AI parameters and behavior
- **Analysis Tools**: Analyze GameObjects and get detailed information
- **Multi-provider Support**: Works with OpenAI and compatible APIs
- **Conversation Management**: Clear history and maintain conversation context
- **Security**: Password field for API key, guidance on .gitignore usage

### Technical Details
- Unity 2019.4+ compatibility
- .NET 4.x scripting runtime required
- Async/await pattern for API calls
- ScriptableObject-based configuration
- Editor-only tools to minimize runtime overhead

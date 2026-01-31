# Changelog

All notable changes to the AI Assistant for Unity will be documented in this file.

The format is based on [Keep a Changelog](https://keepachangelog.com/en/1.0.0/),
and this project adheres to [Semantic Versioning](https://semver.org/spec/v2.0.0.html).

## [1.0.0] - 2024-01-31

### Added
- Initial release of AI Assistant for Unity
- AI-powered chat interface in Unity Editor
- Natural language command processing (English and German)
- Level design automation features:
  - Primitive object creation (cube, sphere, plane, cylinder, capsule)
  - Object grid generation
  - Basic room creation
  - Object arrangement tools (line, circle)
  - Light creation (directional, point, spot)
- Level templates system:
  - Platformer level template
  - Maze generator
  - Arena creator
  - Race track generator
- Scene analysis tools:
  - Performance metrics
  - Missing script detection
  - Empty GameObject finder
  - Optimization recommendations
- Code snippet generation:
  - Player movement scripts
  - Rotation code
  - Trigger systems
  - Singleton pattern
  - Coroutine examples
  - Object pooling implementation
- Material creation helpers:
  - Basic materials
  - PBR materials
  - Emissive materials
  - Transparent materials
  - Material application to selection
- Unity Editor menu integration:
  - Quick Actions menu
  - Analysis tools menu
  - Level Design menu
  - Templates menu
  - Materials menu
- Comprehensive documentation:
  - Quick Start Guide
  - Full README with examples
  - Example workflows and use cases
- Assembly definitions for proper Unity package structure
- Runtime component for AI-generated objects

### Features
- Support for natural language prompts in English and German
- Context-aware responses based on prompt content
- Conversation history with scrollable chat interface
- Undo support for all operations
- Automatic selection of created objects
- Keyboard shortcuts (Ctrl+Enter for submit)
- Clear conversation button
- Help system with command overview

### Documentation
- Installation guide
- Usage examples
- API documentation
- Best practices
- Troubleshooting guide
- Example workflows

### Technical Details
- Unity 2020.3+ compatibility
- No external dependencies
- Editor-only tools (safe for builds)
- Assembly definition files for clean project structure
- Namespace organization (UniGit.AIAssistant.Editor/Runtime)

## [Unreleased]

### Planned Features
- AI model integration for more advanced responses
- Custom template creation
- Script file creation directly from chat
- Prefab generation and management
- Advanced scene optimization tools
- Batch operations on multiple objects
- Material library system
- Terrain generation helpers
- Audio source management
- Animation helper tools
- UI element generation
- Particle system presets

---

For more information, visit: https://github.com/kallinski997/unigit

# AI Assistant for Unity - Complete Feature Guide

## 🚀 Getting Started in 30 Seconds

1. Open Unity Editor
2. Go to `Window > AI Assistant`
3. Type: `create a cube`
4. Press Enter or click Submit
5. Watch your cube appear!

## 📋 Complete Command Reference

### 🏗️ Object Creation Commands

#### Basic Primitives
```
"create a cube"          → Creates a cube at origin
"create a sphere"        → Creates a sphere at origin
"create a plane"         → Creates a plane at origin
"create a cylinder"      → Creates a cylinder at origin
"create a capsule"       → Creates a capsule at origin
```

#### Grids
```
"create a grid"          → Creates 5x5 grid of cubes
"generate a 5x5 grid"    → Creates 5x5 grid
"create a 3x4 grid"      → Creates 3x4 grid
"make a 10x10 grid"      → Creates 10x10 grid
```

#### Rooms & Structures
```
"create a room"          → Creates basic room (10x10x3)
"create a basic room"    → Creates room with walls
"make a room"            → Creates room structure
```

#### Lighting
```
"add a light"            → Adds directional light
"create a light"         → Adds directional light
"add point light"        → Adds point light
"add spot light"         → Adds spot light
```

### 📐 Level Templates

#### Platformer
```
"create a platformer"    → Complete platformer level
"create platformer level" → Platforms + spawn + goal
"make a platformer"      → Platformer template
```

#### Maze
```
"create a maze"          → 10x10 maze with walls
"generate a maze"        → Maze template
"create labyrinth"       → Maze structure (German)
```

#### Arena
```
"create an arena"        → Circular battle arena
"make an arena"          → Arena with walls
"generate arena"         → Arena template
```

#### Race Track
```
"create a race track"    → Track with waypoints
"make a race track"      → Racing level
"generate race track"    → Race course
```

### 📊 Analysis Commands

#### Scene Analysis
```
"analyze scene"          → Full scene analysis
"analyze the scene"      → Performance metrics
"check scene"            → Scene statistics
"optimize scene"         → Optimization tips
```

#### Find Issues
```
"find missing scripts"   → Locate broken references
"find empty objects"     → Find empty GameObjects
"check performance"      → Performance report
```

### 💻 Code Generation

#### Movement Scripts
```
"show movement script"   → Player movement code
"give me movement code"  → Movement template
"movement script"        → WASD + jump script
"bewegung script"        → Movement (German)
```

#### Rotation Scripts
```
"show rotation script"   → Object rotation code
"rotation code"          → Rotation template
"how to rotate"          → Rotation example
```

#### Trigger Systems
```
"show trigger script"    → Trigger zone code
"trigger example"        → OnTrigger events
"collision code"         → Collision handling
```

#### Advanced Patterns
```
"singleton pattern"      → Singleton example
"show singleton"         → Manager pattern
"coroutine example"      → Coroutine code
"show coroutine"         → Wait/delay example
"object pooling"         → Pooling system
"show pool"              → Pool pattern
```

### 🎨 Material Commands

#### Create Materials
```
"create a material"      → Basic white material
"create material"        → New material asset
"make a material"        → Material creation
```

#### Emissive Materials
```
"create emissive material" → Glowing material
"emissive material"        → Light-emitting mat
"glowing material"         → Emissive preset
```

### 🔧 Object Arrangement

#### Via Chat
```
"arrange in line"        → Line up selected objects
"arrange in circle"      → Circular arrangement
"organize objects"       → Arrangement options
```

#### Via Menu
```
AI Assistant > Level Design > Arrange in Line
AI Assistant > Level Design > Arrange in Circle
```

### ❓ Help & Information

```
"help"                   → Show help information
"what can you do"        → List capabilities
"show commands"          → Command overview
```

## 🎯 Quick Actions Menu

Access common operations directly from the menu:

### Quick Actions
- `AI Assistant > Quick Actions > Create Grid 5x5`
- `AI Assistant > Quick Actions > Create Basic Room`
- `AI Assistant > Quick Actions > Add Directional Light`

### Analysis
- `AI Assistant > Analysis > Analyze Current Scene`
- `AI Assistant > Analysis > Find Missing Scripts`
- `AI Assistant > Analysis > Find Empty GameObjects`

### Level Design
- `AI Assistant > Level Design > Arrange in Line`
- `AI Assistant > Level Design > Arrange in Circle`

### Templates
- `AI Assistant > Templates > Platformer Level`
- `AI Assistant > Templates > Maze`
- `AI Assistant > Templates > Arena`
- `AI Assistant > Templates > Race Track`

### Materials
- `AI Assistant > Materials > Create Basic Material`
- `AI Assistant > Materials > Create Emissive Material`

### Settings
- `AI Assistant > Settings` - Open preferences

### Help
- `AI Assistant > Help > Documentation`
- `AI Assistant > Help > About`

## 🌐 Multi-Language Support

### English Commands
All commands work in English (default)

### German Commands (Deutsch)
```
"erstelle einen Würfel"  → Create cube
"erstelle ein Raster"    → Create grid
"erstelle einen Raum"    → Create room
"analysiere die Szene"   → Analyze scene
"zeige Bewegung Script"  → Show movement script
"erstelle Material"      → Create material
```

## ⚙️ Settings & Preferences

Access via `AI Assistant > Settings`:

- **Default Grid Size**: Set preferred grid dimensions (2-20)
- **Default Spacing**: Set object spacing (0.5-10 units)
- **Auto-Select**: Automatically select created objects
- **Show Tips**: Display helpful tips in responses
- **Language**: Choose English or Deutsch

## 🎨 Advanced Usage

### Combining Commands
Create complex scenes with sequential commands:
```
1. "create a basic room"
2. "add a light"
3. "create a 5x5 grid"
4. "create emissive material"
5. "analyze scene"
```

### Workflow Examples

#### Quick Prototype
```
1. Create room
2. Add lighting
3. Generate grid for gameplay elements
4. Analyze for issues
```

#### Level Design
```
1. Choose template (platformer/maze/arena)
2. Add custom objects
3. Arrange in patterns
4. Optimize scene
```

#### Learning Unity
```
1. Ask for code snippets
2. Study the generated code
3. Customize for your needs
4. Apply to your project
```

## 🎹 Keyboard Shortcuts

- **Ctrl + Enter**: Submit prompt in chat window
- **Clear Button**: Reset conversation history

## 💡 Pro Tips

1. **Be Specific**: "Create 3x3 grid" is better than "create grid"
2. **Use Natural Language**: Both "create cube" and "make a cube" work
3. **Chain Commands**: Build complexity step by step
4. **Use Analysis**: Check scene regularly for issues
5. **Explore Templates**: Start with templates, then customize
6. **Save Settings**: Configure preferences for your workflow
7. **Read Responses**: Tips and suggestions are included
8. **Undo Support**: All operations support Ctrl+Z

## 🔍 Troubleshooting Quick Reference

### Command Not Working?
- Check Console for errors
- Verify you have a scene open
- Try simpler command first
- Check spelling

### Objects Not Appearing?
- Check they're not at origin with camera
- Look in Hierarchy panel
- Check Console for errors

### Menu Items Missing?
- Restart Unity
- Reimport Assets/AIAssistant folder
- Check for compilation errors

## 📚 Learning Path

### Beginner
1. Start with basic creation: "create cube"
2. Try grid generation: "create 5x5 grid"
3. Add lighting: "add a light"
4. Analyze your work: "analyze scene"

### Intermediate
1. Use templates: "create platformer"
2. Arrange objects: "arrange in circle"
3. Generate materials: "create material"
4. Get code snippets: "show movement script"

### Advanced
1. Combine multiple commands
2. Create custom workflows
3. Use preferences for optimization
4. Integrate into existing projects

## 🎓 Example Sessions

### Session 1: Empty Scene → Basic Level
```
User: "create a basic room"
AI: ✓ Created a basic room (10x10x3 units)

User: "add a light"
AI: ✓ Created a Directional Light

User: "create a 3x3 grid"
AI: ✓ Created a 3x3 grid of cubes with 2 unit spacing

User: "analyze scene"
AI: Scene Analysis Results:
    Total GameObjects: 15
    Lights: 1
    Performance: Good
```

### Session 2: Code Learning
```
User: "show me a movement script"
AI: [Displays complete movement script with WASD + jump]

User: "show trigger example"
AI: [Displays trigger zone with events]

User: "singleton pattern"
AI: [Displays GameManager singleton]
```

### Session 3: Quick Prototype
```
User: "create arena"
AI: ✓ Created an arena with 10 unit radius

User: "add point light"
AI: ✓ Created a Point Light

User: "create emissive material"
AI: ✓ Created emissive material in Assets folder
```

## 🌟 Best Practices

1. **Start Simple**: Begin with basic commands
2. **Build Incrementally**: Add complexity gradually
3. **Use Analysis**: Check scene health regularly
4. **Organize**: Use parent objects for structure
5. **Customize**: Adapt generated code to your needs
6. **Experiment**: Try different commands and patterns
7. **Read Docs**: Check examples for inspiration

## 📖 Additional Resources

- **README.md**: Full feature documentation
- **QUICKSTART.md**: 5-minute getting started
- **EXAMPLES.md**: Real-world workflows
- **INSTALLATION.md**: Setup instructions
- **CHANGELOG.md**: Version history
- **PROJECT_SUMMARY.md**: Technical overview

## 🤝 Getting Help

1. Click "Help" button in AI Assistant window
2. Type "help" in chat
3. Check documentation files
4. Visit GitHub repository
5. Check Unity Console for errors

---

**Ready to create amazing Unity projects faster!** 🚀

Start with a simple command and explore from there. The AI Assistant is here to help you build better, faster!

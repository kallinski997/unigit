# Installation Guide - AI Assistant for Unity

## System Requirements

- **Unity Version**: 2020.3 or newer
- **Operating System**: Windows, macOS, or Linux
- **Disk Space**: ~5 MB
- **Dependencies**: None (standalone plugin)

## Installation Methods

### Method 1: Manual Installation (Recommended)

1. **Download the Plugin**
   - Download or clone the repository
   - Locate the `Assets/AIAssistant` folder

2. **Copy to Your Project**
   ```
   YourUnityProject/
   └── Assets/
       └── AIAssistant/    <- Copy this entire folder here
   ```

3. **Wait for Compilation**
   - Unity will automatically detect and compile the plugin
   - Check the Console for any errors (there should be none)

4. **Verify Installation**
   - Look for `AI Assistant` menu in the Unity menu bar
   - Try opening `Window > AI Assistant`

### Method 2: Unity Package Manager (Git URL)

1. **Open Package Manager**
   - Go to `Window > Package Manager`

2. **Add Package from Git URL**
   - Click the `+` button
   - Select "Add package from git URL"
   - Enter: `https://github.com/kallinski997/unigit.git?path=/Assets/AIAssistant`

3. **Wait for Installation**
   - Unity will download and install the package

### Method 3: Unity Package (.unitypackage)

1. **Import Package**
   - Download the `.unitypackage` file
   - In Unity: `Assets > Import Package > Custom Package`
   - Select the downloaded file
   - Click "Import"

## Post-Installation Setup

### 1. Open AI Assistant

```
Window > AI Assistant
```

or

```
AI Assistant > Open Window
```

### 2. Test the Installation

Try these commands in the AI Assistant window:
```
"create a cube"
"analyze scene"
"show me a movement script"
```

### 3. Explore the Menu

Check out the menu items:
```
AI Assistant >
  ├── Open Window
  ├── Quick Actions
  ├── Analysis
  ├── Level Design
  ├── Templates
  ├── Materials
  ├── Settings
  └── Help
```

## Troubleshooting

### Issue: Menu Items Don't Appear

**Solution:**
1. Restart Unity
2. Check Console for compilation errors
3. Verify the `Assets/AIAssistant` folder structure is intact
4. Reimport the plugin: Right-click folder > Reimport

### Issue: Window Won't Open

**Solution:**
1. Check Console for errors
2. Verify assembly definitions compiled successfully
3. Try: `Assets > Reimport All`
4. Delete `Library` folder and reopen project

### Issue: Scripts Don't Compile

**Solution:**
1. Check Unity version (must be 2020.3+)
2. Look for compilation errors in Console
3. Verify no conflicting namespaces
4. Check that `.asmdef` files are present:
   - `Editor/UniGit.AIAssistant.Editor.asmdef`
   - `Runtime/UniGit.AIAssistant.Runtime.asmdef`

### Issue: Commands Don't Work

**Solution:**
1. Make sure you have a scene open
2. Check that you're typing valid commands
3. Look in Console for any error messages
4. Try simpler commands first: "create cube"

### Issue: Missing References

**Solution:**
1. The plugin is editor-only, safe for builds
2. If you see missing references, verify:
   - All `.cs` files are in correct folders
   - Assembly definitions are properly set up
3. Try deleting and re-importing the plugin

## Verification Checklist

After installation, verify these work:

- [ ] AI Assistant window opens
- [ ] Can type and submit prompts
- [ ] Menu items appear under "AI Assistant"
- [ ] "Create cube" command works
- [ ] Scene analysis works
- [ ] Code snippets display correctly
- [ ] No console errors

## Updating the Plugin

### To Update:

1. **Backup Your Settings**
   - Export any custom configurations

2. **Remove Old Version**
   - Delete the `Assets/AIAssistant` folder

3. **Install New Version**
   - Follow installation method above

4. **Verify Update**
   - Check version in `AI Assistant > Help > About`

## Uninstallation

### To Remove:

1. **Close AI Assistant Window** (if open)

2. **Delete Folder**
   ```
   Delete: Assets/AIAssistant/
   ```

3. **Clean Up Preferences** (optional)
   - Delete EditorPrefs via menu: `Edit > Clear All PlayerPrefs`
   - Or delete specific preferences manually

4. **Restart Unity**
   - Unity will remove compiled assemblies

## Platform-Specific Notes

### Windows
- No special requirements
- Works with all Unity versions 2020.3+

### macOS
- No special requirements
- Tested on macOS 10.15+

### Linux
- No special requirements
- Tested on Ubuntu 20.04+

## Network and Firewall

This plugin:
- ✅ Works completely offline
- ✅ No internet connection required
- ✅ No external API calls
- ✅ No telemetry or analytics
- ✅ All processing happens locally

## Build Considerations

The plugin is **editor-only** and:
- ✅ Won't be included in builds
- ✅ Won't affect build size
- ✅ Won't affect runtime performance
- ✅ Safe for all platforms

Only the `Runtime` components will be included if you:
- Explicitly add `AIAssistantComponent` to GameObjects
- These are minimal and optional

## Getting Help

If you encounter issues:

1. **Check Documentation**
   - Read the README.md
   - Check EXAMPLES.md

2. **Console Logs**
   - Look for error messages
   - Enable stack traces

3. **GitHub Issues**
   - Search existing issues
   - Create new issue with:
     - Unity version
     - Error messages
     - Steps to reproduce

4. **Community Support**
   - Unity Forums
   - Discord communities
   - Stack Overflow

## Next Steps

After successful installation:

1. Read the [Quick Start Guide](QUICKSTART.md)
2. Try the [Examples](Examples/EXAMPLES.md)
3. Explore the [Full Documentation](README.md)
4. Check out the menu items
5. Experiment with prompts!

---

**Congratulations!** You're ready to use AI Assistant for Unity! 🎉

Start with simple commands and explore the features. Happy developing!

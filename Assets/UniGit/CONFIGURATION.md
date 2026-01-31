# Example API Configuration

This document shows example configurations for different AI providers.

## OpenAI Configuration

```
API Endpoint: https://api.openai.com/v1/chat/completions
Model: gpt-3.5-turbo or gpt-4
API Key: sk-... (get from https://platform.openai.com/api-keys)
Temperature: 0.7
Max Tokens: 2000
```

## Azure OpenAI Configuration

```
API Endpoint: https://YOUR-RESOURCE-NAME.openai.azure.com/openai/deployments/YOUR-DEPLOYMENT-NAME/chat/completions?api-version=2023-05-15
Model: YOUR-DEPLOYMENT-NAME
API Key: YOUR-AZURE-API-KEY
Temperature: 0.7
Max Tokens: 2000
```

## Custom System Prompts

### Unity Scripting Expert
```
You are an expert Unity developer specializing in C# scripting. You provide clean, efficient code examples and explain Unity-specific patterns and best practices.
```

### Performance Optimization Specialist
```
You are a Unity performance optimization specialist. Focus on identifying bottlenecks, suggesting optimization strategies, and explaining performance best practices.
```

### Game Design Assistant
```
You are a game design consultant for Unity projects. Help with gameplay mechanics, level design, user experience, and game feel.
```

### Shader Programming Expert
```
You are an expert in Unity shader programming and graphics. Help with shader development, visual effects, and rendering optimization.
```

## Context Settings

### Minimal Context (Faster, Lower Cost)
- Include Project Context: ❌
- Include Scene Context: ❌
- Good for: General Unity questions

### Balanced (Recommended)
- Include Project Context: ✅
- Include Scene Context: ❌
- Good for: Most use cases

### Full Context (Most Accurate)
- Include Project Context: ✅
- Include Scene Context: ✅
- Good for: Specific scene or object questions

## Security Best Practices

1. **Never commit API keys to version control**
   - Add `**/AIAssistantConfig.asset` to `.gitignore`

2. **Use environment-specific configs**
   - Different configs for development/production
   - Share configs without API keys

3. **Rotate API keys regularly**
   - Change keys periodically
   - Revoke old keys

4. **Monitor API usage**
   - Track costs
   - Set usage limits

## Troubleshooting Common Issues

### Issue: "API Key Required"
**Solution**: Enter a valid API key in Settings

### Issue: "Connection Error"
**Solutions**:
- Check internet connection
- Verify API endpoint URL
- Check firewall settings

### Issue: Rate Limit Errors
**Solutions**:
- Wait before retrying
- Reduce request frequency
- Upgrade API plan

### Issue: Slow Responses
**Solutions**:
- Use faster model (gpt-3.5-turbo)
- Reduce Max Tokens
- Disable Scene Context for large scenes

### Issue: Poor Quality Answers
**Solutions**:
- Improve System Prompt
- Enable Project/Scene Context
- Use more capable model (gpt-4)
- Be more specific in questions

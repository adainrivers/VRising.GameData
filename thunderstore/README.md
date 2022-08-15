# Still WIP, use it at your own risk.

# VRising Game Data Library

See [V Rising Database](https://gaming.tools/v-rising) for detailed information about V Rising items, NPCs and more.

## Installation

Install the NuGet package `GT.VRising.GameData`

## Usage

- Add BepInDependency to your plugin:

```csharp
    [BepInDependency("GT.VRising.GameData")]
    public class Plugin : BasePlugin
```

- Optionally, add the following to your Plugin's `Load()` method. You shouldn't access any of the `GameData` properties before initialization is done.: 

```csharp
public override void Load()
{
    // ... other code
    GameData.OnInitialize += GameDataOnInitialize;
    // ... other code
}
```

- Sample initialization method:

```csharp
private static void GameDataOnInitialize(World world)
{
    // Here you can start using the methods like these:
    Logger.LogWarning("All Users:");
    foreach (var userModel in GameData.Users.All)
    {
        Logger.LogMessage($"{userModel.CharacterName} Connected: {userModel.IsConnected}");
    }

    var weapons = GameData.Items.Weapons.Take(10);
    Logger.LogWarning("Some Weapons:");
    foreach (var itemModel in weapons)
    {
        Logger.LogMessage($"{itemModel.Name}");
    }
}
```
- Remove the event hook in your plugin's `Unload()` method:

```csharp
public override bool Unload()
{
    // ... other code
    GameData.OnInitialize -= GameData_OnInitialize;
    // ... other code
    return true;
}
```

See the sample project here: 

https://github.com/adainrivers/VRising.GameData/tree/main/src/VRising.GameData.SamplePlugin

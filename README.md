# VRising Game Data Library

See [V Rising Database](https://gaming.tools/v-rising) for detailed information about V Rising items, NPCs and more.

## Installation

Install the NuGet package `VRising.GameData`

## Distribution

You can embed the library using https://github.com/Fody/Costura.

- Add `Costura.Fody` NuGet package to your project.
- Update your FodyWeavers.xml to look like this:
```xml
<Weavers xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="FodyWeavers.xsd">
  <Costura>
    <IncludeAssemblies>
      VRising.GameData
    </IncludeAssemblies>
  </Costura>
</Weavers>
```
- Build your plugin and you are done.

## Usage

- Add it to your Plugin's `Load()` method: 

```csharp
public override void Load()
{
    // ... other code
    GameData.Create();
    GameData.OnInitialize += GameDataOnInitialize;
    // ... other code
}
```

- Create the initialization method

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
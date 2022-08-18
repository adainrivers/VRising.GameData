# Still WIP, use it at your own risk.

# VRising Game Data Library

See [V Rising Database](https://gaming.tools/v-rising) for detailed information about V Rising items, NPCs and more.

## Installation

Install the NuGet package `VRising.GameData`

Add the following lines to your plugin's .csproj file:

To the `PropertyGroup`:
```xml
<CopyLocalLockFileAssemblies>true</CopyLocalLockFileAssemblies>
```

To the references `ItemGroup`:
```xml
<PackageReference Include="Fody" Version="6.6.3" PrivateAssets="all" />
<PackageReference Include="ILMerge.Fody" Version="1.23.0" PrivateAssets="all" />
```

And update the FodyWeavers.xml to look like this:

```xml
<?xml version="1.0" encoding="utf-8"?>
<Weavers xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="FodyWeavers.xsd">
  <ILMerge NamespacePrefix="PluginName_" IncludeAssemblies="VRising.GameData">
  </ILMerge>
</Weavers>
```

Replace `PluginName` with your plugin's name. If you have more assemblies to add, separate the with the pipe `|` character. For example:
```xml
<?xml version="1.0" encoding="utf-8"?>
<Weavers xmlns:xsi="http://www.w3.org/2001/XMLSchema-instance" xsi:noNamespaceSchemaLocation="FodyWeavers.xsd">
  <ILMerge NamespacePrefix="RandomEncounters_" IncludeAssemblies="VRising.GameData|Wetstone">
  </ILMerge>
</Weavers>
```

## Usage

Optionally, add the following to your Plugin's `Load()` method. You shouldn't access any of the `GameData` properties before initialization is done.: 

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
Remove the event hook in your plugin's `Unload()` method:

```csharp
public override bool Unload()
{
    // ... other code
    GameData.OnInitialize -= GameData_OnInitialize;
    // ... other code
    return true;
}
```

After the initialization is done, you can access to the `GameData` class from anywhere of your plugin code.

See the sample project here: 

https://github.com/adainrivers/VRising.GameData/tree/main/src/VRising.GameData.SamplePlugin

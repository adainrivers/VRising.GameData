using System.Collections.Generic;
using System.Text;
using Il2CppSystem.IO;
using PluralizeService.Core;
using ProjectM;
using ProjectM.Network;
using Unity.Collections;
using Unity.Entities;
using VRising.GameData.ClassGenerator.Utils;
using Wetstone.API;

namespace VRising.GameData.ClassGenerator
{
    internal class ClassGenerator
    {
        private const string ModelsFolder = @"D:\VRising\Development\VRising.GameData\src\VRising.GameData\Models\Internals";
        private static readonly Dictionary<string, ComponentType> RootTypes = new Dictionary<string, ComponentType>
        {
            { "UserModel", ComponentType.ReadOnly<User>() },
            { "ItemModel", ComponentType.ReadOnly<ItemData>() },
            { "NpcModel", ComponentType.ReadOnly<AggroConsumer>() },
            { "CharacterModel", ComponentType.ReadOnly<PlayerCharacter>() },
        };
        public static void GenerateClasses()
        {
            if (VWorld.IsServer)
            {
                GenerateClasses(VWorld.Server);
            }
            else if (VWorld.IsClient)
            {
                GenerateClasses(VWorld.Client);
            }
        }

        private static void GenerateClasses(World world)
        {
            foreach (var (className, componentType) in RootTypes)
            {
                var types = new Dictionary<string, ComponentType>();
                var query = world.EntityManager.CreateEntityQuery(componentType);
                var entities = query.ToEntityArray(Allocator.Temp);
                foreach (var entity in entities)
                {
                    var componentTypes = world.EntityManager.GetComponentTypes(entity);
                    foreach (var type in componentTypes)
                    {
                        types[type.GetManagedType().AssemblyQualifiedName] = type;
                    }
                }

                var codeBuilder = new CodeBuilder(className);
                foreach (var (name, type) in types)
                {
                    codeBuilder.Add(type);
                }
                codeBuilder.EndClass();
                var destinationFilePath = Path.Combine(ModelsFolder, $"{className}.cs");
                File.WriteAllText(destinationFilePath, codeBuilder.Build());
            }
        }
    }

    public class CodeBuilder
    {
        private StringBuilder builder;
        public CodeBuilder(string className)
        {
            builder = new StringBuilder($@"using System.Collections.Generic;
using Unity.Entities;

namespace VRising.GameData.Models.Internals
{{
    public partial class {className}
    {{
        private readonly World _world;
        private readonly Entity _entity;

        internal {className}(World world, Entity entity)
        {{
            _world = world;
            _entity = entity;
        }}
");
        }

        public void Add(ComponentType type)
        {
            var managedType = type.GetManagedType();
            var typeName = managedType.FullName;
            var name = managedType.Name;
            if (typeName.Contains("+"))
            {
                return;
            }
            if (type.IsBuffer)
            {
                builder.AppendLine($"        public List<{typeName}> {PluralizationProvider.Pluralize(name)} => _world.EntityManager.GetBuffer<{typeName}>(_entity).ToList();");
            }
            else if (type.IsZeroSized)
            {
                builder.AppendLine($"        public bool {name} => _world.EntityManager.HasComponent<{typeName}>(_entity);");
            }
            else
            {
                builder.AppendLine($"        public {typeName} {name} => _world.EntityManager.GetComponentData<{typeName}>(_entity);");
            }
        }

        public void EndClass()
        {
            builder.Append(@"    }
}");
        }

        public string Build()
        {
            return builder.ToString();
        }
    }
}

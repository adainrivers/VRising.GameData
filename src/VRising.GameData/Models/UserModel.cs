using GT.VRising.GameData.Models.Base;
using ProjectM.Network;
using ProjectM.Shared;
using Unity.Entities;
using Unity.Mathematics;

namespace GT.VRising.GameData.Models
{
    public partial class UserModel : EntityModel
    {
        internal UserModel(Entity entity) : base(entity)
        {
            Character = new CharacterModel(Internals.User.LocalCharacter._Entity);
            Inventory = new InventoryModel(Character);
        }

        public InventoryModel Inventory { get; }
        public CharacterModel Character { get; }

        public string CharacterName => Internals.User?.CharacterName.ToString();
        public EquipmentModel Equipment => Character.Equipment;
        public FromCharacter FromCharacter => new() { User = Entity, Character = Character.Entity };
        public bool IsAdmin => Internals.User?.IsAdmin ?? false;
        public bool IsConnected => Internals.User?.IsConnected ?? false;
        // 637960784686678697 not sure what is this
        //public DateTime LastConnectedUtc => Internals.User.TimeLastConnected.ToDateTime();
        public ulong PlatformId => Internals.User?.PlatformId ?? 0;
        public float3 Position => Internals.LocalToWorld?.Position ?? new float3();
        public UserContentFlags UserContent => Internals.User?.UserContent ?? UserContentFlags.None;
    }
}
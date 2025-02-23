namespace FFXIVClientStructs.FFXIV.Client.Game.InstanceContent;

[StructLayout(LayoutKind.Explicit, Size = 0x1CB0)]
public unsafe struct InstanceContentDirector {
    [FieldOffset(0x00)] public ContentDirector ContentDirector;
    //[FieldOffset(0x730)] public fixed byte InstanceContentExcelRow[0xA8];
    /// <summary>
    /// The remaining time in seconds for the instance.
    /// </summary>
    [FieldOffset(0xCE4)] public InstanceContentType InstanceContentType;
}

public enum InstanceContentType : byte {
    Raid = 1,
    Dungeon = 2,
    DeepDungeon = 9,
    Trial = 4,
    BeginnerTraining = 8,
    Frontlines = 6,
    OceanFishing = 16
}

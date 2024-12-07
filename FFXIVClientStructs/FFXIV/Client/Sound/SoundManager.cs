using FFXIVClientStructs.FFXIV.Client.System.Resource;
using Thread = FFXIVClientStructs.FFXIV.Client.System.Threading.Thread;

namespace FFXIVClientStructs.FFXIV.Client.Sound;

// Client::Sound::SoundManager
//   Client::System::Resource::ResourceEventListener
//   Client::System::Threading::Thread
/// <summary>
/// This class is the low level handler for sound related functions and abstracts from the operating system.
/// The functions in this class are not intended by SE to be used directly and do not have proper checks for correct values.
/// </summary>
[GenerateInterop]
[Inherits<ResourceEventListener>]
[StructLayout(LayoutKind.Explicit, Size = 0x1C88)]
public unsafe partial struct SoundManager {
    [FieldOffset(0x0008)] public Thread Thread; // TODO: make Thread properly inheritable
    [FieldOffset(0x0031)] public bool Disabled;
    [FieldOffset(0x0034)] public float MasterVolume;
    [FieldOffset(0x0038)] public float ActiveVolume;
    [FieldOffset(0x003C), FixedSizeArray] internal FixedSizeArray21<float> _volume;
    [FieldOffset(0x0090), FixedSizeArray] internal FixedSizeArray21<float> _unkVolume2; // All are 1.0f
    [FieldOffset(0x00E4), FixedSizeArray] internal FixedSizeArray21<float> _unkVolume3; // All are 1.0f
    [FieldOffset(0x0138), FixedSizeArray] internal FixedSizeArray21<float> _unkVolume4; // All are 1.0f
    [FieldOffset(0x018C), FixedSizeArray] internal FixedSizeArray21<float> _unkVolume5; // All are 1.0f
    [FieldOffset(0x01D8), FixedSizeArray] internal FixedSizeArray21<bool> _channelMuted;
    [FieldOffset(0x01ED), FixedSizeArray] internal FixedSizeArray21<bool> _channelMutedInBackground;

    [FieldOffset(0x0241)] public bool IsMasterMuted;
    [FieldOffset(0x0242)] public bool MuteSoundWhenInactive;
    [FieldOffset(0x0243)] public bool IsSoundMuted;
    [FieldOffset(0x0244)] public bool WindowInactive;

    [FieldOffset(0x0320)] public nint CriticalSection;

    [FieldOffset(0x0348)] public nint EventHandle;

    /// <summary>
    /// Calculates effective volume
    /// </summary>
    /// <param name="channel">The specific sound channel. This is different from the channels visible to the user</param>
    /// <returns>Volume in the ange 0-1</returns>
    [MemberFunction("F3 0F 10 0D ?? ?? ?? ?? 48 63 C2")]
    public partial float GetEffectiveVolume(int channel);

    ///<inheritdoc cref="GetEffectiveVolume(int)"/>
    public float GetEffectiveVolume(SoundChannel channel) => GetEffectiveVolume((int)channel);

    /// <summary>
    /// Sets channel volume
    /// </summary>
    /// <param name="channel">The specific sound channel. This is different from the channels visible to the user</param>
    /// <param name="volume">Volume in the ange 0-1</param>
    /// <param name="p3">unknown</param>
    [MemberFunction("E8 ?? ?? ?? ?? FF C7 D1 EB")]
    public partial void SetVolume(int channel, float volume, int p3 = 100);

    ///<inheritdoc cref="SetVolume(int,float,int)"/>
    public void SetVolume(SoundChannel channel, float volume, int p3 = 100) => SetVolume((int)channel, volume, p3);

    [MemberFunction("48 89 5C 24 ?? 57 48 83 EC 20 80 79 31 00 0F B6 FA 48 8B D9 75 2B")]
    public partial void SetMasterEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 8B D7")] // someone should find a better sig for this
    public partial void SetBgmEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 8B D7")]
    public partial void SetSoundEffectsEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 8B D7")]
    public partial void SetVoiceEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 8B D7")]
    public partial void SetSystemEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 83 FF 01 0F 94 C2 E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 8B D7")]
    public partial void SetEnvironmentEnabled(bool enabled);

    [MemberFunction("E8 ?? ?? ?? ?? E9 ?? ?? ?? ?? 48 8B 8E ?? ?? ?? ?? 8B D7")]
    public partial void SetPerfomEnabled(bool enabled);

    public enum SoundChannel : int {
        Bgm1 = 1,
        Se1 = 2,
        Voice = 3,
        System = 4,
        Env1 = 5,
        Se2 = 6,
        Se3 = 7,
        Bgm2 = 8,
        Bgm3 = 9,
        Env2 = 11,
        Env3 = 12,
        Bgm4 = 16,
        Perform = 17
    }
}

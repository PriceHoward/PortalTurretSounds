using BepInEx;
using HarmonyLib;
using UnityEngine;
using PortalTurret.Patches;

namespace PortalTurretSoundsMod
{
    [BepInPlugin("PortalTurretSounds", "PortalTurretSounds", "0.1.0")]
    public class PortalTurretSounds : BaseUnityPlugin
    {
        private readonly Harmony harmony = new Harmony("PortalTurretSounds");
        private static PortalTurretSounds Instance;
        internal static AudioClip activated_sound;
        internal static AudioClip deactivated_sound;
        internal static AudioClip target_aquired_sound;


        private void Awake()
        {
            if ((Object)(object)Instance == (Object)null)
            {
                Instance = this;
            }

            Logger.LogInfo("Portal Turret Sounds is Activating.");

            string folderLocation = ((BaseUnityPlugin)Instance).Info.Location;
            if (string.IsNullOrEmpty(folderLocation))
            {
                Logger.LogError((object)"Failed to locate the file.");
                return;
            }
            string dllName = "PortalTurret.dll";
            string trimDllName = folderLocation.TrimEnd(dllName.ToCharArray());
            AssetBundle assets = AssetBundle.LoadFromFile(trimDllName + "portalsounds");
            if ((Object)(object)assets == (Object)null)
            {
                Logger.LogError((object)"Failed to load the audio files in the assets.");
                return;
            }

            activated_sound = assets.LoadAsset<AudioClip>("Assets/activated.wav");
            deactivated_sound = assets.LoadAsset<AudioClip>("Assets/sleep_mode.wav");
            target_aquired_sound = assets.LoadAsset<AudioClip>("Assets/target_aquired.wav");

            harmony.PatchAll(typeof(TurretPatch));

            Logger.LogInfo((object)"Portal Turret Sounds Now Activated.");


        }

    }
}

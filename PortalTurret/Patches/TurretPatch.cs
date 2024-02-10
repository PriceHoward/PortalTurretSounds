using HarmonyLib;
using UnityEngine;
using PortalTurretSoundsMod;

namespace PortalTurret.Patches
{
    [HarmonyPatch(typeof(Turret))]
    internal class TurretPatch
    {
        [HarmonyPatch("Start")]
        [HarmonyPostfix]
        public static void turretSoundPatch(ref AudioClip ___turretActivate, ref AudioClip ___turretDeactivate, ref AudioClip ___detectPlayerSFX)
        {
            ___turretActivate = PortalTurretSounds.activated_sound;
            ___turretDeactivate = PortalTurretSounds.deactivated_sound;
            ___detectPlayerSFX = PortalTurretSounds.target_aquired_sound;
        }
    }
}

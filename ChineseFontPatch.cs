using System.IO;
using TMPro;
using BepInEx;
using HarmonyLib;
using UnityEngine;

namespace ChineseFontPatch
{
	[BepInPlugin("ChineseFontPatch", "Chinese Font Patch", "1.0")]
	public class ChineseFontPatch : BaseUnityPlugin
	{
		public static TMP_FontAsset s_font;
		public static float c_outline;

		void Awake()
		{
			string path = Path.Combine(Paths.PluginPath, Config.Bind("General", "Font Asset", "FontAsset-SIMYOU", "The font asset located in plugins folder.").Value);
			var assetBundle = AssetBundle.LoadFromFile(path);

			if (assetBundle == null)
				Logger.LogWarning("Missing AssetBundle: " + path);
			else
			{
				s_font = assetBundle.LoadAsset<TMP_FontAsset>(Config.Bind("General", "Font Name", "Arial SDF", "The name of font included in font asset.").Value);
				Logger.LogDebug("AssetBundle loaded: " + path + "\nFont loaded: " + s_font.name);
			}

			c_outline = Config.Bind<float>("General", "Font Outline", 0.1f, "The outline width of font.").Value;

			var harmony = new Harmony("ChineseFontPatch");
			harmony.PatchAll(typeof(TextMeshProUGUIPatch));
		}
	}

	class TextMeshProUGUIPatch
	{
		[HarmonyPatch(typeof(TextMeshProUGUI), "SetLayoutDirty")]
		[HarmonyPostfix]
		static void TMPEnablePatch(TextMeshProUGUI __instance, CanvasRenderer ___m_canvasRenderer)
		{
			if (__instance != null)
			{
				if (ChineseFontPatch.s_font != null)
				{
					if (!__instance.font.fallbackFontAssetTable.Contains(ChineseFontPatch.s_font))
						__instance.font.fallbackFontAssetTable.Add(ChineseFontPatch.s_font);
					if (___m_canvasRenderer != null)
						__instance.outlineWidth = ChineseFontPatch.c_outline;
				}
			}
		}
	}
}

﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Harmony;
using static Common_Utils.Plugin;

namespace Common_Utils
{
	[HarmonyPatch(typeof(CharacterClassManager), nameof(CharacterClassManager.SetPlayersClass))]
	class StartItemsPatch
	{
		public static bool everRun = false;
		[HarmonyPriority(500)]
		public static void Prefix(CharacterClassManager __instance, RoleType classid)
		{
			List<ItemType> Inventory = new List<ItemType>();
			
			switch (classid)
			{
				case RoleType.ClassD:
					if (Instance.EnableRandomInv)
					{
						foreach (KeyValuePair<ItemType, int> item in Instance.Inventories.ClassDRan)
						{
							if (Instance.Gen.Next(100) <= item.Value)
								Inventory.Add(item.Key);
						}
					}
					else
						Inventory = Instance.Inventories.ClassD;
					break;
				case RoleType.ChaosInsurgency:
					if (Instance.EnableRandomInv)
					{
						foreach (KeyValuePair<ItemType, int> item in Instance.Inventories.ChaosRan)
						{
							if (Instance.Gen.Next(100) <= item.Value)
								Inventory.Add(item.Key);
						}
					}
					else
						Inventory = Instance.Inventories.Chaos;
					break;
				case RoleType.NtfCadet:
					if (Instance.EnableRandomInv)
					{
						foreach (KeyValuePair<ItemType, int> item in Instance.Inventories.NtfCadetRan)
						{
							if (Instance.Gen.Next(100) <= item.Value)
								Inventory.Add(item.Key);
						}
					}
					else
						Inventory = Instance.Inventories.NtfCadet;
					break;
				case RoleType.NtfCommander:
					if (Instance.EnableRandomInv)
					{
						foreach (KeyValuePair<ItemType, int> item in Instance.Inventories.NtfCmdRan)
						{
							if (Instance.Gen.Next(100) <= item.Value)
								Inventory.Add(item.Key);
						}
					}
					else
						Inventory = Instance.Inventories.NtfCommander;
					break;
				case RoleType.NtfLieutenant:
					if (Instance.EnableRandomInv)
					{
						foreach (KeyValuePair<ItemType, int> item in Instance.Inventories.NtfLtRan)
						{
							if (Instance.Gen.Next(100) <= item.Value)
								Inventory.Add(item.Key);
						}
					}
					else
						Inventory = Instance.Inventories.NtfLieutenant;
					break;
				case RoleType.NtfScientist:
					if (Instance.EnableRandomInv)
					{
						foreach (KeyValuePair<ItemType, int> item in Instance.Inventories.NtfSciRan)
						{
							if (Instance.Gen.Next(100) <= item.Value)
								Inventory.Add(item.Key);
						}
					}
					else
						Inventory = Instance.Inventories.NtfScientist;
					break;
				case RoleType.Scientist:
					if (Instance.EnableRandomInv)
					{
						foreach (KeyValuePair<ItemType, int> item in Instance.Inventories.ScientistRan)
						{
							if (Instance.Gen.Next(100) <= item.Value)
								Inventory.Add(item.Key);
						}
					}
					else
						Inventory = Instance.Inventories.Scientist;
					break;
				case RoleType.FacilityGuard:
					if (Instance.EnableRandomInv)
					{
						foreach (KeyValuePair<ItemType, int> item in Instance.Inventories.GuardRan)
						{
							if (Instance.Gen.Next(100) <= item.Value)
								Inventory.Add(item.Key);
						}
					}
					else
						Inventory = Instance.Inventories.Guard;
					break;
				default:
					Inventory = CustomInventory.ConvertToItemList(KConf.ExiledConfiguration.GetListStringValue(EXILED.Plugin.Config.GetString($"util_{classid.ToString().ToLowerInvariant()}_inventory", null)));
					break;
			}
			if (Inventory != null)
			{
				__instance.Classes.SafeGet(classid).startItems = Inventory.ToArray();
			}
		}
	}
}

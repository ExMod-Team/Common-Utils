namespace Common_Utilities.API;

using System.Collections.Generic;
using Exiled.API.Features;
using PlayerRoles;

public static class API
{
    // API methods for potential use by other plugins, not sure if anyone actually uses this
    public static float GetHealthOnKill(RoleTypeId role) => Plugin.Instance.Config.HealthOnKill?.ContainsKey(role) ?? false ? Plugin.Instance.Config.HealthOnKill[role] : 0f;
    
    public static List<ItemType> GetStartItems(RoleTypeId role, Player player = null) => Plugin.Instance.playerHandlers.GetStartingInventory(role, player);
}
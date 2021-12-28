﻿using BepInEx;
using BepInEx.Logging;
using Bindito.Core;
using HarmonyLib;
using TimberAPIExample.AutoConfiguratorInstaller;
using TimberAPIExample.Examples.UIBuilderExample.UIBuilderPreviewPanel;
using Timberborn.SingletonSystem;
using Timberborn.TimeSystem;
using Timberborn.ToolSystem;
using UnityEngine;
using Timberborn.FactionSystem;
using Timberborn.WeatherSystem;
using TimberbornAPI;
using TimberbornAPI.EventSystem;
using TimberbornAPI.Common;
using TimberbornAPI.UIBuilderSystem;

namespace TimberAPIExample
{
    /// <summary>
    /// Example TimberAPI/BepInEx Plugin showing the power of the API
    /// </summary>
    [BepInPlugin("com.timberapi.example", "TimberAPIExample", "0.2.0")]
    [BepInDependency("com.timberapi.timberapi")]
    [HarmonyPatch]
    public class TimberAPIExamplePlugin : BaseUnityPlugin
    {

        internal static ManualLogSource Log;

        public void Awake()
        {
            // Saves the logger instance
            Log = Logger;
            // Register our configurator
            TimberAPI.DependecyRegistry.AddConfigurator(new ExampleConfigurator());
            // Add a label to localization
            TimberAPI.Localization.AddLabel("ExampleMod.ToolGroups.ExampleToolGroup", "Example Label");
            
            // Harmony patches
            new Harmony("com.timberapi.examples").PatchAll();
            
            Logger.LogInfo("TimberAPIExample is loaded!");

            // Adds in game assets with the prefix TimberAPIExample, default folder is assets
            TimberAPI.AssetRegistry.AddSceneAssets("TimberAPIExample", SceneEntryPoint.InGame);
            // Alternatively, add in game assets with prefix TimberAPIExample with custom location > assets > ingame.
            // TimberAPI.AssetLoaderSystem.AddSceneAssets("TimberAPIExample", IAssetLoaderSystem.EntryPoint.InGame, new []{ "assets", "ingame" });

            // This is only for the example mod to provide automatic configurators.
            InstallAutoConfigurators();
            TimberAPI.DependecyRegistry.AddConfigurator(new UIBuilderPanelConfigurator(), SceneEntryPoint.Global);
        }

        public void InstallAutoConfigurators()
        {
            TimberAPI.DependecyRegistry.AddConfigurator(new AutoConfiguratorInGame());
            TimberAPI.DependecyRegistry.AddConfigurator(new AutoConfiguratorMainMenu());
            TimberAPI.DependecyRegistry.AddConfigurator(new AutoConfiguratorEditor());
        }
    }

    /**
     * Example use of localization label in a ToolGroup
     */
    public class ExampleToolGroup : ToolGroup
    {

        public override string IconName => "PriorityToolGroupIcon";

        public override string DisplayNameLocKey => "ExampleMod.ToolGroups.ExampleToolGroup";
    }

    /**
     * Example IConfigurator for dependency injection
     * 1. Use Bind to inject the class, and 2. Add it via TimberAPI.Dependencies.AddConfigurator
     */
    public class ExampleConfigurator : IConfigurator
    {
        public void Configure(IContainerDefinition containerDefinition)
        {
            containerDefinition.Bind<ExampleListener>().AsSingleton();
        }
    }

    /**
     * Example listener class. Can listen to any event with [OnEvent]
     * It automatically registers, but must be bound with an IConfigurator
     * This is not comprehensive of all events, but you can use it with any.
     */
    public class ExampleListener : EventListener
    {
        [OnEvent]
        public void OnToolGroupEntered(ToolGroupEnteredEvent toolGroupEnteredEvent)
        {
            if (toolGroupEnteredEvent.ToolGroup != null)
            {
                Debug.Log("Tool Group: " + toolGroupEnteredEvent.ToolGroup.DisplayNameLocKey);
            }
        }

        [OnEvent]
        public void OnToolEntered(ToolEnteredEvent toolEnteredEvent)
        {
            Debug.Log("ToolEnteredEvent");
        }

        [OnEvent]
        public void OnNighttimeStartEvent(NighttimeStartEvent nighttimeStartEvent)
        {
            Debug.Log("NighttimeStartEvent");
        }

        [OnEvent]
        public void OnDaytimeStartEvent(DaytimeStartEvent daytimeStartEvent)
        {
            Debug.Log("DaytimeStartEvent");
        }

        [OnEvent]
        public void OnFactionUnlocked(FactionUnlockedEvent factionUnlockedEvent)
        {
            Debug.Log("FactionUnlockedEvent");
        }

        [OnEvent]
        public void OnDroughtStarted(DroughtStartedEvent droughtStartedEvent)
        {
            Debug.Log("DroughtStartedEvent");
        }

        [OnEvent]
        public void OnDroughtEnded(DroughtEndedEvent droughtEndedEvent)
        {
            Debug.Log("DroughtEndedEvent");
        }
    }
}

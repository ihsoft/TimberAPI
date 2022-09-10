﻿using System;
using TimberApi.Common.ConsoleSystem;
using TimberApi.Core.ConfigSystem;
using TimberApi.Core.ModLoaderSystem;
using TimberApi.New.ConfigSystem;
using UnityEngine;
using Paths = TimberApi.Common.Paths;
using Versions = TimberApi.Common.Versions;

namespace TimberApi.Core
{
    internal class TimberApiCoreRunner
    {
        private readonly IInternalConsoleWriter _consoleWriter;

        private readonly ModLoader _modLoader;

        private readonly ModRepository _modRepository;

        public TimberApiCoreRunner(IInternalConsoleWriter consoleWriter, ModLoader modLoader, ModRepository modRepository, IConfigServiceFactory configServiceFactory)
        {
            _consoleWriter = consoleWriter;
            _modLoader = modLoader;
            _modRepository = modRepository;
            TimberApiCore.Configs = configServiceFactory.CreateWithAssemblyConfigs(typeof(TimberApiCoreRunner).Assembly, Paths.TimberApi, "TimberAPI");
            Run();
        }

        public void Run()
        {
            _consoleWriter.Log("TimberAPI Core", $"TimberAPI {Versions.TimberApiVersion} - Timberborn {Versions.GameVersion}, loader: {Environment.GetEnvironmentVariable("TIMBER_LOADER_TYPE")}", LogType.Log);
            _modLoader.Run();
            _modRepository.LoadMods();
        }
    }
}
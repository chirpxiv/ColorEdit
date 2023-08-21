﻿using Dalamud.IoC;
using Dalamud.Game;
using Dalamud.Plugin;
using Dalamud.Plugin.Services;

using PalettePlus.Core;

namespace PalettePlus.Services; 

internal class DalamudServices {
	private readonly DalamudPluginInterface PluginApi;
	
	// Using interfaces to future-proof here - the next API bump will require this.
	[PluginService] private ICommandManager CommandManager { get; set; } = null!;
	[PluginService] private IObjectTable ObjectTable { get; set; } = null!;
	[PluginService] private ISigScanner SigScanner { get; set; } = null!;

	internal DalamudServices(DalamudPluginInterface api) {
		this.PluginApi = api;
		api.Inject(this);
	}

	internal void AddServices(ServiceManager mgr) => mgr
		.AddInstance(this.PluginApi)
		.AddInstance(this.PluginApi.UiBuilder)
		.AddInstance(this.CommandManager)
		.AddInstance(this.ObjectTable)
		.AddInstance(this.SigScanner);
}
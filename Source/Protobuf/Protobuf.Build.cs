// Copyright Epic Games, Inc. All Rights Reserved.

using UnrealBuildTool;

public class Protobuf : ModuleRules
{
	public Protobuf(ReadOnlyTargetRules Target) : base(Target)
	{
		PCHUsage = ModuleRules.PCHUsageMode.UseExplicitOrSharedPCHs;
		
		PublicIncludePaths.AddRange(
			new string[] {
				// ... add public include paths required here ...
			}
			);
				
		
		PrivateIncludePaths.AddRange(
			new string[] {
				// ... add other private include paths required here ...
			}
			);
			
		
		PublicDependencyModuleNames.AddRange(
			new string[]
			{
				"Core",
				// ... add other public dependencies that you statically link with here ...
			}
			);
			
		
		PrivateDependencyModuleNames.AddRange(
			new string[]
			{
				"CoreUObject",
				"Engine",
				"Slate",
				"SlateCore",
				// ... add private dependencies that you statically link with here ...	
			}
			);
		
		
		DynamicallyLoadedModuleNames.AddRange(
			new string[]
			{
				// ... add any modules that your module loads dynamically here ...
			}
			);

		// Protobuf source integration
		ShadowVariableWarningLevel = WarningLevel.Off;  //bEnableShadowVariableWarnings = false;	//4.24 deprecated
		bEnableUndefinedIdentifierWarnings = false;
		bEnableExceptions = true;
		PublicDefinitions.Add("_CRT_SECURE_NO_WARNINGS");   //Definitions.Add("_CRT_SECURE_NO_WARNINGS");	// deprecated
		// Disable RTTI
		PublicDefinitions.AddRange(
			new string[]
			{
				"_CRT_SECURE_NO_WARNINGS",
				"GOOGLE_PROTOBUF_NO_RTTI=1",
			}
			);
	}
}

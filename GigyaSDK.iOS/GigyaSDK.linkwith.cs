using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("GigyaSDK.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, LinkerFlags = "-ObjC", Frameworks = "Foundation Security Social")]

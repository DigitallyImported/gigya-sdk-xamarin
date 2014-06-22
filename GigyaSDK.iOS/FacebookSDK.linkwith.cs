using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("FacebookSDK.a", LinkTarget.Simulator | LinkTarget.ArmV7 | LinkTarget.ArmV7s, ForceLoad = true)]

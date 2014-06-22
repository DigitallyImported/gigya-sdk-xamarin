using System;
using MonoTouch.ObjCRuntime;

[assembly: LinkWith ("GooglePlus.a", LinkTarget.ArmV7 | LinkTarget.ArmV7s | LinkTarget.Simulator, ForceLoad = true, LinkerFlags = "-ObjC", Frameworks = "AddressBook AssetsLibrary Foundation CoreLocation CoreMotion CoreGraphics CoreText MediaPlayer Security SystemConfiguration UIKit")]

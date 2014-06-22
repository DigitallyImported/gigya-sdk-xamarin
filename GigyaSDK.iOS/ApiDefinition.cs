using System;
using System.Drawing;

using MonoTouch.ObjCRuntime;
using MonoTouch.Foundation;
using MonoTouch.UIKit;

namespace GigyaSDK.iOS
{
    [BaseType (typeof (NSObject))]
    public partial interface GSSession {

        [Export ("isValid")]
        bool IsValid { get; }

        [Export ("token", ArgumentSemantic.Copy)]
        string Token { get; set; }

        [Export ("secret", ArgumentSemantic.Copy)]
        string Secret { get; set; }

        [Export ("expiration", ArgumentSemantic.Copy)]
        NSDate Expiration { get; set; }

        [Export ("lastLoginProvider", ArgumentSemantic.Copy)]
        string LastLoginProvider { get; set; }

        [Export ("initWithSessionToken:secret:")]
        IntPtr Constructor (string token, string secret);

        [Export ("initWithSessionToken:secret:expiration:")]
        IntPtr Constructor (string token, string secret, NSDate expiration);
    }

    [BaseType (typeof (NSObject))]
    public partial interface GSObject {

        [Export ("source", ArgumentSemantic.Copy)]
        string Source { get; set; }

        [Export ("objectForKeyedSubscript:")]
        NSObject ObjectForKeyedSubscript (string key);

        [Export ("setObject:forKeyedSubscript:")]
        void SetObjectForKeyedSubscript (NSObject obj, string key);

        [Export ("objectForKey:")]
        NSObject ObjectForKey (string key);

        [Export ("setObject:forKey:")]
        void SetObject (NSObject obj, string key);

        [Export ("removeObjectForKey:")]
        void RemoveObjectForKey (string key);

        [Export ("allKeys")]
        string [] AllKeys { get; }

        [Export ("JSONString")]
        string JSONString { get; }
    }

    [BaseType (typeof (GSObject))]
    public partial interface GSResponse {

        [Static, Export ("responseForMethod:data:")]
        GSResponse ResponseForMethod (string method, NSData data);

        [Static, Export ("responseWithError:")]
        GSResponse ResponseWithError (NSError error);

        [Export ("method")]
        string Method { get; }

        [Export ("errorCode")]
        int ErrorCode { get; }

        [Export ("callId")]
        string CallId { get; }

        [Export ("allKeys")]
        string [] AllKeys { get; }

        [Export ("objectForKey:")]
        NSObject ObjectForKey (string key);

        [Export ("objectForKeyedSubscript:")]
        NSObject ObjectForKeyedSubscript (string key);

        [Export ("JSONString")]
        string JSONString { get; }
    }

    [BaseType (typeof (NSObject))]
    public partial interface GSRequest {

        [Static, Export ("requestForMethod:")]
        GSRequest RequestForMethod (string method);

        [Static, Export ("requestForMethod:parameters:")]
        GSRequest RequestForMethod (string method, [NullAllowed] NSDictionary parameters);

        [Export ("method", ArgumentSemantic.Copy)]
        string Method { get; set; }

        [Export ("parameters", ArgumentSemantic.Retain)]
        NSMutableDictionary Parameters { get; set; }

        [Export ("useHTTPS")]
        bool UseHTTPS { get; set; }

        [Export ("sendWithResponseHandler:")]
        void SendWithResponseHandler (GSResponseHandler handler);

        [Export ("sendSynchronouslyWithError:")]
        GSResponse SendSynchronouslyWithError (out NSError error);

        [Export ("cancel")]
        void Cancel ();

        [Export ("session", ArgumentSemantic.Retain)]
        GSSession Session { get; set; }

        [Export ("requestID")]
        string RequestID { get; }

        [Export ("includeAuthInfo")]
        bool IncludeAuthInfo { get; set; }

        [Export ("source", ArgumentSemantic.Copy)]
        string Source { get; set; }
    }

    [BaseType (typeof (GSResponse))]
    public partial interface GSUser {

        [Export ("UID")]
        string UID { get; }

        [Export ("loginProvider")]
        string LoginProvider { get; }

        [Export ("nickname")]
        string Nickname { get; }

        [Export ("firstName")]
        string FirstName { get; }

        [Export ("lastName")]
        string LastName { get; }

        [Export ("email")]
        string Email { get; }

        [Export ("identities")]
        NSDictionary [] Identities { get; }

        [Export ("photoURL")]
        NSUrl PhotoURL { get; }

        [Export ("thumbnailURL")]
        NSUrl ThumbnailURL { get; }

        [Export ("allKeys")]
        string [] AllKeys { get; }

        [Export ("objectForKey:")]
        NSObject ObjectForKey (string key);

        [Export ("objectForKeyedSubscript:")]
        NSObject ObjectForKeyedSubscript (string key);

        [Export ("JSONString")]
        string JSONString { get; }
    }

    [BaseType (typeof (GSResponse))]
    public partial interface GSAccount {

        [Export ("UID")]
        string UID { get; }

        [Export ("profile")]
        NSDictionary Profile { get; }

        [Export ("data")]
        NSDictionary Data { get; }

        [Export ("nickname")]
        string Nickname { get; }

        [Export ("firstName")]
        string FirstName { get; }

        [Export ("lastName")]
        string LastName { get; }

        [Export ("email")]
        string Email { get; }

        [Export ("photoURL")]
        NSUrl PhotoURL { get; }

        [Export ("thumbnailURL")]
        NSUrl ThumbnailURL { get; }

        [Export ("allKeys")]
        string [] AllKeys { get; }

        [Export ("objectForKey:")]
        NSObject ObjectForKey (string key);

        [Export ("objectForKeyedSubscript:")]
        NSObject ObjectForKeyedSubscript (string key);

        [Export ("JSONString")]
        string JSONString { get; }
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface GSSessionDelegate {

        [Export ("userDidLogin:")]
        void UserDidLogin (GSUser user);

        [Export ("userDidLogout")]
        void UserDidLogout ();

        [Export ("userInfoDidChange:")]
        void UserInfoDidChange (GSUser user);
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface GSSocializeDelegate {

        [Export ("userDidLogin:")]
        void UserDidLogin (GSUser user);

        [Export ("userDidLogout")]
        void UserDidLogout ();

        [Export ("userInfoDidChange:")]
        void UserInfoDidChange (GSUser user);
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface GSAccountsDelegate {

        [Export ("accountDidLogin:")]
        void AccountDidLogin (GSAccount account);

        [Export ("accountDidLogout")]
        void AccountDidLogout ();
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface GSWebBridgeDelegate {

        [Export ("webView:startedLoginForMethod:parameters:")]
        void StartedLoginForMethod (UIWebView webView, string method, NSDictionary parameters);

        [Export ("webView:finishedLoginWithResponse:")]
        void FinishedLoginWithResponse (UIWebView webView, GSResponse response);

        [Export ("webView:receivedPluginEvent:fromPluginInContainer:")]
        void ReceivedPluginEvent (UIWebView webView, NSDictionary pluginEvent, string containerID);
    }

    [BaseType (typeof (NSObject))]
    public partial interface GSWebBridge {

        [Static, Export ("registerWebView:delegate:")]
        void RegisterWebView (UIWebView webView, GSWebBridgeDelegate webBridgeDelegate);

        [Static, Export ("unregisterWebView:")]
        void UnregisterWebView (UIWebView webView);

        [Static, Export ("webViewDidStartLoad:")]
        void WebViewDidStartLoad (UIWebView webView);

        [Static, Export ("handleRequest:webView:")]
        bool HandleRequest (NSUrlRequest request, UIWebView webView);
    }

    [Model, BaseType (typeof (NSObject))]
    public partial interface GSPluginViewDelegate {

        [Export ("pluginView:finishedLoadingPluginWithEvent:")]
        void FinishedLoadingPluginWithEvent (GSPluginView pluginView, NSDictionary pluginEvent);

        [Export ("pluginView:firedEvent:")]
        void FiredEvent (GSPluginView pluginView, NSDictionary pluginEvent);

        [Export ("pluginView:didFailWithError:")]
        void DidFailWithError (GSPluginView pluginView, NSError error);
    }

    [BaseType (typeof (UIView))]
    public partial interface GSPluginView {

        [Export ("delegate", ArgumentSemantic.Assign)]
        GSPluginViewDelegate Delegate { get; set; }

        [Export ("loadPlugin:")]
        void LoadPlugin (string plugin);

        [Export ("loadPlugin:parameters:")]
        void LoadPlugin (string plugin, [NullAllowed] NSDictionary parameters);

        [Export ("plugin")]
        string Plugin { get; }

        [Export ("showLoginProgress")]
        bool ShowLoginProgress { get; set; }

        [Export ("loginProgressText", ArgumentSemantic.Copy)]
        string LoginProgressText { get; set; }

        [Export ("showLoadingProgress")]
        bool ShowLoadingProgress { get; set; }

        [Export ("loadingProgressText", ArgumentSemantic.Copy)]
        string LoadingProgressText { get; set; }

        [Export ("javascriptLoadingTimeout")]
        int JavascriptLoadingTimeout { get; set; }
    }

    [BaseType (typeof (NSObject))]
    public partial interface Gigya {

        [Static, Export ("initWithAPIKey:")]
        void InitWithAPIKey (string apiKey);

        [Static, Export ("initWithAPIKey:APIDomain:")]
        void InitWithAPIKey (string apiKey, string apiDomain);

        [Static, Export ("APIKey")]
        string APIKey { get; }

        [Static, Export ("APIDomain")]
        string APIDomain { get; }

        [Static, Export ("session")]
        GSSession Session { get; set; }

        [Static, Export ("sessionDelegate")]
        GSSessionDelegate SessionDelegate { get; set; }

        [Static, Export ("socializeDelegate")]
        GSSocializeDelegate SocializeDelegate { get; set; }

        [Static, Export ("accountsDelegate")]
        GSAccountsDelegate AccountsDelegate { get; set; }

        [Static, Export ("loginToProvider:")]
        void LoginToProvider (string provider);

        [Static, Export ("showLoginDialogOver:provider:")]
        void ShowLoginDialogOver (UIViewController viewController, string provider);

        [Static, Export ("loginToProvider:parameters:completionHandler:")]
        void LoginToProvider (string provider, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

        [Static, Export ("showLoginDialogOver:provider:parameters:completionHandler:")]
        void ShowLoginDialogOver (UIViewController viewController, string provider, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

        [Static, Export ("loginToProvider:parameters:over:completionHandler:")]
        void LoginToProvider (string provider, [NullAllowed] NSDictionary parameters, [NullAllowed] UIViewController viewController, GSUserInfoHandler handler);

        [Static, Export ("showLoginProvidersDialogOver:")]
        void ShowLoginProvidersDialogOver (UIViewController viewController);

        [Static, Export ("showLoginProvidersPopoverFrom:")]
        void ShowLoginProvidersPopoverFrom (UIView view);

        [Static, Export ("showLoginProvidersDialogOver:providers:parameters:completionHandler:")]
        void ShowLoginProvidersDialogOver (UIViewController viewController, string [] providers, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

        [Static, Export ("showLoginProvidersPopoverFrom:providers:parameters:completionHandler:")]
        void ShowLoginProvidersPopoverFrom (UIView view, string [] providers, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

        [Static, Export ("logout")]
        void Logout ();

        [Static, Export ("logoutWithCompletionHandler:")]
        void LogoutWithCompletionHandler (GSResponseHandler handler);

        [Static, Export ("addConnectionToProvider:")]
        void AddConnectionToProvider (string provider);

        [Static, Export ("showAddConnectionDialogOver:provider:")]
        void ShowAddConnectionDialogOver (UIViewController viewController, string provider);

        [Static, Export ("addConnectionToProvider:parameters:completionHandler:")]
        void AddConnectionToProvider (string provider, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

        [Static, Export ("showAddConnectionDialogOver:provider:parameters:completionHandler:")]
        void ShowAddConnectionDialogOver (UIViewController viewController, string provider, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

        [Static, Export ("addConnectionToProvider:parameters:over:completionHandler:")]
        void AddConnectionToProvider (string provider, [NullAllowed] NSDictionary parameters, UIViewController viewController, GSUserInfoHandler handler);

        [Static, Export ("showAddConnectionProvidersDialogOver:")]
        void ShowAddConnectionProvidersDialogOver (UIViewController viewController);

        [Static, Export ("showAddConnectionProvidersPopoverFrom:")]
        void ShowAddConnectionProvidersPopoverFrom (UIView view);

        [Static, Export ("showAddConnectionProvidersDialogOver:providers:parameters:completionHandler:")]
        void ShowAddConnectionProvidersDialogOver (UIViewController viewController, string [] providers, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

        [Static, Export ("showAddConnectionProvidersPopoverFrom:providers:parameters:completionHandler:")]
        void ShowAddConnectionProvidersPopoverFrom (UIView view, string [] providers, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

        [Static, Export ("removeConnectionToProvider:")]
        void RemoveConnectionToProvider (string provider);

        [Static, Export ("removeConnectionToProvider:completionHandler:")]
        void RemoveConnectionToProvider (string provider, GSUserInfoHandler handler);

        [Static, Export ("showPluginDialogOver:plugin:parameters:")]
        void ShowPluginDialogOver (UIViewController viewController, string plugin, [NullAllowed] NSDictionary parameters);

        [Static, Export ("showPluginDialogOver:plugin:parameters:completionHandler:")]
        void ShowPluginDialogOver (UIViewController viewController, string plugin, [NullAllowed] NSDictionary parameters, GSPluginCompletionHandler handler);

        [Static, Export ("showPluginDialogOver:plugin:parameters:completionHandler:delegate:")]
        void ShowPluginDialogOver (UIViewController viewController, string plugin, [NullAllowed] NSDictionary parameters, GSPluginCompletionHandler handler, GSPluginViewDelegate pluginViewDelegate);

        [Static, Export ("requestFacebookPublishPermissions:responseHandler:")]
        void RequestFacebookPublishPermissions (string permissions, GSPermissionRequestResultHandler handler);

        [Static, Export ("handleOpenURL:sourceApplication:annotation:")]
        bool HandleOpenURL ([NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

        [Static, Export ("handleDidBecomeActive")]
        void HandleDidBecomeActive ();

        [Static, Export ("useHTTPS")]
        bool UseHTTPS { get; set; }

        [Static, Export ("networkActivityIndicatorEnabled")]
        bool NetworkActivityIndicatorEnabled { get; set; }
    }

    public delegate void GSUserInfoHandler (GSUser user, NSError error);

    public delegate void GSPermissionRequestResultHandler (bool granted, NSError error);

    public delegate void GSPluginCompletionHandler (bool closedByUser, NSError error);

    public delegate void GSResponseHandler(GSResponse response, NSError error);
}

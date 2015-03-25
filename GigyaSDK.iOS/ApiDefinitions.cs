using System;
using Foundation;
using GigyaSDK;
using ObjCRuntime;
using UIKit;

namespace GigyaSDK.iOS
{
	// @interface GSSession : NSObject <NSCoding>
	[BaseType (typeof(NSObject))]
	interface GSSession : INSCoding
	{
		// -(BOOL)isValid;
		[Export ("isValid")]
		bool IsValid { get; }

		// @property (copy, nonatomic) NSString * token;
		[Export ("token")]
		string Token { get; set; }

		// @property (copy, nonatomic) NSString * secret;
		[Export ("secret")]
		string Secret { get; set; }

		// @property (copy, nonatomic) NSDate * expiration;
		[Export ("expiration", ArgumentSemantic.Copy)]
		NSDate Expiration { get; set; }

		// @property (copy, nonatomic) NSString * lastLoginProvider;
		[Export ("lastLoginProvider")]
		string LastLoginProvider { get; set; }

		// -(GSSession *)initWithSessionToken:(NSString *)token secret:(NSString *)secret;
		[Export ("initWithSessionToken:secret:")]
		IntPtr Constructor (string token, string secret);

		// -(GSSession *)initWithSessionToken:(NSString *)token secret:(NSString *)secret expiration:(NSDate *)expiration;
		[Export ("initWithSessionToken:secret:expiration:")]
		IntPtr Constructor (string token, string secret, NSDate expiration);
	}

	// @interface GSObject : NSObject
	[BaseType (typeof(NSObject))]
	interface GSObject
	{
		// @property (copy, nonatomic) NSString * source;
		[Export ("source")]
		string Source { get; set; }

		// -(id)objectForKeyedSubscript:(NSString *)key;
		[Export ("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript (string key);

		// -(void)setObject:(id)obj forKeyedSubscript:(NSString *)key;
		[Export ("setObject:forKeyedSubscript:")]
		void SetObjectForKeyedSubscript (NSObject obj, string key);

		// -(id)objectForKey:(NSString *)key;
		[Export ("objectForKey:")]
		NSObject ObjectForKey (string key);

		// -(void)setObject:(id)obj forKey:(NSString *)key;
		[Export ("setObject:forKey:")]
		void SetObject (NSObject obj, string key);

		// -(void)removeObjectForKey:(NSString *)key;
		[Export ("removeObjectForKey:")]
		void RemoveObjectForKey (string key);

		// -(NSArray *)allKeys;
		[Export ("allKeys")]
		NSString[] AllKeys { get; }

		// -(NSString *)JSONString;
		[Export ("JSONString")]
		string JSONString { get; }
	}

	// @interface GSResponse : GSObject
	[BaseType (typeof(GSObject))]
	interface GSResponse
	{
		// +(GSResponse *)responseForMethod:(NSString *)method data:(NSData *)data;
		[Static]
		[Export ("responseForMethod:data:")]
		GSResponse ResponseForMethod (string method, NSData data);

		// +(GSResponse *)responseWithError:(NSError *)error;
		[Static]
		[Export ("responseWithError:")]
		GSResponse ResponseWithError (NSError error);

		// @property (readonly) NSString * method;
		[Export ("method")]
		string Method { get; }

		// @property (readonly) int errorCode;
		[Export ("errorCode")]
		int ErrorCode { get; }

		// @property (readonly) NSString * callId;
		[Export ("callId")]
		string CallId { get; }
	}

	// typedef void (^GSResponseHandler)(GSResponse *NSError *);
	delegate void GSResponseHandler (GSResponse arg0, NSError arg1);

	// @interface GSRequest : NSObject <NSURLConnectionDelegate>
	[BaseType (typeof(NSObject))]
	interface GSRequest
	{
		// +(GSRequest *)requestForMethod:(NSString *)method;
		[Static]
		[Export ("requestForMethod:")]
		GSRequest RequestForMethod (string method);

		// +(GSRequest *)requestForMethod:(NSString *)method parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("requestForMethod:parameters:")]
		GSRequest RequestForMethod (string method, [NullAllowed] NSDictionary parameters);

		// @property (copy, nonatomic) NSString * method;
		[Export ("method")]
		string Method { get; set; }

		// @property (retain, nonatomic) NSMutableDictionary * parameters;
		[Export ("parameters", ArgumentSemantic.Retain)]
		NSMutableDictionary Parameters { get; set; }

		// @property (nonatomic) BOOL useHTTPS;
		[Export ("useHTTPS")]
		bool UseHTTPS { get; set; }

		// @property (nonatomic) NSTimeInterval requestTimeout;
		[Export ("requestTimeout")]
		double RequestTimeout { get; set; }

		// -(void)sendWithResponseHandler:(GSResponseHandler)handler;
		[Export ("sendWithResponseHandler:")]
		void SendWithResponseHandler (GSResponseHandler handler);

		// -(GSResponse *)sendSynchronouslyWithError:(NSError **)error;
		[Export ("sendSynchronouslyWithError:")]
		GSResponse SendSynchronouslyWithError (out NSError error);

		// -(void)cancel;
		[Export ("cancel")]
		void Cancel ();

		// @property (retain, nonatomic) GSSession * session;
		[Export ("session", ArgumentSemantic.Retain)]
		GSSession Session { get; set; }

		// @property (readonly, nonatomic) NSString * requestID;
		[Export ("requestID")]
		string RequestID { get; }

		// @property (nonatomic) BOOL includeAuthInfo;
		[Export ("includeAuthInfo")]
		bool IncludeAuthInfo { get; set; }

		// @property (copy, nonatomic) NSString * source;
		[Export ("source")]
		string Source { get; set; }
	}

	// @interface GSUser : GSResponse
	[BaseType (typeof(GSResponse))]
	interface GSUser
	{
		// @property (readonly, nonatomic) NSString * UID;
		[Export ("UID")]
		string UID { get; }

		// @property (readonly, nonatomic) NSString * loginProvider;
		[Export ("loginProvider")]
		string LoginProvider { get; }

		// @property (readonly, nonatomic) NSString * nickname;
		[Export ("nickname")]
		string Nickname { get; }

		// @property (readonly, nonatomic) NSString * firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; }

		// @property (readonly, nonatomic) NSArray * identities;
		[Export ("identities")]
		NSObject[] Identities { get; }

		// @property (readonly, nonatomic) NSURL * photoURL;
		[Export ("photoURL")]
		NSUrl PhotoURL { get; }

		// @property (readonly, nonatomic) NSURL * thumbnailURL;
		[Export ("thumbnailURL")]
		NSUrl ThumbnailURL { get; }
	}

	// @interface GSAccount : GSResponse
	[BaseType (typeof(GSResponse))]
	interface GSAccount
	{
		// @property (readonly, nonatomic) NSString * UID;
		[Export ("UID")]
		string UID { get; }

		// @property (readonly, nonatomic) NSDictionary * profile;
		[Export ("profile")]
		NSDictionary Profile { get; }

		// @property (readonly, nonatomic) NSDictionary * data;
		[Export ("data")]
		NSDictionary Data { get; }

		// @property (readonly, nonatomic) NSString * nickname;
		[Export ("nickname")]
		string Nickname { get; }

		// @property (readonly, nonatomic) NSString * firstName;
		[Export ("firstName")]
		string FirstName { get; }

		// @property (readonly, nonatomic) NSString * lastName;
		[Export ("lastName")]
		string LastName { get; }

		// @property (readonly, nonatomic) NSString * email;
		[Export ("email")]
		string Email { get; }

		// @property (readonly, nonatomic) NSURL * photoURL;
		[Export ("photoURL")]
		NSUrl PhotoURL { get; }

		// @property (readonly, nonatomic) NSURL * thumbnailURL;
		[Export ("thumbnailURL")]
		NSUrl ThumbnailURL { get; }
	}

	// @protocol GSSessionDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSSessionDelegate
	{
		// @optional -(void)userDidLogin:(GSUser *)user;
		[Export ("userDidLogin:")]
		void UserDidLogin (GSUser user);

		// @optional -(void)userDidLogout;
		[Export ("userDidLogout")]
		void UserDidLogout ();

		// @optional -(void)userInfoDidChange:(GSUser *)user;
		[Export ("userInfoDidChange:")]
		void UserInfoDidChange (GSUser user);
	}

	// @protocol GSSocializeDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSSocializeDelegate
	{
		// @optional -(void)userDidLogin:(GSUser *)user;
		[Export ("userDidLogin:")]
		void UserDidLogin (GSUser user);

		// @optional -(void)userDidLogout;
		[Export ("userDidLogout")]
		void UserDidLogout ();

		// @optional -(void)userInfoDidChange:(GSUser *)user;
		[Export ("userInfoDidChange:")]
		void UserInfoDidChange (GSUser user);
	}

	// @protocol GSAccountsDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSAccountsDelegate
	{
		// @optional -(void)accountDidLogin:(GSAccount *)account;
		[Export ("accountDidLogin:")]
		void AccountDidLogin (GSAccount account);

		// @optional -(void)accountDidLogout;
		[Export ("accountDidLogout")]
		void AccountDidLogout ();
	}

	// @protocol GSWebBridgeDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSWebBridgeDelegate
	{
		// @optional -(void)webView:(UIWebView *)webView startedLoginForMethod:(NSString *)method parameters:(NSDictionary *)parameters;
		[Export ("webView:startedLoginForMethod:parameters:")]
		void StartedLoginForMethod (UIWebView webView, string method, [NullAllowed] NSDictionary parameters);

		// @optional -(void)webView:(UIWebView *)webView finishedLoginWithResponse:(GSResponse *)response;
		[Export ("webView:finishedLoginWithResponse:")]
		void FinishedLoginWithResponse (UIWebView webView, GSResponse response);

		// @optional -(void)webView:(UIWebView *)webView receivedPluginEvent:(NSDictionary *)event fromPluginInContainer:(NSString *)containerID;
		[Export ("webView:receivedPluginEvent:fromPluginInContainer:")]
		void ReceivedPluginEvent (UIWebView webView, NSDictionary eventDetails, string containerID);

		// @optional -(void)webView:(UIWebView *)webView receivedJsLog:(NSString *)logType logInfo:(NSDictionary *)logInfo;
		[Export ("webView:receivedJsLog:logInfo:")]
		void ReceivedJsLog (UIWebView webView, string logType, NSDictionary logInfo);
	}

	// @interface GSWebBridge : NSObject
	[BaseType (typeof(NSObject))]
	interface GSWebBridge
	{
		// +(void)registerWebView:(UIWebView *)webView delegate:(id<GSWebBridgeDelegate>)delegate;
		[Static]
		[Export ("registerWebView:delegate:")]
		void RegisterWebView (UIWebView webView, GSWebBridgeDelegate webBridgeDelegate);

		// +(void)registerWebView:(UIWebView *)webView delegate:(id<GSWebBridgeDelegate>)delegate settings:(NSDictionary *)settings;
		[Static]
		[Export ("registerWebView:delegate:settings:")]
        void RegisterWebView (UIWebView webView, GSWebBridgeDelegate webBridgeDelegate, NSDictionary settings);

		// +(void)unregisterWebView:(UIWebView *)webView;
		[Static]
		[Export ("unregisterWebView:")]
		void UnregisterWebView (UIWebView webView);

		// +(void)webViewDidStartLoad:(UIWebView *)webView;
		[Static]
		[Export ("webViewDidStartLoad:")]
		void WebViewDidStartLoad (UIWebView webView);

		// +(BOOL)handleRequest:(NSURLRequest *)request webView:(UIWebView *)webView;
		[Static]
		[Export ("handleRequest:webView:")]
		bool HandleRequest (NSUrlRequest request, UIWebView webView);
	}

	// @protocol GSPluginViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface GSPluginViewDelegate
	{
		// @optional -(void)pluginView:(GSPluginView *)pluginView finishedLoadingPluginWithEvent:(NSDictionary *)event;
		[Export ("pluginView:finishedLoadingPluginWithEvent:")]
		void FinishedLoadingPluginWithEvent (GSPluginView pluginView, NSDictionary pluginEvent);

		// @optional -(void)pluginView:(GSPluginView *)pluginView firedEvent:(NSDictionary *)event;
		[Export ("pluginView:firedEvent:")]
		void FiredEvent (GSPluginView pluginView, NSDictionary pluginEvent);

		// @optional -(void)pluginView:(GSPluginView *)pluginView didFailWithError:(NSError *)error;
		[Export ("pluginView:didFailWithError:")]
		void DidFailWithError (GSPluginView pluginView, NSError error);
	}

	// @interface GSPluginView : UIView
	[BaseType (typeof(UIView))]
	interface GSPluginView
	{
		[Wrap ("WeakDelegate")]
		GSPluginViewDelegate Delegate { get; set; }

		// @property (assign, nonatomic) id<GSPluginViewDelegate> delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Assign)]
		NSObject WeakDelegate { get; set; }

		// -(void)loadPlugin:(NSString *)plugin;
		[Export ("loadPlugin:")]
		void LoadPlugin (string plugin);

		// -(void)loadPlugin:(NSString *)plugin parameters:(NSDictionary *)parameters;
		[Export ("loadPlugin:parameters:")]
		void LoadPlugin (string plugin, [NullAllowed] NSDictionary parameters);

		// @property (readonly, nonatomic) NSString * plugin;
		[Export ("plugin")]
		string Plugin { get; }

		// @property (nonatomic) BOOL showLoginProgress;
		[Export ("showLoginProgress")]
		bool ShowLoginProgress { get; set; }

		// @property (copy, nonatomic) NSString * loginProgressText;
		[Export ("loginProgressText")]
		string LoginProgressText { get; set; }

		// @property (nonatomic) BOOL showLoadingProgress;
		[Export ("showLoadingProgress")]
		bool ShowLoadingProgress { get; set; }

		// @property (copy, nonatomic) NSString * loadingProgressText;
		[Export ("loadingProgressText")]
		string LoadingProgressText { get; set; }

		// @property (nonatomic) NSInteger javascriptLoadingTimeout;
		[Export ("javascriptLoadingTimeout", ArgumentSemantic.Assign)]
		nint JavascriptLoadingTimeout { get; set; }
	}

	// typedef void (^GSUserInfoHandler)(GSUser *NSError *);
	delegate void GSUserInfoHandler (GSUser arg0, NSError arg1);

	// typedef void (^GSPermissionRequestResultHandler)(BOOLNSError *NSArray *);
	delegate void GSPermissionRequestResultHandler (bool arg0, NSError arg1, NSObject[] arg2);

	// typedef void (^GSPluginCompletionHandler)(BOOLNSError *);
	delegate void GSPluginCompletionHandler (bool arg0, NSError arg1);

	// @interface Gigya : NSObject
	[BaseType (typeof(NSObject))]
	interface Gigya
	{
		// +(void)initWithAPIKey:(NSString *)apiKey;
		[Static]
		[Export ("initWithAPIKey:")]
		void InitWithAPIKey (string apiKey);

		// +(void)initWithAPIKey:(NSString *)apiKey APIDomain:(NSString *)apiDomain;
		[Static]
		[Export ("initWithAPIKey:APIDomain:")]
		void InitWithAPIKey (string apiKey, string apiDomain);

		// +(NSString *)APIKey;
		[Static]
		[Export ("APIKey")]
		string APIKey { get; }

		// +(NSString *)APIDomain;
		[Static]
		[Export ("APIDomain")]
		string APIDomain { get; }

		// +(GSSession *)session;
		// +(void)setSession:(GSSession *)session;
		[Static]
		[Export ("session")]
		GSSession Session { get; set; }

		// +(id<GSSessionDelegate>)sessionDelegate;
		[Static]
		[Export ("sessionDelegate")]
		GSSessionDelegate SessionDelegate ();

		// +(void)setSessionDelegate:(id<GSSessionDelegate>)delegate __attribute__((deprecated("Use [Gigya setSocializeDelegate:] with a GSSocializeDelegate instead")));
		[Static]
		[Export ("setSessionDelegate:")]
		void SetSessionDelegate (GSSessionDelegate sessionDelegate);

		// +(id<GSSocializeDelegate>)socializeDelegate;
		[Static]
		[Export ("socializeDelegate")]
		GSSocializeDelegate SocializeDelegate ();

		// +(void)setSocializeDelegate:(id<GSSocializeDelegate>)socializeDelegate;
		[Static]
		[Export ("setSocializeDelegate:")]
		void SetSocializeDelegate (GSSocializeDelegate socializeDelegate);

		// +(id<GSAccountsDelegate>)accountsDelegate;
		[Static]
		[Export ("accountsDelegate")]
		GSAccountsDelegate AccountsDelegate ();

		// +(void)setAccountsDelegate:(id<GSAccountsDelegate>)accountsDelegate;
		[Static]
		[Export ("setAccountsDelegate:")]
		void SetAccountsDelegate (GSAccountsDelegate accountsDelegate);

		// +(void)loginToProvider:(NSString *)provider;
		[Static]
		[Export ("loginToProvider:")]
		void LoginToProvider (string provider);

		// +(void)showLoginDialogOver:(UIViewController *)viewController provider:(NSString *)provider __attribute__((deprecated("Use loginToProvider: instead")));
		[Static]
		[Export ("showLoginDialogOver:provider:")]
		void ShowLoginDialogOver (UIViewController viewController, string provider);

		// +(void)loginToProvider:(NSString *)provider parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("loginToProvider:parameters:completionHandler:")]
		void LoginToProvider (string provider, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

		// +(void)showLoginDialogOver:(UIViewController *)viewController provider:(NSString *)provider parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler __attribute__((deprecated("Use loginToProvider:parameters:completionHandler: instead")));
		[Static]
		[Export ("showLoginDialogOver:provider:parameters:completionHandler:")]
		void ShowLoginDialogOver (UIViewController viewController, string provider, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

		// +(void)loginToProvider:(NSString *)provider parameters:(NSDictionary *)parameters over:(UIViewController *)viewController completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("loginToProvider:parameters:over:completionHandler:")]
		void LoginToProvider (string provider, [NullAllowed] NSDictionary parameters, UIViewController viewController, GSUserInfoHandler handler);

		// +(void)showLoginProvidersDialogOver:(UIViewController *)viewController;
		[Static]
		[Export ("showLoginProvidersDialogOver:")]
		void ShowLoginProvidersDialogOver (UIViewController viewController);

		// +(void)showLoginProvidersPopoverFrom:(UIView *)view;
		[Static]
		[Export ("showLoginProvidersPopoverFrom:")]
		void ShowLoginProvidersPopoverFrom (UIView view);

		// +(void)showLoginProvidersDialogOver:(UIViewController *)viewController providers:(NSArray *)providers parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("showLoginProvidersDialogOver:providers:parameters:completionHandler:")]
		void ShowLoginProvidersDialogOver (UIViewController viewController, string[] providers, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

		// +(void)showLoginProvidersPopoverFrom:(UIView *)view providers:(NSArray *)providers parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("showLoginProvidersPopoverFrom:providers:parameters:completionHandler:")]
		void ShowLoginProvidersPopoverFrom (UIView view, string[] providers, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

		// +(void)logout;
		[Static]
		[Export ("logout")]
		void Logout ();

		// +(void)logoutWithCompletionHandler:(GSResponseHandler)handler;
		[Static]
		[Export ("logoutWithCompletionHandler:")]
		void LogoutWithCompletionHandler (GSResponseHandler handler);

		// +(void)addConnectionToProvider:(NSString *)provider;
		[Static]
		[Export ("addConnectionToProvider:")]
		void AddConnectionToProvider (string provider);

		// +(void)showAddConnectionDialogOver:(UIViewController *)viewController provider:(NSString *)provider __attribute__((deprecated("Use addConnectionToProvider: instead")));
		[Static]
		[Export ("showAddConnectionDialogOver:provider:")]
		void ShowAddConnectionDialogOver (UIViewController viewController, string provider);

		// +(void)addConnectionToProvider:(NSString *)provider parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("addConnectionToProvider:parameters:completionHandler:")]
		void AddConnectionToProvider (string provider, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

		// +(void)showAddConnectionDialogOver:(UIViewController *)viewController provider:(NSString *)provider parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler __attribute__((deprecated("Use addConnectionToProvider:parameters:completionHandler: instead")));
		[Static]
		[Export ("showAddConnectionDialogOver:provider:parameters:completionHandler:")]
		void ShowAddConnectionDialogOver (UIViewController viewController, string provider, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

		// +(void)addConnectionToProvider:(NSString *)provider parameters:(NSDictionary *)parameters over:(UIViewController *)viewController completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("addConnectionToProvider:parameters:over:completionHandler:")]
		void AddConnectionToProvider (string provider, [NullAllowed] NSDictionary parameters, UIViewController viewController, GSUserInfoHandler handler);

		// +(void)showAddConnectionProvidersDialogOver:(UIViewController *)viewController;
		[Static]
		[Export ("showAddConnectionProvidersDialogOver:")]
		void ShowAddConnectionProvidersDialogOver (UIViewController viewController);

		// +(void)showAddConnectionProvidersPopoverFrom:(UIView *)view;
		[Static]
		[Export ("showAddConnectionProvidersPopoverFrom:")]
		void ShowAddConnectionProvidersPopoverFrom (UIView view);

		// +(void)showAddConnectionProvidersDialogOver:(UIViewController *)viewController providers:(NSArray *)providers parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("showAddConnectionProvidersDialogOver:providers:parameters:completionHandler:")]
		void ShowAddConnectionProvidersDialogOver (UIViewController viewController, string[] providers, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

		// +(void)showAddConnectionProvidersPopoverFrom:(UIView *)view providers:(NSArray *)providers parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("showAddConnectionProvidersPopoverFrom:providers:parameters:completionHandler:")]
		void ShowAddConnectionProvidersPopoverFrom (UIView view, string[] providers, [NullAllowed] NSDictionary parameters, GSUserInfoHandler handler);

		// +(void)removeConnectionToProvider:(NSString *)provider;
		[Static]
		[Export ("removeConnectionToProvider:")]
		void RemoveConnectionToProvider (string provider);

		// +(void)removeConnectionToProvider:(NSString *)provider completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export ("removeConnectionToProvider:completionHandler:")]
		void RemoveConnectionToProvider (string provider, GSUserInfoHandler handler);

		// +(void)showPluginDialogOver:(UIViewController *)viewController plugin:(NSString *)plugin parameters:(NSDictionary *)parameters;
		[Static]
		[Export ("showPluginDialogOver:plugin:parameters:")]
		void ShowPluginDialogOver (UIViewController viewController, string plugin, [NullAllowed] NSDictionary parameters);

		// +(void)showPluginDialogOver:(UIViewController *)viewController plugin:(NSString *)plugin parameters:(NSDictionary *)parameters completionHandler:(GSPluginCompletionHandler)handler;
		[Static]
		[Export ("showPluginDialogOver:plugin:parameters:completionHandler:")]
		void ShowPluginDialogOver (UIViewController viewController, string plugin, [NullAllowed] NSDictionary parameters, GSPluginCompletionHandler handler);

		// +(void)showPluginDialogOver:(UIViewController *)viewController plugin:(NSString *)plugin parameters:(NSDictionary *)parameters completionHandler:(GSPluginCompletionHandler)handler delegate:(id<GSPluginViewDelegate>)delegate;
		[Static]
		[Export ("showPluginDialogOver:plugin:parameters:completionHandler:delegate:")]
		void ShowPluginDialogOver (UIViewController viewController, string plugin, [NullAllowed] NSDictionary parameters, GSPluginCompletionHandler handler, GSPluginViewDelegate pluginViewDelegate);

		// +(void)requestNewFacebookPublishPermissions:(NSString *)permissions responseHandler:(GSPermissionRequestResultHandler)handler;
		[Static]
		[Export ("requestNewFacebookPublishPermissions:responseHandler:")]
		void RequestNewFacebookPublishPermissions (string permissions, GSPermissionRequestResultHandler handler);

		// +(void)requestNewFacebookReadPermissions:(NSString *)permissions responseHandler:(GSPermissionRequestResultHandler)handler;
		[Static]
		[Export ("requestNewFacebookReadPermissions:responseHandler:")]
		void RequestNewFacebookReadPermissions (string permissions, GSPermissionRequestResultHandler handler);

		// +(BOOL)handleOpenURL:(NSURL *)url sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
		[Static]
		[Export ("handleOpenURL:sourceApplication:annotation:")]
        bool HandleOpenURL ([NullAllowed] NSUrl url, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// +(void)handleDidBecomeActive;
		[Static]
		[Export ("handleDidBecomeActive")]
		void HandleDidBecomeActive ();

		// +(BOOL)useHTTPS;
		[Static]
		[Export ("useHTTPS")]
		bool UseHTTPS ();

		// +(void)setUseHTTPS:(BOOL)useHTTPS;
		[Static]
		[Export ("setUseHTTPS:")]
		void SetUseHTTPS (bool useHTTPS);

		// +(BOOL)networkActivityIndicatorEnabled;
		[Static]
		[Export ("networkActivityIndicatorEnabled")]
		bool NetworkActivityIndicatorEnabled ();

		// +(void)setNetworkActivityIndicatorEnabled:(BOOL)networkActivityIndicatorEnabled;
		[Static]
		[Export ("setNetworkActivityIndicatorEnabled:")]
		void SetNetworkActivityIndicatorEnabled (bool networkActivityIndicatorEnabled);

		// +(NSTimeInterval)requestTimeout;
		[Static]
		[Export ("requestTimeout")]
		double RequestTimeout ();

		// +(void)setRequestTimeout:(NSTimeInterval)requestTimeout;
		[Static]
		[Export ("setRequestTimeout:")]
		void SetRequestTimeout (double requestTimeout);
	}
}

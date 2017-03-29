namespace GigyaSDK.iOS
{
	using System;

	using UIKit;
	using Foundation;
	using ObjCRuntime;
	using CoreGraphics;

	// @interface GSSessionInfo : NSObject <NSCoding>
	[BaseType(typeof(NSObject))]
	interface GSSessionInfo : INSCoding
	{
		// @property (copy, nonatomic) NSDate * expiration;
		[Export("expiration", ArgumentSemantic.Copy)]
		NSDate Expiration { get; set; }

		// @property (copy, nonatomic) NSString * APIKey;
		[Export("APIKey")]
		string APIKey { get; set; }

		// -(GSSessionInfo *)initWithAPIKey:(NSString *)apikey expiration:(NSDate *)expiration;
		[Export("initWithAPIKey:expiration:")]
		IntPtr Constructor(string apikey, NSDate expiration);

		// -(BOOL)isValid;
		[Export("isValid")]
		bool IsValid();
	}

	// @interface GSSession : NSObject <NSCoding>
	[BaseType(typeof(NSObject))]
	interface GSSession : INSCoding
	{
		// @property (copy, nonatomic) NSString * token;
		[Export("token")]
		string Token { get; set; }

		// @property (copy, nonatomic) NSString * secret;
		[Export("secret")]
		string Secret { get; set; }

		// @property (retain, nonatomic) GSSessionInfo * info;
		[Export("info", ArgumentSemantic.Retain)]
		GSSessionInfo Info { get; set; }

		// @property (copy, nonatomic) NSString * lastLoginProvider;
		[Export("lastLoginProvider")]
		string LastLoginProvider { get; set; }

		// -(GSSession *)initWithSessionToken:(NSString *)token secret:(NSString *)secret;
		[Export("initWithSessionToken:secret:")]
		IntPtr Constructor(string token, string secret);

		// -(GSSession *)initWithSessionToken:(NSString *)token secret:(NSString *)secret expiration:(NSDate *)expiration;
		[Export("initWithSessionToken:secret:expiration:")]
		IntPtr Constructor(string token, string secret, NSDate expiration);

		// -(GSSession *)initWithSessionToken:(NSString *)token secret:(NSString *)secret expiresIn:(NSString *)expiresIn;
		[Export("initWithSessionToken:secret:expiresIn:")]
		IntPtr Constructor(string token, string secret, string expiresIn);

		// -(BOOL)isValid;
		[Export("isValid")]
		bool IsValid();
	}

	// @interface GSObject : NSObject
	[BaseType(typeof(NSObject))]
	interface GSObject
	{
		// @property (copy, nonatomic) NSString * source;
		[Export("source")]
		string Source { get; set; }

		// -(id)objectForKeyedSubscript:(NSString *)key;
		[Export("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript(string key);

		// -(void)setObject:(id)obj forKeyedSubscript:(NSString *)key;
		[Export("setObject:forKeyedSubscript:")]
		void SetObjectForKeyedSubscript(NSObject obj, string key);

		// -(id)objectForKey:(NSString *)key;
		[Export("objectForKey:")]
		NSObject ObjectForKey(string key);

		// -(void)setObject:(id)obj forKey:(NSString *)key;
		[Export("setObject:forKey:")]
		void SetObject(NSObject obj, string key);

		// -(void)removeObjectForKey:(NSString *)key;
		[Export("removeObjectForKey:")]
		void RemoveObjectForKey(string key);

		// -(NSArray *)allKeys;
		[Export("allKeys")]
		NSObject[] AllKeys { get; }

		// -(NSString *)JSONString;
		[Export("JSONString")]
		string JSONString { get; }
	}

	// typedef void (^ _Nullable)(GSResponse * _Nullable, NSError * _Nullable) GSResponseHandler;
	delegate void GSResponseHandler([NullAllowed] GSResponse arg0, [NullAllowed] NSError arg1);

	// @interface GSRequest : NSObject
	[BaseType(typeof(NSObject))]
	interface GSRequest
	{
		// +(GSRequest *)requestForMethod:(NSString * _Nonnull)method;
		[Static]
		[Export("requestForMethod:")]
		GSRequest RequestForMethod(string method);

		// +(GSRequest *)requestForMethod:(NSString * _Nonnull)method parameters:(NSDictionary * _Nullable)parameters;
		[Static]
		[Export("requestForMethod:parameters:")]
		GSRequest RequestForMethod(string method, [NullAllowed] NSDictionary parameters);

		// @property (copy, nonatomic) NSString * _Nonnull method;
		[Export("method")]
		string Method { get; set; }

		// @property (nonatomic, strong) NSMutableDictionary * _Nullable parameters;
		[NullAllowed, Export("parameters", ArgumentSemantic.Strong)]
		NSMutableDictionary Parameters { get; set; }

		// @property (nonatomic) BOOL useHTTPS;
		[Export("useHTTPS")]
		bool UseHTTPS { get; set; }

		// @property (nonatomic) NSTimeInterval requestTimeout;
		[Export("requestTimeout")]
		double RequestTimeout { get; set; }

		// -(void)sendWithResponseHandler:(GSResponseHandler)handler;
		[Export("sendWithResponseHandler:")]
		void SendWithResponseHandler([NullAllowed] GSResponseHandler handler);

		// -(void)cancel;
		[Export("cancel")]
		void Cancel();

		// @property (nonatomic, strong) GSSession * session;
		[Export("session", ArgumentSemantic.Strong)]
		GSSession Session { get; set; }

		// @property (readonly, nonatomic, strong) NSString * requestID;
		[Export("requestID", ArgumentSemantic.Strong)]
		string RequestID { get; }

		// @property (nonatomic) BOOL includeAuthInfo;
		[Export("includeAuthInfo")]
		bool IncludeAuthInfo { get; set; }

		// @property (copy, nonatomic) NSString * source;
		[Export("source")]
		string Source { get; set; }
	}

	// @interface GSResponse : GSObject
	[BaseType(typeof(GSObject))]
	interface GSResponse
	{
		// +(void)responseForMethod:(NSString *)method data:(NSData *)data completionHandler:(GSResponseHandler)handler;
		[Static]
		[Export("responseForMethod:data:completionHandler:")]
		void ResponseForMethod(string method, NSData data, [NullAllowed] GSResponseHandler handler);

		// +(GSResponse *)responseWithError:(NSError *)error;
		[Static]
		[Export("responseWithError:")]
		GSResponse ResponseWithError(NSError error);

		// @property (readonly, weak) NSString * method;
		[Export("method", ArgumentSemantic.Weak)]
		string Method { get; }

		// @property (readonly) int errorCode;
		[Export("errorCode")]
		int ErrorCode { get; }

		// @property (readonly, weak) NSString * callId;
		[Export("callId", ArgumentSemantic.Weak)]
		string CallId { get; }

		// -(NSArray *)allKeys;
		[Export("allKeys")]
		NSObject[] AllKeys { get; }

		// -(id)objectForKey:(NSString *)key;
		[Export("objectForKey:")]
		NSObject ObjectForKey(string key);

		// -(id)objectForKeyedSubscript:(NSString *)key;
		[Export("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript(string key);

		// -(NSString *)JSONString;
		[Export("JSONString")]
		string JSONString { get; }
	}

	// @interface GSUser : GSResponse
	[BaseType(typeof(GSResponse))]
	interface GSUser
	{
		// @property (readonly, nonatomic, weak) NSString * UID;
		[Export("UID", ArgumentSemantic.Weak)]
		string UID { get; }

		// @property (readonly, nonatomic, weak) NSString * loginProvider;
		[Export("loginProvider", ArgumentSemantic.Weak)]
		string LoginProvider { get; }

		// @property (readonly, nonatomic, weak) NSString * nickname;
		[Export("nickname", ArgumentSemantic.Weak)]
		string Nickname { get; }

		// @property (readonly, nonatomic, weak) NSString * firstName;
		[Export("firstName", ArgumentSemantic.Weak)]
		string FirstName { get; }

		// @property (readonly, nonatomic, weak) NSString * lastName;
		[Export("lastName", ArgumentSemantic.Weak)]
		string LastName { get; }

		// @property (readonly, nonatomic, weak) NSString * email;
		[Export("email", ArgumentSemantic.Weak)]
		string Email { get; }

		// @property (readonly, nonatomic, weak) NSArray * identities;
		[Export("identities", ArgumentSemantic.Weak)]
		NSObject[] Identities { get; }

		// @property (readonly, nonatomic, weak) NSURL * photoURL;
		[Export("photoURL", ArgumentSemantic.Weak)]
		NSUrl PhotoURL { get; }

		// @property (readonly, nonatomic, weak) NSURL * thumbnailURL;
		[Export("thumbnailURL", ArgumentSemantic.Weak)]
		NSUrl ThumbnailURL { get; }

		// -(NSArray *)allKeys;
		[Export("allKeys")]
		NSObject[] AllKeys { get; }

		// -(id)objectForKey:(NSString *)key;
		[Export("objectForKey:")]
		NSObject ObjectForKey(string key);

		// -(id)objectForKeyedSubscript:(NSString *)key;
		[Export("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript(string key);

		// -(NSString *)JSONString;
		[Export("JSONString")]
		string JSONString { get; }
	}

	// @interface GSAccount : GSResponse
	[BaseType(typeof(GSResponse))]
	interface GSAccount
	{
		// @property (readonly, nonatomic, weak) NSString * UID;
		[Export("UID", ArgumentSemantic.Weak)]
		string UID { get; }

		// @property (readonly, nonatomic, weak) NSDictionary * profile;
		[Export("profile", ArgumentSemantic.Weak)]
		NSDictionary Profile { get; }

		// @property (readonly, nonatomic, weak) NSDictionary * data;
		[Export("data", ArgumentSemantic.Weak)]
		NSDictionary Data { get; }

		// @property (readonly, nonatomic, weak) NSString * nickname;
		[Export("nickname", ArgumentSemantic.Weak)]
		string Nickname { get; }

		// @property (readonly, nonatomic, weak) NSString * firstName;
		[Export("firstName", ArgumentSemantic.Weak)]
		string FirstName { get; }

		// @property (readonly, nonatomic, weak) NSString * lastName;
		[Export("lastName", ArgumentSemantic.Weak)]
		string LastName { get; }

		// @property (readonly, nonatomic, weak) NSString * email;
		[Export("email", ArgumentSemantic.Weak)]
		string Email { get; }

		// @property (readonly, nonatomic, weak) NSURL * photoURL;
		[Export("photoURL", ArgumentSemantic.Weak)]
		NSUrl PhotoURL { get; }

		// @property (readonly, nonatomic, weak) NSURL * thumbnailURL;
		[Export("thumbnailURL", ArgumentSemantic.Weak)]
		NSUrl ThumbnailURL { get; }

		// -(NSArray *)allKeys;
		[Export("allKeys")]
		NSObject[] AllKeys { get; }

		// -(id)objectForKey:(NSString *)key;
		[Export("objectForKey:")]
		NSObject ObjectForKey(string key);

		// -(id)objectForKeyedSubscript:(NSString *)key;
		[Export("objectForKeyedSubscript:")]
		NSObject ObjectForKeyedSubscript(string key);

		// -(NSString *)JSONString;
		[Export("JSONString")]
		string JSONString { get; }
	}

	// @protocol GSSessionDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface GSSessionDelegate
	{
		// @optional -(void)userDidLogin:(GSUser *)user;
		[Export("userDidLogin:")]
		void UserDidLogin(GSUser user);

		// @optional -(void)userDidLogout;
		[Export("userDidLogout")]
		void UserDidLogout();

		// @optional -(void)userInfoDidChange:(GSUser *)user;
		[Export("userInfoDidChange:")]
		void UserInfoDidChange(GSUser user);
	}

	// @protocol GSSocializeDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface GSSocializeDelegate
	{
		// @optional -(void)userDidLogin:(GSUser *)user;
		[Export("userDidLogin:")]
		void UserDidLogin(GSUser user);

		// @optional -(void)userDidLogout;
		[Export("userDidLogout")]
		void UserDidLogout();

		// @optional -(void)userInfoDidChange:(GSUser *)user;
		[Export("userInfoDidChange:")]
		void UserInfoDidChange(GSUser user);
	}

	// @protocol GSAccountsDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface GSAccountsDelegate
	{
		// @optional -(void)accountDidLogin:(GSAccount *)account;
		[Export("accountDidLogin:")]
		void AccountDidLogin(GSAccount account);

		// @optional -(void)accountDidLogout;
		[Export("accountDidLogout")]
		void AccountDidLogout();
	}

	// @protocol GSWebBridgeDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface GSWebBridgeDelegate
	{
		// @optional -(void)webView:(id)webView startedLoginForMethod:(NSString *)method parameters:(NSDictionary *)parameters;
		[Export("webView:startedLoginForMethod:parameters:")]
		void StartedLoginForMethod(NSObject webView, string method, NSDictionary parameters);

		// @optional -(void)webView:(id)webView finishedLoginWithResponse:(GSResponse *)response;
		[Export("webView:finishedLoginWithResponse:")]
		void FinishedLoginWithResponse(NSObject webView, GSResponse response);

		// @optional -(void)webView:(id)webView receivedPluginEvent:(NSDictionary *)event fromPluginInContainer:(NSString *)containerID;
		[Export("webView:receivedPluginEvent:fromPluginInContainer:")]
		void ReceivedPluginEvent(NSObject webView, NSDictionary @event, string containerID);

		// @optional -(void)webView:(id)webView receivedJsLog:(NSString *)logType logInfo:(NSDictionary *)logInfo;
		[Export("webView:receivedJsLog:logInfo:")]
		void ReceivedJsLog(NSObject webView, string logType, NSDictionary logInfo);
	}

	// @interface GSWebBridge : NSObject
	[BaseType(typeof(NSObject))]
	interface GSWebBridge
	{
		// +(void)registerWebView:(id)webView delegate:(id<GSWebBridgeDelegate>)delegate;
		[Static]
		[Export("registerWebView:delegate:")]
		void RegisterWebView(NSObject webView, GSWebBridgeDelegate @delegate);

		// +(void)registerWebView:(id)webView delegate:(id<GSWebBridgeDelegate>)delegate settings:(NSDictionary *)settings;
		[Static]
		[Export("registerWebView:delegate:settings:")]
		void RegisterWebView(NSObject webView, GSWebBridgeDelegate @delegate, NSDictionary settings);

		// +(void)unregisterWebView:(id)webView;
		[Static]
		[Export("unregisterWebView:")]
		void UnregisterWebView(NSObject webView);

		// +(void)webViewDidStartLoad:(id)webView;
		[Static]
		[Export("webViewDidStartLoad:")]
		void WebViewDidStartLoad(NSObject webView);

		// +(BOOL)handleRequest:(NSURLRequest *)request webView:(id)webView;
		[Static]
		[Export("handleRequest:webView:")]
		bool HandleRequest(NSUrlRequest request, NSObject webView);
	}

	// @protocol GSPluginViewDelegate <NSObject>
	[Protocol, Model]
	[BaseType(typeof(NSObject))]
	interface GSPluginViewDelegate
	{
		// @optional -(void)pluginView:(GSPluginView *)pluginView finishedLoadingPluginWithEvent:(NSDictionary *)event;
		[Export("pluginView:finishedLoadingPluginWithEvent:")]
		void FinishedLoadingPluginWithEvent(GSPluginView pluginView, NSDictionary @event);

		// @optional -(void)pluginView:(GSPluginView *)pluginView firedEvent:(NSDictionary *)event;
		[Export("pluginView:firedEvent:")]
		void FiredEvent(GSPluginView pluginView, NSDictionary @event);

		// @optional -(void)pluginView:(GSPluginView *)pluginView didFailWithError:(NSError *)error;
		[Export("pluginView:didFailWithError:")]
		void DidFailWithError(GSPluginView pluginView, NSError error);
	}

	// @interface GSPluginView : UIView
	[BaseType(typeof(UIView))]
	interface GSPluginView
	{
		[Wrap("WeakDelegate")]
		GSPluginViewDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<GSPluginViewDelegate> delegate;
		[NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }

		// -(void)loadPlugin:(NSString *)plugin;
		[Export("loadPlugin:")]
		void LoadPlugin(string plugin);

		// -(void)loadPlugin:(NSString *)plugin parameters:(NSDictionary *)parameters;
		[Export("loadPlugin:parameters:")]
		void LoadPlugin(string plugin, NSDictionary parameters);

		// @property (readonly, nonatomic) NSString * plugin;
		[Export("plugin")]
		string Plugin { get; }

		// @property (nonatomic) BOOL showLoginProgress;
		[Export("showLoginProgress")]
		bool ShowLoginProgress { get; set; }

		// @property (copy, nonatomic) NSString * loginProgressText;
		[Export("loginProgressText")]
		string LoginProgressText { get; set; }

		// @property (nonatomic) BOOL showLoadingProgress;
		[Export("showLoadingProgress")]
		bool ShowLoadingProgress { get; set; }

		// @property (copy, nonatomic) NSString * loadingProgressText;
		[Export("loadingProgressText")]
		string LoadingProgressText { get; set; }

		// @property (nonatomic) NSInteger javascriptLoadingTimeout;
		[Export("javascriptLoadingTimeout")]
		nint JavascriptLoadingTimeout { get; set; }
	}

	// typedef void (^ _Nullable)(GSUser * _Nullable, NSError * _Nullable) GSUserInfoHandler;
	delegate void GSUserInfoHandler([NullAllowed] GSUser arg0, [NullAllowed] NSError arg1);

	// typedef void (^ _Nullable)(BOOL, NSError * _Nullable, NSArray * _Nullable) GSPermissionRequestResultHandler;
	delegate void GSPermissionRequestResultHandler(bool arg0, [NullAllowed] NSError arg1, [NullAllowed] NSObject[] arg2);

	// typedef void (^GSPluginCompletionHandler)(BOOL, NSError * _Nullable);
	delegate void GSPluginCompletionHandler(bool arg0, [NullAllowed] NSError arg1);

	// typedef void (^GSGetSessionCompletionHandler)(GSSession * _Nullable);
	delegate void GSGetSessionCompletionHandler([NullAllowed] GSSession arg0);

	// @interface Gigya : NSObject
	[BaseType(typeof(NSObject))]
	interface Gigya
	{
		// +(void)initWithAPIKey:(NSString *)apiKey application:(UIApplication *)application launchOptions:(NSDictionary *)launchOptions;
		[Static]
		[Export("initWithAPIKey:application:launchOptions:")]
		void InitWithAPIKey(string apiKey, UIApplication application, NSDictionary launchOptions);

		// +(void)initWithAPIKey:(NSString *)apiKey application:(UIApplication *)application launchOptions:(NSDictionary *)launchOptions APIDomain:(NSString *)apiDomain;
		[Static]
		[Export("initWithAPIKey:application:launchOptions:APIDomain:")]
		void InitWithAPIKey(string apiKey, UIApplication application, NSDictionary launchOptions, string apiDomain);

		// +(NSString *)APIKey;
		[Static]
		[Export("APIKey")]
		string APIKey { get; }

		// +(NSString *)APIDomain;
		[Static]
		[Export("APIDomain")]
		string APIDomain { get; }

		// +(void)getSessionWithCompletionHandler:(GSGetSessionCompletionHandler _Nonnull)handler;
		[Static]
		[Export("getSessionWithCompletionHandler:")]
		void GetSessionWithCompletionHandler(GSGetSessionCompletionHandler handler);

		// +(BOOL)isSessionValid;
		[Static]
		[Export("isSessionValid")]
		bool IsSessionValid();

		// +(void)setSession:(GSSession * _Nullable)session;
		[Static]
		[Export("setSession:")]
		void SetSession([NullAllowed] GSSession session);

		// +(id<GSSessionDelegate>)sessionDelegate;
		// +(void)setSessionDelegate:(id<GSSessionDelegate>)delegate __attribute__((deprecated("Use [Gigya setSocializeDelegate:] with a GSSocializeDelegate instead")));
		[Static]
		[Export("sessionDelegate")]
		GSSessionDelegate SessionDelegate { get; set; }

		// +(id<GSSocializeDelegate> _Nullable)socializeDelegate;
		[Static]
		[Export("socializeDelegate")]
		[return: NullAllowed]
		GSSocializeDelegate SocializeDelegate();

		// +(void)setSocializeDelegate:(id<GSSocializeDelegate> _Nullable)socializeDelegate;
		[Static]
		[Export("setSocializeDelegate:")]
		void SetSocializeDelegate([NullAllowed] GSSocializeDelegate socializeDelegate);

		// +(id<GSAccountsDelegate> _Nullable)accountsDelegate;
		[Static]
		[Export("accountsDelegate")]
		[return: NullAllowed]
		GSAccountsDelegate AccountsDelegate();

		// +(void)setAccountsDelegate:(id<GSAccountsDelegate> _Nullable)accountsDelegate;
		[Static]
		[Export("setAccountsDelegate:")]
		void SetAccountsDelegate([NullAllowed] GSAccountsDelegate accountsDelegate);

		// +(void)loginToProvider:(NSString * _Nonnull)provider;
		[Static]
		[Export("loginToProvider:")]
		void LoginToProvider(string provider);

		// +(void)showLoginDialogOver:(UIViewController *)viewController provider:(NSString *)provider __attribute__((deprecated("Use loginToProvider: instead")));
		[Static]
		[Export("showLoginDialogOver:provider:")]
		void ShowLoginDialogOver(UIViewController viewController, string provider);

		// +(void)loginToProvider:(NSString * _Nonnull)provider parameters:(NSDictionary * _Nullable)parameters completionHandler:(GSUserInfoHandler _Nullable)handler;
		[Static]
		[Export("loginToProvider:parameters:completionHandler:")]
		void LoginToProvider(string provider, [NullAllowed] NSDictionary parameters, [NullAllowed] GSUserInfoHandler handler);

		// +(void)showLoginDialogOver:(UIViewController *)viewController provider:(NSString *)provider parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler __attribute__((deprecated("Use loginToProvider:parameters:completionHandler: instead")));
		[Static]
		[Export("showLoginDialogOver:provider:parameters:completionHandler:")]
		void ShowLoginDialogOver(UIViewController viewController, string provider, NSDictionary parameters, [NullAllowed] GSUserInfoHandler handler);

		// +(void)loginToProvider:(NSString * _Nonnull)provider parameters:(NSDictionary * _Nullable)parameters over:(UIViewController * _Nullable)viewController completionHandler:(GSUserInfoHandler _Nullable)handler;
		[Static]
		[Export("loginToProvider:parameters:over:completionHandler:")]
		void LoginToProvider(string provider, [NullAllowed] NSDictionary parameters, [NullAllowed] UIViewController viewController, [NullAllowed] GSUserInfoHandler handler);

		// +(void)showLoginProvidersDialogOver:(UIViewController *)viewController;
		[Static]
		[Export("showLoginProvidersDialogOver:")]
		void ShowLoginProvidersDialogOver(UIViewController viewController);

		// +(void)showLoginProvidersPopoverFrom:(UIView *)view;
		[Static]
		[Export("showLoginProvidersPopoverFrom:")]
		void ShowLoginProvidersPopoverFrom(UIView view);

		// +(void)showLoginProvidersDialogOver:(UIViewController *)viewController providers:(NSArray *)providers parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export("showLoginProvidersDialogOver:providers:parameters:completionHandler:")]
		void ShowLoginProvidersDialogOver(UIViewController viewController, string[] providers, NSDictionary parameters, [NullAllowed] GSUserInfoHandler handler);

		// +(void)showLoginProvidersPopoverFrom:(UIView *)view providers:(NSArray *)providers parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export("showLoginProvidersPopoverFrom:providers:parameters:completionHandler:")]
		void ShowLoginProvidersPopoverFrom(UIView view, string[] providers, NSDictionary parameters, [NullAllowed] GSUserInfoHandler handler);

		// +(void)logout;
		[Static]
		[Export("logout")]
		void Logout();

		// +(void)logoutWithCompletionHandler:(GSResponseHandler)handler;
		[Static]
		[Export("logoutWithCompletionHandler:")]
		void LogoutWithCompletionHandler([NullAllowed] GSResponseHandler handler);

		// +(void)addConnectionToProvider:(NSString *)provider;
		[Static]
		[Export("addConnectionToProvider:")]
		void AddConnectionToProvider(string provider);

		// +(void)showAddConnectionDialogOver:(UIViewController *)viewController provider:(NSString *)provider __attribute__((deprecated("Use addConnectionToProvider: instead")));
		[Static]
		[Export("showAddConnectionDialogOver:provider:")]
		void ShowAddConnectionDialogOver(UIViewController viewController, string provider);

		// +(void)addConnectionToProvider:(NSString *)provider parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export("addConnectionToProvider:parameters:completionHandler:")]
		void AddConnectionToProvider(string provider, NSDictionary parameters, [NullAllowed] GSUserInfoHandler handler);

		// +(void)showAddConnectionDialogOver:(UIViewController *)viewController provider:(NSString *)provider parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler __attribute__((deprecated("Use addConnectionToProvider:parameters:completionHandler: instead")));
		[Static]
		[Export("showAddConnectionDialogOver:provider:parameters:completionHandler:")]
		void ShowAddConnectionDialogOver(UIViewController viewController, string provider, NSDictionary parameters, [NullAllowed] GSUserInfoHandler handler);

		// +(void)addConnectionToProvider:(NSString *)provider parameters:(NSDictionary *)parameters over:(UIViewController *)viewController completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export("addConnectionToProvider:parameters:over:completionHandler:")]
		void AddConnectionToProvider(string provider, NSDictionary parameters, UIViewController viewController, [NullAllowed] GSUserInfoHandler handler);

		// +(void)showAddConnectionProvidersDialogOver:(UIViewController *)viewController;
		[Static]
		[Export("showAddConnectionProvidersDialogOver:")]
		void ShowAddConnectionProvidersDialogOver(UIViewController viewController);

		// +(void)showAddConnectionProvidersPopoverFrom:(UIView *)view;
		[Static]
		[Export("showAddConnectionProvidersPopoverFrom:")]
		void ShowAddConnectionProvidersPopoverFrom(UIView view);

		// +(void)showAddConnectionProvidersDialogOver:(UIViewController *)viewController providers:(NSArray *)providers parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export("showAddConnectionProvidersDialogOver:providers:parameters:completionHandler:")]
		void ShowAddConnectionProvidersDialogOver(UIViewController viewController, string[] providers, NSDictionary parameters, [NullAllowed] GSUserInfoHandler handler);

		// +(void)showAddConnectionProvidersPopoverFrom:(UIView *)view providers:(NSArray *)providers parameters:(NSDictionary *)parameters completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export("showAddConnectionProvidersPopoverFrom:providers:parameters:completionHandler:")]
		void ShowAddConnectionProvidersPopoverFrom(UIView view, string[] providers, NSDictionary parameters, [NullAllowed] GSUserInfoHandler handler);

		// +(void)removeConnectionToProvider:(NSString *)provider;
		[Static]
		[Export("removeConnectionToProvider:")]
		void RemoveConnectionToProvider(string provider);

		// +(void)removeConnectionToProvider:(NSString *)provider completionHandler:(GSUserInfoHandler)handler;
		[Static]
		[Export("removeConnectionToProvider:completionHandler:")]
		void RemoveConnectionToProvider(string provider, [NullAllowed] GSUserInfoHandler handler);

		// +(void)showPluginDialogOver:(UIViewController *)viewController plugin:(NSString *)plugin parameters:(NSDictionary *)parameters;
		[Static]
		[Export("showPluginDialogOver:plugin:parameters:")]
		void ShowPluginDialogOver(UIViewController viewController, string plugin, NSDictionary parameters);

		// +(void)showPluginDialogOver:(UIViewController *)viewController plugin:(NSString *)plugin parameters:(NSDictionary *)parameters completionHandler:(GSPluginCompletionHandler)handler;
		[Static]
		[Export("showPluginDialogOver:plugin:parameters:completionHandler:")]
		void ShowPluginDialogOver(UIViewController viewController, string plugin, NSDictionary parameters, GSPluginCompletionHandler handler);

		// +(void)showPluginDialogOver:(UIViewController *)viewController plugin:(NSString *)plugin parameters:(NSDictionary *)parameters completionHandler:(GSPluginCompletionHandler)handler delegate:(id<GSPluginViewDelegate>)delegate;
		[Static]
		[Export("showPluginDialogOver:plugin:parameters:completionHandler:delegate:")]
		void ShowPluginDialogOver(UIViewController viewController, string plugin, NSDictionary parameters, GSPluginCompletionHandler handler, GSPluginViewDelegate @delegate);

		// +(void)requestNewFacebookPublishPermissions:(NSString *)permissions viewController:(UIViewController * _Nullable)viewController responseHandler:(GSPermissionRequestResultHandler)handler;
		[Static]
		[Export("requestNewFacebookPublishPermissions:viewController:responseHandler:")]
		void RequestNewFacebookPublishPermissions(string permissions, [NullAllowed] UIViewController viewController, [NullAllowed] GSPermissionRequestResultHandler handler);

		// +(void)requestNewFacebookReadPermissions:(NSString *)permissions viewController:(UIViewController * _Nullable)viewController responseHandler:(GSPermissionRequestResultHandler)handler;
		[Static]
		[Export("requestNewFacebookReadPermissions:viewController:responseHandler:")]
		void RequestNewFacebookReadPermissions(string permissions, [NullAllowed] UIViewController viewController, [NullAllowed] GSPermissionRequestResultHandler handler);

		// +(BOOL)handleOpenURL:(NSURL *)url app:(UIApplication *)app options:(NSDictionary<NSString *,id> *)options;
		[Static]
		[Export("handleOpenURL:app:options:")]
		bool HandleOpenURL(NSUrl url, UIApplication app, NSDictionary<NSString, NSObject> options);

		// +(BOOL)handleOpenURL:(NSURL *)url application:(UIApplication *)application sourceApplication:(NSString *)sourceApplication annotation:(id)annotation;
		[Static]
		[Export("handleOpenURL:application:sourceApplication:annotation:")]
		bool HandleOpenURL(NSUrl url, UIApplication application, [NullAllowed] string sourceApplication, [NullAllowed] NSObject annotation);

		// +(void)handleDidBecomeActive;
		[Static]
		[Export("handleDidBecomeActive")]
		void HandleDidBecomeActive();

		// +(BOOL)useHTTPS;
		[Static]
		[Export("useHTTPS")]
		bool UseHTTPS();

		// +(void)setUseHTTPS:(BOOL)useHTTPS;
		[Static]
		[Export("setUseHTTPS:")]
		void SetUseHTTPS(bool useHTTPS);

		// +(BOOL)networkActivityIndicatorEnabled;
		[Static]
		[Export("networkActivityIndicatorEnabled")]
		bool NetworkActivityIndicatorEnabled();

		// +(void)setNetworkActivityIndicatorEnabled:(BOOL)networkActivityIndicatorEnabled;
		[Static]
		[Export("setNetworkActivityIndicatorEnabled:")]
		void SetNetworkActivityIndicatorEnabled(bool networkActivityIndicatorEnabled);

		// +(NSTimeInterval)requestTimeout;
		[Static]
		[Export("requestTimeout")]
		double RequestTimeout();

		// +(void)setRequestTimeout:(NSTimeInterval)requestTimeout;
		[Static]
		[Export("setRequestTimeout:")]
		void SetRequestTimeout(double requestTimeout);

		// +(BOOL)dontLeaveApp;
		[Static]
		[Export("dontLeaveApp")]
		bool DontLeaveApp();

		// +(void)setDontLeaveApp:(BOOL)dontLeaveApp;
		[Static]
		[Export("setDontLeaveApp:")]
		void SetDontLeaveApp(bool dontLeaveApp);

		// +(BOOL)__debugOptionEnableTestNetworks;
		[Static]
		[Export("__debugOptionEnableTestNetworks")]
		bool __debugOptionEnableTestNetworks();

		// +(void)__setDebugOptionEnableTestNetworks:(BOOL)debugOptionEnableTestNetworks;
		[Static]
		[Export("__setDebugOptionEnableTestNetworks:")]
		void __setDebugOptionEnableTestNetworks(bool debugOptionEnableTestNetworks);
	}
}
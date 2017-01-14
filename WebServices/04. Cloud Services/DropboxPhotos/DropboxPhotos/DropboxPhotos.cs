﻿namespace DropboxPhotos
{
    using System;
    using System.IO;
    using System.Diagnostics;

    using Spring.Social.OAuth1;
    using Spring.Social.Dropbox.Api;
    using Spring.Social.Dropbox.Connect;
    using Spring.IO;

    public class DropboxPhotos
    {
        // Register your own Dropbox app at https://www.dropbox.com/developers/apps
        // with "Full Dropbox" access level and set your app keys and app secret below
        private const string DropboxAppKey = "zzf4pb30klyr42v";
        private const string DropboxAppSecret = "mwl54uqcuzs9qxq";
        private const string OAuthTokenFileName = "OAuthTokenFileName.txt";

        static void Main()
        {
            DropboxServiceProvider dropboxServiceProvider =
                new DropboxServiceProvider(DropboxAppKey, DropboxAppSecret, AccessLevel.Full);

            // Authenticate the application (if not authenticated) and load the OAuth token
            if (!File.Exists(OAuthTokenFileName))
            {
                AuthorizeAppOAuth(dropboxServiceProvider);
            }
            OAuthToken oauthAccessToken = LoadOAuthToken();

            // Login in Dropbox
            IDropbox dropbox = dropboxServiceProvider.GetApi(oauthAccessToken.Value, oauthAccessToken.Secret);

            // Display user name (from his profile)
            DropboxProfile profile = dropbox.GetUserProfileAsync().Result;
            Console.WriteLine("Hi " + profile.DisplayName + "!");

            // Create new folder
            string newFolderName = "Photos_" + DateTime.Now.Ticks;
            Entry createFolderEntry = dropbox.CreateFolderAsync(newFolderName).Result;
            Console.WriteLine("Created folder: {0}", createFolderEntry.Path);

            //Put of all your photos in the folder "Photos"
            //Selecting files
            string[] filePaths = Directory.GetFiles(@"../../Photos/");

            //Uploading files
            for (int i = 0; i < filePaths.Length; i++)
            {
                string filePath = filePaths[i];
                var fileResource = new FileResource(filePath);

                Entry uploadFileEntry = dropbox.UploadFileAsync(
                fileResource,
                "/" + newFolderName + string.Format("/Photo_{0}.jpg", i)).Result;
                Console.WriteLine("Uploaded a file: {0}", uploadFileEntry.Path);

                // Share a file
                DropboxLink sharedUrl = dropbox.GetShareableLinkAsync(uploadFileEntry.Path).Result;
                Process.Start(sharedUrl.Url);
            }
        }

        private static OAuthToken LoadOAuthToken()
        {
            string[] lines = File.ReadAllLines(OAuthTokenFileName);
            OAuthToken oauthAccessToken = new OAuthToken(lines[0], lines[1]);
            return oauthAccessToken;
        }

        private static void AuthorizeAppOAuth(DropboxServiceProvider dropboxServiceProvider)
        {
            // Authorization without callback url
            Console.Write("Getting request token...");
            OAuthToken oauthToken = dropboxServiceProvider.OAuthOperations.FetchRequestTokenAsync(null, null).Result;
            Console.WriteLine("Done.");

            OAuth1Parameters parameters = new OAuth1Parameters();
            string authenticateUrl = dropboxServiceProvider.OAuthOperations.BuildAuthorizeUrl(
                oauthToken.Value, parameters);
            Console.WriteLine("Redirect the user for authorization to {0}", authenticateUrl);
            Process.Start(authenticateUrl);
            Console.Write("Press [Enter] when authorization attempt has succeeded.");
            Console.ReadLine();

            Console.Write("Getting access token...");
            AuthorizedRequestToken requestToken = new AuthorizedRequestToken(oauthToken, null);
            OAuthToken oauthAccessToken =
                dropboxServiceProvider.OAuthOperations.ExchangeForAccessTokenAsync(requestToken, null).Result;
            Console.WriteLine("Done.");

            string[] oauthData = new string[] { oauthAccessToken.Value, oauthAccessToken.Secret };
            File.WriteAllLines(OAuthTokenFileName, oauthData);
        }
    }

}

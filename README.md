# csharp-jive-api-wrapper

A simple wrapper to communicate with the Jive Software REST API.
It provides :
* A model that represents API objects (blog posts, documents, persons, etc.)
* Authentication method with the possibility to impersonate a different user
* Methods to GET, PUT, POST items to the API
* A list of available endpoints (work in progress)

# How to use it

```csharp
// wrapper instanciation
Client jiveApiClient = new Client
{
    APIBaseURI = "https://your-instance.com/api/core/v3",
    AuthenticationURI = "https://your-instance.com/oauth2/token",
    OauthId = "oauthtoken123456.i",
    OauthSecret = "oauthsecret123456.s",
    Username = "adminlogin",
    Password = "password"
};

// Logger configuration
log4net.Config.XmlConfigurator.Configure();
ILogger logging_adapter = new Log4netAdapter(log);
jiveApiClient.setLogger(logging_adapter);

// Authentication
bool isAuthentified = jiveApiClient.Authentify();
if (isAuthentified) {
	// Get person by username
	Person person = jiveApiClient.GetItem<Person>(EndPoints.PeopleByIdWithPhotos, "usernameToFind");
}
```
# Available endpoints
Work in progress...
```csharp
// Contents
public static String AllContents = "/contents";
public static String ContentById = "/contents/{0}";
public static String ContentsAttachments = "/attachments/contents/{0}";

// Persons/people
public static String PersonByIdWithPhotos = "/people/username/{0}?fields=photos";
public static String TemporaryProfileImage = "/profileImages/temporary";
public static String PersonByIdProfileImages = "/people/{0}/images/";
public static String PersonByUsernameProfileImages = "/people/{0}/images/";

// Places
public static String Places = "/places";
public static String PlaceById = "/places/{0}";
// Statics
public static String StaticsByPlaceID = "/statics/{0}";
```
# Use cases
**Get a Person** 
```csharp
// Get person by username
Person person = jiveApiClient.GetItem<Person>(EndPoints.PeopleByIdWithPhotos, "usernameToFind");
```

**List all contents**
```csharp
// List contents
ContentList content = jiveApiClient.GetItem<ContentList>(EndPoints.AllContents);
```

**List contents attachments**
```csharp
// List content's attachements
string contentID = "5279";
List<Attachment> attachments = jiveApiClient.GetContent<List<Attachment>>(EndPoints.ContentsAttachments, contentID);
```

**List all places**
```csharp
// List places
PlacesList places = jiveApiClient.GetItem<PlacesList>(EndPoints.Places);
```

**Get a place by ID**
```csharp
// Get a place by id
string placeID = "5279";
string myPlaceEndPoint = String.Format(EndPoints.PlaceById, placeID);
Place place = jiveApiClient.GetItem<Place>(myPlaceEndPoint);
```

**Get persons pictures by ID**
```csharp
// Get persons pictures by ID
Person person = jiveApiClient.GetContent<Person>(EndPoints.PeopleByIdPhotosOnly, "5424");
```

**Post a blog post on behalf another person**
```csharp
// Post a blog post
// Caution : beware of passing the id of the "blog" itself, not the id of the place, as blog posts cannot be pushed directly to a place
String blogURI = jiveApiClient.APIBaseURI + String.Format(EndPoints.PlaceById, "5280");
String impersonatedLogin = "johnsmith";
Post post = new Post();
post.subject = "test";
post.type = "post";
post.content = new ContentBody();
post.content.text = "Hello world";
post.content.type = "text/html";
post.parent = blogURI;
APIResult result = jiveApiClient.PostItem<Post>(EndPoints.AllContents, post, null, impersonatedLogin);
```

**Uploading an attachment to an article**
```csharp
// Uploading an attachment to an article
String contentsAttachmentsEndpoint = String.Format(EndPoints.ContentsAttachments, "34403");
APIResult result = jiveApiClient.UploadToItem(contentsAttachmentsEndpoint, System.IO.File.ReadAllBytes("D:/yourfile.png"), "png", "image/png", "filename.png");
```
**Uploading a profile image to a person**
```csharp
// Uploading a profile image to a person
String personByIdProfileImagesEndPoint = String.Format(EndPoints.PersonByIdProfileImages, "5424");
// step 1 : upload a temp image service
APIResult result = jiveApiClient.UploadToItem(EndPoints.TemporaryProfileImage, System.IO.File.ReadAllBytes("D:/goldenmoustache.png"), "png", "image/png", "goldenmoustache.png");
// step 2 : get the uploaded file's URI
String uploadedTempImageURI = result2.ressourceUrl;
if (uploadedTempImageURI != null) {
	// step 3 : set the temp image as a profile image 
	var nvc = new List<KeyValuePair<string, string>>();
	nvc.Add(new KeyValuePair<string, string>("imageURI", uploadedTempImageURI));
	APIResult result2 = jiveApiClient.PostFormToEndPoint(personByIdProfileImagesEndPoint, nvc);
}
```


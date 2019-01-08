# Blazor Technology Character Generator

The purpose of this application is to compare performance of a client-side Blazor application with a server-side Blazor application.

## Deployment

There are 3 seperate components that need to be deployed for the application to work completely.

### 1. TechnologyCharacterGenerator.Child.Client

TechnologyCharacterGenerator.Child.Client is the same application as TechnologyCharacterGenerator.Child.Server but TechnologyCharacterGenerator.Child.Client runs client-side in the user's browser while TechnologyCharacterGenerator.Child.Server uses Razor Components and runs on the server-side.

### 2. TechnologyCharacterGenerator.Child.Server

TechnologyCharacterGenerator.Child.Server is the same application as TechnologyCharacterGenerator.Child.Client but TechnologyCharacterGenerator.Child.Server uses Razor Components and runs on the server-side while TechnologyCharacterGenerator.Child.Client runs client-side in the user's browser.

### 3. TechnologyCharacterGenerator.Parent.Server

TechnologyCharacterGenerator.Parent.Server is a blazor application that loads both TechnologyCharacterGenerator.Child.Client and TechnologyCharacterGenerator.Child.Server in iFrames and tracks the performance of both applications. It has a form that allows TechnologyCharacterGenerator.Parent.Server to control both child applications at the same time.

TechnologyCharacterGenerator.Parent.Server requires configuration that defines both the "ClientApplicationUrl" and the "ServerApplicationUrl".

Example secrets.json:

```json
{
  "ClientApplicationUrl": "http://localhost:65254/",
  "ServerApplicationUrl": "http://localhost:65233/"
}
```

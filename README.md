## Running the App
Add your Ditto `App_Id` and `Token` to 
```
ditto = new Ditto(identity: DittoIdentity.OnlinePlayground("<App_ID>", "<TOKEN>"));
```
in the `/DittoToolsApp/Program.cs` file.

In the terminal, navigate to the `DittoToolsApp` folder and run `dotnet run --project DittoToolsApp.csproj`

This will start the `Heartbeat`.
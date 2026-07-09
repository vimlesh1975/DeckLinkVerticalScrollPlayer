# Compile the project in Release mode.
# The custom MSBuild Target inside DeckLinkVerticalScrollPlayer.vbproj automatically handles killing older instances,
# cleaning, creating the timestamped executable, and launching the new player instance.
dotnet build .\DeckLinkVerticalScrollPlayer.vbproj -c Release

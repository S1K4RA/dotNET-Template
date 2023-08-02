# dotNET-Template
Basic API Template using Newtonsoft library

How To Use
1. Download project and save as .zip file
2. Place the .zip file at Visual Studio Project Templates Folder (ex. ..\Documents\Visual Studio 2019\Templates\ProjectTemplates)
3. Restart Visual Studio
4. Load project as template for new project(s)
5. Open .csproj file in Text Editor App
6. Comment this line 

```
 <Target Name="EnsureNuGetPackageBuildImports" BeforeTargets="PrepareForBuild">
    <PropertyGroup>
      <ErrorText>This project references NuGet package(s) that are missing on this computer. Use NuGet Package Restore to download them.  For more information, see http://go.microsoft.com/fwlink/?LinkID=322105. The missing file is {0}.</ErrorText>
    </PropertyGroup>
    <Error Condition="!Exists('..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.2.0.1\build\net46\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props')" Text="$([System.String]::Format('$(ErrorText)', '..\packages\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.2.0.1\build\net46\Microsoft.CodeDom.Providers.DotNetCompilerPlatform.props'))" />
  </Target>
```
7. Build the project
8. You're good to go :)

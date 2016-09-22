# LocalNugetWizard
A small VS template wizard to copy local NuGet packages and configs to the destination solution.


Usage
------------------------
- Build
- Register assembly in GAC
- Add the following lines in your project template vstemplate file, inside the VSTemplate tag, replacing the PublicKeyToken with the one retrieved from gacutil :

```
  <WizardExtension>
    <Assembly>
      LocalNuGetWizard, Version=1.0.0.0, Culture=neutral, PublicKeyToken=e7c9b03113558b13, processorArchitecture=MSIL
    </Assembly>
    <FullClassName>LocalNuGetWizard.LocalNuGetWizard</FullClassName>
  </WizardExtension>
```

- In your VS project template root, put a NuGet.config file with the following content

```
<?xml version="1.0" encoding="utf-8"?>
  <configuration>
    <packageSources>
      <add key="LocalPackages" value="./LocalPackages" />
    </packageSources>
    <activePackageSource>
      <!-- this tells that all of them are active -->
      <add key="All" value="(Aggregate source)" />
    </activePackageSource>
 </configuration>
```

 - Add your local NuGet packages in the LocalPackages directory, still under the template root.
 
 
Behavior
------------------------
Upon creating a project from your template, the packages and config file will be copied to the destination solution folder.  This setup will allow you to reference these packages from within your template and to see them listed in the package manager for manual installation.

A nice and easy way to distribute your library to customer projects without giving away your code!  If your customers need an update or fix, then you only need to send them the updated NuGet package and update the reference in the solution.
